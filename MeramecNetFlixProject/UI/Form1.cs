using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        LoginForm loginForm;
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            loginForm = new LoginForm();
            //loginForm.ShowDialog();
            loginForm.Show();
            //new Thread(() => new LoginForm().ShowDialog()).Start();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (loginForm == null) { }
            else
            {
                loginForm.Close();
                loginForm = null;
            }
        }
    }
}
