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
    public partial class GenreDataEntry : Form
    {
        public GenreDataEntry()
        {
            InitializeComponent();

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Call the GenreDB static class to fill the data grid
            try
            {
                List<Genre> genreList = new List<Genre>();
                genreList = GenreDB.GetGenres();
                dataGridView1.DataSource = genreList;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Validate the UI
            if (string.IsNullOrEmpty(txtGenreID.Text.Trim()))
            {
                MessageBox.Show("Please enter a genre id.");
                txtGenreID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtGenreName.Text.Trim()))
            {
                MessageBox.Show("Please enter a genre name.");
                txtGenreID.Focus();
                return;
            }

            Genre objGenre = new Genre();
            objGenre.ID = txtGenreID.Text.Trim();
            objGenre.Name = txtGenreName.Text.Trim();
            try
            {
                bool status = GenreDB.AddGenre(objGenre);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Genre added to the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Genre was not added to database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtGenreID.Text.Trim()))
            {
                MessageBox.Show("Please enter a genre id.");
                txtGenreID.Focus();
                return;
            }

            Genre objGenre = GenreDB.GetGenre(Convert.ToInt32(txtGenreID.Text.Trim()));
            //Step 2: Validate to make sure the Customer object is not null.
            if (objGenre != null)
            {
                //Populate the UI with the object values
                txtGenreName.Text = objGenre.Name;
                //make Genre ID field read-only to be used for updating and deleting records demo
                txtGenreID.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Genre ID " + txtGenreID.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Validate the UI
            if (string.IsNullOrEmpty(txtGenreID.Text.Trim()))
            {
                MessageBox.Show("Please enter a genre id.");
                txtGenreID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtGenreName.Text.Trim()))
            {
                MessageBox.Show("Please enter a genre name.");
                txtGenreID.Focus();
                return;
            }

            Genre objGenre = new Genre();
            objGenre.ID = txtGenreID.Text.Trim();
            objGenre.Name = txtGenreName.Text.Trim();
            try
            {
                bool status = GenreDB.UpdateGenre(objGenre);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Genre has been updated.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Genre was not updated in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtGenreID.Text.Trim()))
            {
                MessageBox.Show("Please enter a genre id.");
                txtGenreID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtGenreName.Text.Trim()))
            {
                MessageBox.Show("Please enter a genre name.");
                txtGenreID.Focus();
                return;
            }

            Genre objGenre = new Genre();
            objGenre.ID = txtGenreID.Text.Trim();
            objGenre.Name = txtGenreName.Text.Trim();
            try
            {
                bool status = GenreDB.DeleteGenre(objGenre);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Genre was deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Genre was not deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtGenreID.ReadOnly = false;
            txtGenreID.Text = String.Empty;
            txtGenreName.Text = String.Empty;
            dataGridView1.DataSource = null;
        }
    }
}
