using System;
using System.IO;
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
    public partial class MemberDataEntry : Form
    {
        public MemberDataEntry()
        {
            InitializeComponent();

            PopulateCBSub();

        }

        private void PopulateCBSub()
        {
            List<Subscription> subs = new List<Subscription>();

            subs = SubscriptionDB.GetSubscriptions();


            cbSubscription.DisplayMember = "Name";
            cbSubscription.ValueMember = "ID";
            cbSubscription.DataSource = subs;

        }

        private RadioButton GetRadioButtonSelected(GroupBox gb)
        {
            foreach (var control in gb.Controls)
            {
                RadioButton rb = control as RadioButton;
                if (rb != null && rb.Checked)
                {
                    return rb;
                }
            }
            return null;
        }

        private void SavePhoto()
        {
            if (!Directory.Exists(photoDir + "\\MemberPhotos"))
            {
                Directory.CreateDirectory(photoDir + "\\MemberPhotos");
                string path = photoDir + "\\MemberPhotos\\" + Path.GetFileName(pictureBoxPhoto.ImageLocation);
                if (!File.Exists(path))
                    pictureBoxPhoto.Image.Save(path);
            }
            else
            {
                string path = photoDir + "\\MemberPhotos\\" + Path.GetFileName(pictureBoxPhoto.ImageLocation);
                if (!File.Exists(path))
                    pictureBoxPhoto.Image.Save(path);
            }
        }
       

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Call the MemberDB static class to fill the data grid
            try
            {
                List<Member> memberList = new List<Member>();
                memberList = MemberDB.GetMembers();
                dataGridView1.DataSource = memberList;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Validate the UI
            //if (string.IsNullOrEmpty(txtNumberber.Text.Trim()))
            //{
            //    MessageBox.Show("Please enter a member id.");
            //    txtNumberber.Focus();
            //    return;
            //}

            if (string.IsNullOrEmpty(txtJoinDate.Text.Trim()))
            {
                MessageBox.Show("Please enter a member name.");
                txtJoinDate.Focus();
                return;
            }

            Member objMember = new Member();
            //objMember.number = txtNumber.Text.Trim();
            objMember.joindate = txtJoinDate.Text.Trim();
            objMember.firstname = txtFirstname.Text.Trim();
            objMember.lastname = txtLastname.Text.Trim();
            objMember.address = txtAddress.Text.Trim();
            objMember.city = txtCity.Text.Trim();
            objMember.state = txtState.Text.Trim();
            objMember.zipcode = txtZipcode.Text.Trim();
            objMember.phone = txtPhone.Text.Trim();
            objMember.member_status = GetRadioButtonSelected(gbMemberStatus).Tag.ToString();
            objMember.login_name = txtLoginName.Text.Trim();
            objMember.password = txtPassword.Text.Trim();
            objMember.email = txtEmailAddress.Text.Trim();
            objMember.contact_method = GetRadioButtonSelected(gbContactMethod).Tag.ToString();
            objMember.subscription_id = ((Subscription)cbSubscription.SelectedItem).ID.ToString();
            objMember.photo = Path.GetFileName(pictureBoxPhoto.ImageLocation);
            try
            {
                bool status = MemberDB.AddMember(objMember);
                SavePhoto();
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Member added to the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Member was not added to database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        string photoDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Photos";
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate the UI
                if (string.IsNullOrEmpty(txtLoginName.Text.Trim()))
                {
                    MessageBox.Show("Search by Login Name", "Uh oh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLoginName.Focus();
                    return;
                }

                //Member objMember = MemberDB.GetMember(Convert.ToInt32(txtNumberber.Text.Trim()));
                Member objMember = MemberDB.GetMember(txtLoginName.Text);
                //Step 2: Validate to make sure the Customer object is not null.
                if (objMember != null)
                {
                    //Populate the UI with the object values
                    txtNumber.Text = objMember.number;
                    txtJoinDate.Text = objMember.joindate;
                    txtJoinDate.Text = objMember.joindate;
                    txtFirstname.Text = objMember.firstname;
                    txtLastname.Text = objMember.lastname;
                    txtAddress.Text = objMember.address;
                    txtCity.Text = objMember.city;
                    txtState.Text = objMember.state;
                    txtZipcode.Text = objMember.zipcode;
                    txtPhone.Text = objMember.phone;
                    if (objMember.member_status == "A")
                        rbActive.Select();
                    else if (objMember.member_status == "I")
                        rbInactive.Select();
                    txtLoginName.Text = objMember.login_name;
                    txtPassword.Text = objMember.password;
                    txtEmailAddress.Text = objMember.email;

                    int counter = 4;
                    foreach (var control in gbContactMethod.Controls)
                    {
                        RadioButton rb = control as RadioButton;
                        if (counter == Convert.ToInt32(objMember.contact_method))
                        {
                            rb.Select();
                        }
                        counter--;
                    }

                    
                    cbSubscription.SelectedIndex = Convert.ToInt32(objMember.subscription_id) - 1;

                    if (objMember.photo != "")
                    {
                        pictureBoxPhoto.ImageLocation = photoDir + "\\MemberPhotos\\" + objMember.photo;
                        pictureBoxPhoto.Load();
                    }

                }
                else
                {
                    MessageBox.Show("Member " + txtLoginName.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Validate the UI
            if (string.IsNullOrEmpty(txtJoinDate.Text.Trim()))
            {
                MessageBox.Show("Please enter a member name.");
                txtJoinDate.Focus();
                return;
            }

            Member objMember = new Member();
            objMember.number = txtNumber.Text.Trim();
            objMember.joindate = txtJoinDate.Text.Trim();
            objMember.firstname = txtFirstname.Text.Trim();
            objMember.lastname = txtLastname.Text.Trim();
            objMember.address = txtAddress.Text.Trim();
            objMember.city = txtCity.Text.Trim();
            objMember.state = txtState.Text.Trim();
            objMember.zipcode = txtZipcode.Text.Trim();
            objMember.phone = txtPhone.Text.Trim();
            objMember.member_status = GetRadioButtonSelected(gbMemberStatus).Tag.ToString();
            objMember.login_name = txtLoginName.Text.Trim();
            objMember.password = txtPassword.Text.Trim();
            objMember.email = txtEmailAddress.Text.Trim();
            objMember.contact_method = GetRadioButtonSelected(gbContactMethod).Tag.ToString();
            objMember.subscription_id = ((Subscription)cbSubscription.SelectedItem).ID.ToString();
            objMember.photo = Path.GetFileName(pictureBoxPhoto.ImageLocation);
            try
            {
                bool status = MemberDB.UpdateMember(objMember);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Member has been updated.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Member was not updated in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtJoinDate.Text.Trim()))
            {
                MessageBox.Show("Please enter a member name.");
                txtJoinDate.Focus();
                return;
            }

            Member objMember = MemberDB.GetMember(txtNumber.Text);

            try
            {
                bool status = MemberDB.DeleteMember(objMember);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Member was deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Member was not deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtNumber.Text = String.Empty;
            txtJoinDate.Text = String.Empty;
            txtFirstname.Text = String.Empty;
            txtLastname.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtState.Text = String.Empty;
            txtZipcode.Text = String.Empty;
            txtPhone.Text = String.Empty;
            foreach (var control in gbMemberStatus.Controls)
            {
                RadioButton rb = control as RadioButton;
                rb.Checked = false;
            }
            txtLoginName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtEmailAddress.Text = String.Empty;
            foreach (var control in gbContactMethod.Controls)
            {
                RadioButton rb = control as RadioButton;
                rb.Checked = false;
            }
            cbSubscription.SelectedIndex = -1;
            pictureBoxPhoto.Image = null;

            dataGridView1.DataSource = null;
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = photoDir  + "\\MemberPhotos\\";
                openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|";
                //openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.CheckPathExists)
                    {
                        string fileSelected = openFileDialog.FileName;
                        pictureBoxPhoto.ImageLocation = fileSelected;
                    }

                   
                }


            }
        }
    }
}
