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
    public partial class ViewMovie : Form
    {
        public ViewMovie()
        {
            try
            {
                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;

                movie = MovieDB.GetMovie(2);
                memberNum = "1";
                label1.Text = movie.movie_title;
                label2.Text = movie.description;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        Movie movie;
        string memberNum;
        public ViewMovie(Movie movie, string memberNum)
        {
            try
            {
                InitializeComponent();

                this.StartPosition = FormStartPosition.CenterParent;
                this.movie = movie;
                this.memberNum = memberNum;
                label1.Text = movie.movie_title;
                label2.Text = movie.description;
                textBox1.Text = movie.description;
                webControl.WebView.LoadUrl(movie.trailer);
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRent_Click(object sender, EventArgs e)
        {
            try
            {
                Rental rental = new Rental();
                rental.movie_number = movie.movie_number;
                rental.member_number = memberNum;
                rental.media_checkout_date = DateTime.Now.ToString();
                rental.media_return_date = null;

                RentalDB.AddRental(rental);
                MessageBox.Show("Success!");
            }
            catch (Exception)
            {

                MessageBox.Show("Error in rental process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewMovie_Deactivate(object sender, EventArgs e)
        {
            if (this.Visible && !this.CanFocus) { }
            else this.Close();
        }

        private void ViewMovie_Load(object sender, EventArgs e)
        {

           
        


           
        }
    }
}
