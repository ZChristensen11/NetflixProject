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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                Member member = new Member();
                member.joindate = DateTime.Now.ToString();
                member.firstname = txtFName.Text;
                member.lastname = txtLName.Text;
                member.address = txtAddress.Text;
                member.city = txtCity.Text;
                member.state = txtState.Text;
                member.zipcode = txtZipcode.Text;
                member.phone = maskedTextBox1.Text;
                member.member_status = "A";
                member.login_name = txtUsername.Text;
                member.password = txtPass.Text;
                member.email = txtEmail.Text;
                member.contact_method = "1";
                member.subscription_id = "1";
                member.photo = "";

                MemberDB.AddMember(member);

                MessageBox.Show("Welcome to Meramec OnLine Movie Kiosk " + member.login_name);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
