using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Survey_App
{
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
        }

        private void Results_Load(object sender, EventArgs e)
        {
            string connstring = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand cmd = new SqlCommand("SurveyData", connection))
                connection.Open();

                int totalSurveys = GetTotalSurveys(connection);
                double averageAge = GetAverageAge(connection);
                string oldestPerson = GetOldestPerson(connection);
                string youngestPerson = GetYoungestPerson(connection);
                double pizzaPercentage = GetPercentage(connection, "Pizza");
                double pastaPercentage = GetPercentage(connection, "Pasta");
                double papWorsPercentage = GetPercentage(connection, "Pap_Wors");
                double chickenStirFryPercentage = GetPercentage(connection, "Chicken_stir_fry");
                double beefStirFryPercentage = GetPercentage(connection, "Beef_stir_fry");
                double otherPercentage = GetPercentage(connection, "Other");
                double eatOutRating = GetAverageRating(connection, "I_like_to_eat_out");
                double watchMoviesRating = GetAverageRating(connection, "I_like_to_watch_movies");
                double watchTVRating = GetAverageRating(connection, "I_like_to_watch_TV");
                double listenRadioRating = GetAverageRating(connection, "I_like_to_listen_to_the_radio");

                lblTotalSurveys.Text = totalSurveys.ToString();
                lblAverageAge.Text = averageAge.ToString();
                lblOldestPerson.Text = oldestPerson;
                lblYoungestPerson.Text = youngestPerson;
                lblPizzaPercentage.Text = pizzaPercentage.ToString("0.0") + "%";
                lblPastaPercentage.Text = pastaPercentage.ToString("0.0") + "%";
                lblPapWorsPercentage.Text = papWorsPercentage.ToString("0.0") + "%";
                lblChickenStirFryPercentage.Text = chickenStirFryPercentage.ToString("0.0") + "%";
                lblBeefStirFryPercentage.Text = beefStirFryPercentage.ToString("0.0") + "%";
                label0.Text = otherPercentage.ToString("0.0") + "%";
                lblEatOutRating.Text = eatOutRating.ToString("0.0");
                lblWatchMoviesRating.Text = watchMoviesRating.ToString("0.0");
                lblWatchTVRating.Text = watchTVRating.ToString("0.0");
                lblListenRadioRating.Text = listenRadioRating.ToString("0.0");
            }
        }

        private int GetTotalSurveys(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Details", connection))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private double GetAverageAge(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT AVG(Age) FROM Details", connection))
            {
                return Convert.ToDouble(command.ExecuteScalar());
            }
        }

        private string GetOldestPerson(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 ST_Name + ' ' + Surname FROM Details ORDER BY Age DESC", connection))
            {
                return command.ExecuteScalar().ToString();
            }
        }

        private string GetYoungestPerson(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 ST_Name + ' ' + Surname FROM Details ORDER BY Age ASC", connection))
            {
                return command.ExecuteScalar().ToString();
            }
        }

        private double GetPercentage(SqlConnection connection, string columnName)
        {
            using (SqlCommand command = new SqlCommand($"SELECT (COUNT(CASE WHEN {columnName} = 1 THEN 1 END) * 100.0 / COUNT(*)) FROM Details", connection))
            {
                return Convert.ToDouble(command.ExecuteScalar());
            }
        }

        private double GetAverageRating(SqlConnection connection, string columnName)
        {
            using (SqlCommand command = new SqlCommand($"SELECT AVG(CONVERT(FLOAT, {columnName})) FROM Details", connection))
            {
                object result = command.ExecuteScalar();
                return result == DBNull.Value ? 0.0 : Convert.ToDouble(result);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.Hide();
            mainMenu.Show();

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}

