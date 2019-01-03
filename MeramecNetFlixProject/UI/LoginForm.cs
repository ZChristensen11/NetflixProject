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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            txtLogin.Text = "buddy";
            txtPassword.Text = "password";

            txtLogin.Focus();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                lblUsernameError.Text = "";

                Member member = MemberDB.GetMember(txtLogin.Text);
                if (txtPassword.Text == member.password)
                {
                    new Thread(() => new RentalForm(member).ShowDialog()).Start();
                    this.Close();
                }
                else
                {
                    lblError.Text = "* incorrect password";
                }


            }
            catch (Exception ex)
            {
                lblUsernameError.Text = "* invalid username";
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp newSignUp = new SignUp();
            Thread suThd = new Thread(() => newSignUp.ShowDialog());
            suThd.Start();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void LoginForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
