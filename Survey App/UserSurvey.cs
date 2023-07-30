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
                if (e.KeyChar != '\b') 
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

            if (Name.Length <= 3 && Surname.Length <= 3 && Number.Length < 10 && !int.TryParse(Age, out age) && 
                string.IsNullOrEmpty(Age) && (age <= 3 | age >= 120))
            {
                lblExit1.Show();
                lblExit2.Show();
                lblExit3.Show();
                lblExit5.Show();
                return;

            }
            else if (Name.Length > 3 && Surname.Length > 3 && Number.Length == 10 && 
                int.TryParse(Age, out age) && (age > 3 && age < 120)  &&
                (cbxPizza.Checked || cbxPasta.Checked || cbxPW.Checked || cbxCSF.Checked ||
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


                        int eat = RadioEat();
                        int movies = radMovies();
                        int watchTv = radWatchTv();
                        int listen = radListen();

                        if (eat >= 1 && eat <= 5 && movies >= 1 && movies <= 5 &&
                            watchTv >= 1 && watchTv <= 5 && listen >= 1 && listen <= 5)
                        {
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
            }
            else if (Name.Length > 3 && Surname.Length <= 3 && Number.Length < 10 && 
                !int.TryParse(Age, out age) && string.IsNullOrEmpty(Age) && (age <= 3 | age >= 120))
            {
                lblExit1.Hide();
                lblExit2.Show();
                lblExit3.Show();
                lblExit5.Show();
                return;

            }
            else if (Name.Length > 3 && Surname.Length > 3 && Number.Length < 10 && 
                !int.TryParse(Age, out age) && string.IsNullOrEmpty(Age) && (age <= 3 | age >= 120))
            {
                lblExit1.Hide();
                lblExit2.Hide();
                lblExit3.Show();
                lblExit5.Show();
                return;
            }
            else if (Name.Length > 3 && Surname.Length > 3 && Number.Length == 10 && 
                !int.TryParse(Age, out age) && string.IsNullOrEmpty(Age) && (age <= 3 | age >= 120))
            {
                lblExit1.Hide();
                lblExit2.Hide();
                lblExit3.Hide();
                lblExit5.Show();
                return;
            }

            else if (Name.Length > 3 && Surname.Length > 3 && Number.Length < 10 && 
                int.TryParse(Age, out age) && (age > 3 && age < 120))
            {
                lblExit1.Hide();
                lblExit2.Hide();
                lblExit3.Show();
                lblExit5.Hide();
                return;
            }
            else if (Name.Length > 3 && Surname.Length <= 3 && Number.Length < 10 && 
                int.TryParse(Age, out age) && (age > 3 && age < 120))
            {
                lblExit1.Hide();
                lblExit2.Show();
                lblExit3.Show();
                lblExit5.Hide();
                return;
            }
            else if (Name.Length <= 3 && Surname.Length <= 3 && Number.Length < 10 && 
                int.TryParse(Age, out age) && (age > 3 && age < 120))
            {
                lblExit1.Show();
                lblExit2.Show();
                lblExit3.Show();
                lblExit5.Hide();
                return;
            }
            else if (Name.Length <= 3 && Surname.Length > 3 && Number.Length < 10 && 
                int.TryParse(Age, out age) && (age > 3 | age < 120))
            {
                lblExit1.Show();
                lblExit2.Hide();
                lblExit3.Show();
                lblExit5.Show();
                return;
            }
            else if (Name.Length <= 3 && Surname.Length > 3 && Number.Length == 10 && 
                int.TryParse(Age, out age) && (age > 3 | age < 120))
            {
                lblExit1.Show();
                lblExit2.Show();
                lblExit3.Hide();
                lblExit5.Show();
                return;
            }
            if (Name.Length <= 3 && Surname.Length > 3 && Number.Length == 10 && 
                !int.TryParse(Age, out age) && string.IsNullOrEmpty(Age) && (age <= 3 | age >= 120))
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
            radEat1.Tag = 1;
            radEat2.Tag = 2;
            radEat3.Tag = 3;
            radEat4.Tag = 4;
            radEat5.Tag = 5;

            RadioButton[] radioButtons = { radEat1, radEat2, radEat3, radEat4, radEat5 };

            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    rad1.Hide();
                    return int.Parse(radioButton.Tag.ToString());
                }
            }
            rad1.Show();
            return 0;
        }
        private int radMovies()
        {
            radWM1.Tag = 1;
            radWM2.Tag = 2;
            radWM3.Tag = 3;
            radWM4.Tag = 4;
            radWM5.Tag = 5;

            RadioButton[] radioButtons = { radWM1, radWM2, radWM3, radWM4, radWM5 };

            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    rad2.Hide();
                    return int.Parse(radioButton.Tag.ToString());
                }
            }
            rad2.Show();
            return 0;
        }

        private int radWatchTv()
        {
            radWTV1.Tag = 1;
            radWTV2.Tag = 2;
            radWTV3.Tag = 3;
            radWTV4.Tag = 4;
            radWTV5.Tag = 5;

            RadioButton[] radioButtons = { radWTV1, radWTV2, radWTV3, radWTV4, radWTV5 };

            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    rad3.Hide(); 
                    return int.Parse(radioButton.Tag.ToString()); 
                }
            }
            rad3.Show(); 
            return 0;

            }
        private int radListen()
        {
            radLR1.Tag = 1;
            radLR2.Tag = 2;
            radLR3.Tag = 3;
            radLR4.Tag = 4;
            radLR5.Tag = 5;

            RadioButton[] radioButtons = { radLR1, radLR2, radLR3, radLR4, radLR5 };

            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    rad4.Hide();
                    return int.Parse(radioButton.Tag.ToString());
                }
            }
            rad4.Show();
            return 0;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.Hide();
            mainMenu.Show();

        }

        public void clear()
        {
            txtName.Clear();
            txtSurname.Clear();
            txtNum.Clear();
            txtAge.Clear();
            cbxBSF.Checked = false;
            cbxCSF.Checked = false;
            cbxPasta.Checked = false;
            cbxPizza.Checked = false;
            cbxPW.Checked = false;
            cbxOther.Checked = false;

            radEat1.Checked = false;
            radEat2.Checked = false;
            radEat3.Checked = false;
            radEat4.Checked = false;
            radEat5.Checked = false;

            radLR1.Checked = false;
            radLR2.Checked = false;
            radLR3.Checked = false;
            radLR4.Checked = false;
            radLR5.Checked = false;

            radWM1.Checked = false;
            radWM2.Checked = false;
            radWM3.Checked = false;
            radWM4.Checked = false;
            radWM5.Checked = false;

            radWTV1.Checked = false;
            radWTV2.Checked = false;
            radWTV3.Checked = false;
            radWTV4.Checked = false;
            radWTV5.Checked = false;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}