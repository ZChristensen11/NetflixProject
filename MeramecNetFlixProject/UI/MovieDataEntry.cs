using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeramecNetFlixProject.Business_Objects;
using MeramecNetFlixProject.Data_Access_Layer;

namespace MeramecNetFlixProject.UI
{
    public partial class MovieDataEntry : Form
    {
        public MovieDataEntry()
        {
            InitializeComponent();
            populateGenreNames();
        }

        private void populateGenreNames()
        {
            List<Genre> genres = GenreDB.GetGenres();

            cbGenre.DisplayMember = "Name";
            cbGenre.ValueMember = "ID";
            cbGenre.DataSource = genres;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Call the MovieDB static class to fill the data grid
            try
            {
                List<Movie> movieList = new List<Movie>();
                movieList = MovieDB.GetMovies();
                dataGridView1.DataSource = movieList;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Validate the UI
            if (string.IsNullOrEmpty(txtMovieNumber.Text.Trim()))
            {
                MessageBox.Show("Please enter a movie id.");
                txtMovieNumber.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMovieTitle.Text.Trim()))
            {
                MessageBox.Show("Please enter a movie name.");
                txtMovieNumber.Focus();
                return;
            }

            Movie objMovie = new Movie();
            objMovie.movie_number = txtMovieNumber.Text.Trim();
            objMovie.movie_title = txtMovieTitle.Text.Trim();
            objMovie.description = txtDescription.Text.Trim();
            objMovie.movie_year_made = txtMovieYearMade.Text.Trim();
            objMovie.genre_id = ((Genre)cbGenre.SelectedItem).ID.ToString();
            objMovie.movie_rating = cbRating.Text.Trim();
            objMovie.media_type = cbMediaType.Text.Trim();
            objMovie.movie_retail_cost = Math.Round(Convert.ToDecimal(txtRetailCost.Text.Trim()),2);
            objMovie.copies_on_hand = txtCopiesOnHand.Text.Trim();
            objMovie.image = txtImageFilename.Text.Trim();
            objMovie.trailer = txtTrailerLink.Text.Trim();
            try
            {
                bool status = MovieDB.AddMovie(objMovie);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Movie added to the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Movie was not added to database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //Validate the UI
            if (string.IsNullOrEmpty(txtMovieNumber.Text.Trim()))
            {
                MessageBox.Show("Please enter a movie id.");
                txtMovieNumber.Focus();
                return;
            }

            Movie objMovie = MovieDB.GetMovie(Convert.ToInt32(txtMovieNumber.Text.Trim()));
            //Step 2: Validate to make sure the Customer object is not null.
            if (objMovie != null)
            {
                //Populate the UI with the object values
                txtMovieNumber.Text = objMovie.movie_number;
                txtMovieTitle.Text = objMovie.movie_title;
                txtMovieTitle.Text = objMovie.movie_title;
                txtDescription.Text = objMovie.description;
                txtMovieYearMade.Text = objMovie.movie_year_made;
                for (int i = 0; i < cbGenre.Items.Count; i++)
                {
                    if (objMovie.genre_id == ((Genre)cbGenre.Items[i]).ID.ToString())
                    {
                        cbGenre.SelectedIndex = i;
                    }
                }
                cbRating.Text = objMovie.movie_rating;
                cbMediaType.Text = objMovie.media_type;
                txtRetailCost.Text = Math.Round(objMovie.movie_retail_cost,2).ToString();
                txtCopiesOnHand.Text = objMovie.copies_on_hand;
                txtImageFilename.Text = objMovie.image;
                txtTrailerLink.Text = objMovie.trailer;
                //make Movie ID field read-only to be used for updating and deleting records demo
                txtMovieNumber.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Movie ID " + txtMovieNumber.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Validate the UI
            if (string.IsNullOrEmpty(txtMovieNumber.Text.Trim()))
            {
                MessageBox.Show("Please enter a movie id.");
                txtMovieNumber.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMovieTitle.Text.Trim()))
            {
                MessageBox.Show("Please enter a movie name.");
                txtMovieNumber.Focus();
                return;
            }

           

            Movie objMovie = new Movie();
            objMovie.movie_number = txtMovieNumber.Text.Trim();
            objMovie.movie_title = txtMovieTitle.Text.Trim();
            objMovie.description = txtDescription.Text.Trim();
            objMovie.movie_year_made = txtMovieYearMade.Text.Trim();
            //Genre genre = GenreDB.GetGenreByName(cbGenre.SelectedItem.ToString()); objMovie.genre_id = genre.ID;
            objMovie.genre_id = ((Genre)cbGenre.SelectedItem).ID.ToString();//MessageBox.Show(cbGenre.SelectedIndex.ToString());
            objMovie.movie_rating = cbRating.Text.Trim();
            objMovie.media_type = cbMediaType.Text.Trim();
            objMovie.movie_retail_cost = Math.Round(Convert.ToDecimal(txtRetailCost.Text.Trim()),2);
            objMovie.copies_on_hand = txtCopiesOnHand.Text.Trim();
            objMovie.image = txtImageFilename.Text.Trim();
            objMovie.trailer = txtTrailerLink.Text.Trim();
            try
            {
                bool status = MovieDB.UpdateMovie(objMovie);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Movie has been updated.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Movie was not updated in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Validate the UI
            if (string.IsNullOrEmpty(txtMovieNumber.Text.Trim()))
            {
                MessageBox.Show("Please enter a movie id.");
                txtMovieNumber.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtMovieTitle.Text.Trim()))
            {
                MessageBox.Show("Please enter a movie name.");
                txtMovieNumber.Focus();
                return;
            }

            Movie objMovie = new Movie();
            objMovie.movie_number = txtMovieNumber.Text.Trim();
            objMovie.movie_title = txtMovieTitle.Text.Trim();
            objMovie.description = txtDescription.Text.Trim();
            objMovie.movie_year_made = txtMovieYearMade.Text.Trim();
            objMovie.genre_id =  ((Genre)cbGenre.SelectedItem).ID.ToString();
            objMovie.movie_rating = cbRating.Text.Trim();
            objMovie.media_type = cbMediaType.Text.Trim();
            objMovie.movie_retail_cost = Convert.ToDecimal(txtRetailCost.Text.Trim());
            objMovie.copies_on_hand = txtCopiesOnHand.Text.Trim();
            objMovie.image = txtImageFilename.Text.Trim();
            objMovie.trailer = txtTrailerLink.Text.Trim();
            try
            {
                bool status = MovieDB.DeleteMovie(objMovie);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Movie was deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Movie was not deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMovieNumber.ReadOnly = false;
            txtMovieNumber.Text = String.Empty;
            txtMovieTitle.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtMovieYearMade.Text = String.Empty;
            txtRetailCost.Text = String.Empty;
            txtCopiesOnHand.Text = String.Empty;
            txtImageFilename.Text = String.Empty;
            txtTrailerLink.Text = String.Empty;

            cbGenre.SelectedIndex = -1;
            cbMediaType.SelectedIndex = -1;
            cbRating.SelectedIndex = -1;

            dataGridView1.DataSource = null;
        }
    }
}
