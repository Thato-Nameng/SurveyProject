using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Survey_App
{
    public partial class UserSurvey : Form
    {
        public UserSurvey()
        {
            InitializeComponent();
        }

        private void UserSurvey_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblExit1.Hide();
            lblExit2.Hide();
            lblExit3.Hide();
            lblExit4.Hide();
            lblExit5.Hide();
            rad1.Hide();
            rad2.Hide();
            rad3.Hide();
            rad4.Hide();
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!decimal.TryParse((sender as TextBox).Text + e.KeyChar, out decimal number))
            {
                if (e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!decimal.TryParse((sender as TextBox).Text + e.KeyChar, out decimal number))
            {
                if (e.KeyChar != '\b') // Check if the key is not the Backspace key
                {
                    e.Handled = true;
                }
            }
        }

        private void btnFOS_Click(object sender, EventArgs e)
        {

            TextBox();
            CheckBox();
            RadioEat();
            radMovies();
            radWatchTv();
            radListen();
            

        }
    
        

        private void TextBox()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string Name, Surname, Number, Age;
            int age;
            Name = txtName.Text;
            Surname = txtSurname.Text;
            Number = txtNum.Text;
            Age = txtAge.Text;

            if (Name.Length <= 3 && Surname.Length <= 3 && Number.Length < 10 && !int.TryParse(Age, out age) && string.IsNullOrEmpty(Age) && (age <= 3 | age >= 120))
            {
                lblExit1.Show();
                lblExit2.Show();
                lblExit3.Show();
                lblExit5.Show();
                return;

            }
            else if (Name.Length > 3 && Surname.Length > 3 && Number.Length == 10 && int.TryParse(Age, out age) && (age > 3 && age < 120)
                
                &&(cbxPizza.Checked || cbxPasta.Checked || cbxPW.Checked || cbxCSF.Checked ||
                 cbxBSF.Checked || cbxOther.Checked))
            {
                lblExit1.Hide();
                lblExit2.Hide();
                lblExit3.Hide();
                lblExit5.Hide();

                string connstring = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                using (SqlConnection sqlcon = new SqlConnection(connstring))
                {
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand("SurveyData", sqlcon))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ST_Name", Name.ToString());
                        cmd.Parameters.AddWithValue("@Surname", Surname.ToString());
                        cmd.Parameters.AddWithValue("@Contact_Number", Number.ToString());
                        cmd.Parameters.AddWithValue("@T_Date", txtDate.Text.ToString());
                        cmd.Parameters.AddWithValue("@Age", age.ToString());

                        cmd.Parameters.AddWithValue("@Pizza", cbxPizza.Checked);
                        cmd.Parameters.AddWithValue("@Pasta", cbxPasta.Checked);
                        cmd.Parameters.AddWithValue("@Pap_Wors", cbxPW.Checked);
                        cmd.Parameters.AddWithValue("@Chicken_stir_fry", cbxCSF.Checked);
                        cmd.Parameters.AddWithValue("@Beef_stir_fry", cbxBSF.Checked);
                        cmd.Parameters.AddWithValue("@Other", cbxOther.Checked);

                        cmd.Parameters.AddWithValue("@I_like_to_eat_out", RadioEat());
                        cmd.Parameters.AddWithValue("@I_like_to_watch_movies", radMovies());
                        cmd.Parameters.AddWithValue("@I_like_to_watch_TV", radWatchTv());
                        cmd.Parameters.AddWithValue("@I_like_to_listen_to_the_radio", radListen());



                        int i = cmd.ExecuteNonQuery();
                        sqlcon.Close();
                        if (i > 0)
                        {
                            MessageBox.Show("Data insereted successfully");
                        }
                    }
                }
            }
            else if (Name.Length > 3 && Surname.Length <= 3 && Number.Length < 10 && !int.TryParse(Age, out age) && string.IsNullOrEmpty(Age) && (age <= 3 | age >= 120))
            {
                lblExit1.Hide();
                lblExit2.Show();
                lblExit3.Show();
                lblExit5.Show();
                return;

            }
            else if (Name.Length > 3 && Surname.Length > 3 && Number.Length < 10 && !int.TryParse(Age, out age) && string.IsNullOrEmpty(Age) && (age <= 3 | age >= 120))
            {
                lblExit1.Hide();
                lblExit2.Hide();
                lblExit3.Show();
                lblExit5.Show();
                return;
            }
            else if (Name.Length > 3 && Surname.Length > 3 && Number.Length == 10 && !int.TryParse(Age, out age) && string.IsNullOrEmpty(Age) && (age <= 3 | age >= 120))
            {
                lblExit1.Hide();
                lblExit2.Hide();
                lblExit3.Hide();
                lblExit5.Show();
                return;
            }

            else if (Name.Length > 3 && Surname.Length > 3 && Number.Length < 10 && int.TryParse(Age, out age) && (age > 3 && age < 120))
            {
                lblExit1.Hide();
                lblExit2.Hide();
                lblExit3.Show();
                lblExit5.Hide();
                return;
            }
            else if (Name.Length > 3 && Surname.Length <= 3 && Number.Length < 10 && int.TryParse(Age, out age) && (age > 3 && age < 120))
            {
                lblExit1.Hide();
                lblExit2.Show();
                lblExit3.Show();
                lblExit5.Hide();
                return;
            }
            else if (Name.Length <= 3 && Surname.Length <= 3 && Number.Length < 10 && int.TryParse(Age, out age) && (age > 3 && age < 120))
            {
                lblExit1.Show();
                lblExit2.Show();
                lblExit3.Show();
                lblExit5.Hide();
                return;
            }
            else if (Name.Length <= 3 && Surname.Length > 3 && Number.Length < 10 && int.TryParse(Age, out age) && (age > 3 | age < 120))
            {
                lblExit1.Show();
                lblExit2.Hide();
                lblExit3.Show();
                lblExit5.Show();
                return;
            }
            else if (Name.Length <= 3 && Surname.Length > 3 && Number.Length == 10 && int.TryParse(Age, out age) && (age > 3 | age < 120))
            {
                lblExit1.Show();
                lblExit2.Show();
                lblExit3.Hide();
                lblExit5.Show();
                return;
            }
            if (Name.Length <= 3 && Surname.Length > 3 && Number.Length == 10 && !int.TryParse(Age, out age) && string.IsNullOrEmpty(Age) && (age <= 3 | age >= 120))
            {
                lblExit1.Show();
                lblExit2.Hide();
                lblExit3.Hide();
                lblExit5.Show();
                return;

            }
        }

        private void CheckBox()
        {
            if (cbxPizza.Checked || cbxPasta.Checked || cbxPW.Checked || cbxCSF.Checked ||
                 cbxBSF.Checked || cbxOther.Checked)
            {
                lblExit4.Hide();
            }
            else
            {
                lblExit4.Show();
                return;
            }
        }

        private int RadioEat()
        {
            try
            {
                if (radEat1.Checked)
                {
                    rad1.Hide();
                    return 1;
                }
                else if (radEat2.Checked)
                {
                    rad1.Hide();
                    return 2;
                }
                if (radEat3.Checked)
                {
                    rad1.Hide();

                    return 3;
                }
                else if (radEat4.Checked)
                {
                    rad1.Hide();

                    return 4;
                }
                else if (radEat5.Checked)
                {
                    rad1.Hide();
                    return 5;
                }
                else
                {
                    return 0;
                }
            }
            catch (DivideByZeroException ex)
            {
                rad1.Show();
                return 0;
            }
            catch (Exception ex)
            {
                rad1.Show();
                return 0;
            }
        }
        private int radMovies()
        {
            try
            {
                if (radWM1.Checked)
                {
                    rad2.Hide();
                    return 1;
                }
                else if (radWM2.Checked)
                {
                    rad2.Hide();
                    return 2;
                }
                else if (radWM3.Checked)
                {
                    rad2.Hide();
                    return 3;
                }
                else if (radWM4.Checked)
                {
                    rad2.Hide();
                    return 4;
                }
                else if (radWM5.Checked)
                {
                    rad2.Hide();
                    return 5;
                }
                else
                {
                    return 0;
                }
            }
            catch (DivideByZeroException ex)
            {
                rad2.Show();
                return 0;
            }
            catch (Exception ex)
            {
                rad2.Show();
                return 0;
            }
        }

        private int radWatchTv()
        {
            try
            {
                if (radWTV1.Checked)
                {
                    rad3.Hide();
                    return 1;
                }
                else if (radWTV2.Checked)
                {
                    rad3.Hide();
                    return 2;
                }
                else if (radWTV3.Checked)
                {
                    rad3.Hide();
                    return 3;
                }
                else if (radWTV4.Checked)
                {
                    rad3.Hide();
                    return 4;
                }
                else if (radWTV5.Checked)
                {
                    rad3.Hide();
                    return 5;
                }
                else
                {
                    return 0;
                }
            }
            catch (DivideByZeroException ex)
            {
                rad3.Show();
                return 0;
            }
            catch (Exception ex)
            {
                rad3.Show();
                return 0;
            }

        }
        private int radListen()
        {
            try
            {
                if (radWTV1.Checked)
                {
                    rad4.Hide();
                    return 1;
                }
                else if (radWTV2.Checked)
                {
                    rad4.Hide();
                    return 2;
                }
                else if (radWTV3.Checked)
                {
                    rad4.Hide();
                    return 3;
                }
                else if (radWTV4.Checked)
                {
                    rad4.Hide();
                    return 4;
                }
                else if (radWTV5.Checked)
                {
                    rad4.Hide();
                    return 5;
                }
                else
                {
                    return 0;
                }
            }
            catch (DivideByZeroException ex)
            {
                rad4.Show();
                return 0;
            }
            catch (Exception ex)
            {
                rad4.Show();
                return 0;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.Hide();
            mainMenu.Show();

        }
    }
}