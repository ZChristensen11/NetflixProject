using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeramecNetFlixProject.Business_Objects;
using MeramecNetFlixProject.Data_Access_Layer;

namespace MeramecNetFlixProject.UI
{
    public partial class RentalForm : Form
    {
        public List<Movie> Movies { get; set; }

        public RentalForm()
        {
            InitializeComponent();
            Movies = MovieDB.GetMovies();
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;

            initPictureBoxes();

            pbLeftArrow.Enabled = false;
            pbLeftArrow.Visible = false;

            
        }

        Member member = MemberDB.GetMember("buddy");
        public RentalForm(Member member)
        {
            InitializeComponent();
            Movies = MovieDB.GetMovies();
            this.member = member;
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            initPictureBoxes();
            PopulateGenreCB();

            pbLeftArrow.Enabled = false;
            pbLeftArrow.Visible = false;
        }

        List<PictureBox> pictureBoxes = new List<PictureBox>();
        private void initPictureBoxes()
        {
            int locCounter = 3;
            for (int i = 0; i < 5; i++)
            {
                PictureBox pb = new PictureBox();
                pictureBoxes.Add(pb);
                pb.Name = "pb" + i;
                pb.Parent = panelMovies;
                pb.Cursor = Cursors.Hand;
                pb.Location = new Point(locCounter, 3);
                locCounter += 250;
                pb.Size = new Size(247, 365);
                pb.ImageLocation = photoDir + "\\MoviePosters\\" + Movies[i].image;
                pb.Tag = Movies[i].movie_number;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Click += new EventHandler(movieClick);
                pb.Load();

                

            }

        }

        private void PopulateGenreCB()
        {
            try
            {
                List<Genre> genres = GenreDB.GetGenres();
                cbGenre.DisplayMember = "Name";
                cbGenre.ValueMember = "ID";
                cbGenre.DataSource = genres;

            }
            catch (Exception)
            {

                throw;
            }
        }

        // unused
        private int GetMaxIdx(List<Movie> movies)
        {
            IEnumerable<int> numbers = from movie in movies
                                       select Convert.ToInt32(movie.movie_number);

            int maxIdx = numbers.Max<int>();
            return maxIdx;
        }

        private void GetMoviesByGenre(int genreID)
        {
            try
            {
                Movies = MovieDB.GetMoviesByGenre(genreID);
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int startIdx = 0;
        string photoDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Photos";
        private void LoadMovies()
        {


            try
            {
                //List<Movie> movies = MovieDB.GetMovies();
                
                
                if (startIdx >= Movies.Count() || startIdx <= 0)
                {
                    startIdx = 0;
                    pbLeftArrow.Enabled = false;
                    pbLeftArrow.Visible = false;
                }
                else
                {
                    pbLeftArrow.Enabled = true;
                    pbLeftArrow.Visible = true;
                }

                int maxIdx = Movies.Count();
                int endIdx = 0;
                if ((startIdx + 4) >= maxIdx) // or equal to because idx is base 1 and the lists are base 0
                {
                    endIdx = (startIdx + 4) - maxIdx;
                    //endIdx = maxIdx - 1;
                }
                else
                {
                    endIdx = startIdx + 4;
                }
                

                IEnumerable<string> imageQuery;
                IEnumerable<string> idQuery;
                
                imageQuery = from movie in Movies
                                orderby Convert.ToInt32(movie.movie_number) ascending
                                select movie.image;
                idQuery = from movie in Movies
                            orderby Convert.ToInt32(movie.movie_number) ascending
                            select movie.movie_number;
                //MessageBox.Show("Start: " + startIdx.ToString() + "\nEnd: " + endIdx.ToString());


                List<string> posters = new List<string>();
                foreach (string filename in imageQuery)
                {
                    posters.Add(filename);
                }
                List<string> movieNumbers = new List<string>();
                foreach (string number in idQuery)
                {
                    movieNumbers.Add(number);
                }

                //MessageBox.Show(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName);
                
                //string msg = "";
                for (int i = 0; i < 5; i++)
                {
                    PictureBox pb = pictureBoxes[i];
                    int idx = (startIdx + i) % (posters.Count());
                    pb.ImageLocation = photoDir + "\\MoviePosters\\" + posters[idx];
                    pb.Tag = movieNumbers[idx];
                    pb.Load();
                    //msg += " " + movieNumbers[idx];
                }
                //MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void movieClick(object sender, EventArgs e)
        {


            try
            {
                PictureBox pb = sender as PictureBox;

                Thread viewMovie = new Thread(() => new ViewMovie(MovieDB.GetMovie(Convert.ToInt32(pb.Tag)), member.number).ShowDialog());
                viewMovie.SetApartmentState(ApartmentState.STA);
                viewMovie.Start();

            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*
             * stored procedure should be to decrement copies on hand when rental is added 
             * 
             * 
             * 
             * 
             */


        }


        private void pbRightArrow_Click(object sender, EventArgs e)
        {
            startIdx += 4;
            LoadMovies();
            
        }

        private void pbLeftArrow_Click(object sender, EventArgs e)
        {
            startIdx -= 4;
            LoadMovies();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Movie movie = MovieDB.GetMovie(txtTitle.Text.Trim());
            if (movie != null)
            {
                Thread viewMovie = new Thread(() => new ViewMovie(movie, member.number).ShowDialog());
                viewMovie.SetApartmentState(ApartmentState.STA);
                viewMovie.Start();

            }
            else
            {
                MessageBox.Show(txtTitle.Text.Trim() + " not found.", "Uh oh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearchByGenre_Click(object sender, EventArgs e)
        {
            GetMoviesByGenre(Convert.ToInt32(((Genre)cbGenre.SelectedItem).ID));
            LoadMovies();

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            Movies = MovieDB.GetMovies();
            LoadMovies();
        }
    }
}
