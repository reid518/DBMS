using Mono.CSharp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBMS
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Process_Click(object sender, RoutedEventArgs e)
        {
            Output.Items.Clear();

            if (ListMode.IsChecked == true)
            {
                TitleSearch.Clear();
                //Put code here to query
                MySqlConnection connect = new MySqlConnection("SERVER=localhost; user id=root; password=root; database=northwind");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM orders");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connect;
                connect.Open();
                try
                {
                    MySqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        this.Output.Items.Add(new MyItem { Title = dr.GetString(0), Year = dr.GetString(1), Owner = dr.GetString(2), Genre = dr.GetString(3), MPAA_Rating = dr.GetString(4), Owner_Rating = dr.GetString(6), RT = dr.GetString(7) });
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }

                }



            }
            else if (SearchMode.IsChecked == true)
            {
                OwnerDrop.SelectedIndex = 0;
                GenreDrop.SelectedIndex = 0;
                RatedDrop.SelectedIndex = 0;
                OwnRateDrop.SelectedIndex = 0;
                RottenToDrop.SelectedIndex = 0;
                Output.Items.Add("Searching for " + TitleSearch.Text);
                //straight to SQL stuff
                
            }
        }

        private void Output_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchMode_Checked(object sender, RoutedEventArgs e)
        {
            OwnerDrop.SelectedIndex = 0;
            GenreDrop.SelectedIndex = 0;
            RatedDrop.SelectedIndex = 0;
            OwnRateDrop.SelectedIndex = 0;
            RottenToDrop.SelectedIndex = 0;

        }

        private void ListMode_Checked(object sender, RoutedEventArgs e)
        {
            TitleSearch.Clear();
        }

        private void Output_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    internal class MyItem
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Owner { get; set; }
        public string Genre { get; set; }
        public string MPAA_Rating { get; set; }
        public string Owner_Rating { get; set; }
        public string RT { get; set; }
    }
}
