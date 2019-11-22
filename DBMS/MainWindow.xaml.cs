using ICSharpCode.AvalonEdit.Search;
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
        private string beginQuery;
        private string query;
        private int queryIndex = 0;
        public MainWindow()
        {
            InitializeComponent();

            MySqlConnection connect = new MySqlConnection("SERVER=localhost; user id=root; password=root; database=movies");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connect;
            connect.Open();
            try
            {
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    OwnerDrop.Items.Add(dr.GetString(0));
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
        public MainWindow(string text) : this()
        {
            Output.Items.Add(text);
           
        }

        private void Process_Click(object sender, RoutedEventArgs e)
        {
            Output.Items.Clear();
            query = null;
            queryIndex = 0;

            if (ListMode.IsChecked == true)
            {

                TitleSearch.Clear();
               


                //Output.Items.Add("Searching with filters...");

                if (OwnerDrop.SelectedIndex != 0)
                {
                    query += "owner = '" + OwnerDrop.Text.ToLower() +"'";
                    queryIndex++;
                }
                //Output.Items.Add(OwnerDrop.Text);

                if (GenreDrop.SelectedIndex != 0)
                {
                    if (queryIndex > 0)
                    {
                        query += " AND ";
                    }
                    query += "genre = '" + GenreDrop.Text.ToLower() + "'";
                    queryIndex++;
                }
                //Output.Items.Add(GenreDrop.Text);

                if (RatedDrop.SelectedIndex != 0)
                {
                    if (queryIndex > 0)
                    {
                        query += " AND ";
                    }
                    query += "mpaa = '" + RatedDrop.Text.ToLower() + "'";
                    queryIndex++;
                }
                //Output.Items.Add(RatedDrop.Text);

                if (OwnRateDrop.SelectedIndex != 0)
                {
                    if (queryIndex > 0)
                    {
                        query += " AND ";
                    }
                    query += "ownrate = '" + OwnRateDrop.Text.ToLower() + "'";
                    queryIndex++;
                }
                // Output.Items.Add(OwnRateDrop.Text);

                if (RottenToDrop.SelectedIndex != 0)
                {
                    if (queryIndex > 0)
                    {
                        query += " AND ";
                    }
                    query += "rottentomatoes = '" + RottenToDrop.Text.ToLower() + "'";
                    queryIndex++;
                }
                //Output.Items.Add(RottenToDrop.Text);
            }
            else if (SearchMode.IsChecked == true)
            {
                OwnerDrop.SelectedIndex = 0;
                GenreDrop.SelectedIndex = 0;
                RatedDrop.SelectedIndex = 0;
                OwnRateDrop.SelectedIndex = 0;
                RottenToDrop.SelectedIndex = 0;
                //Output.Items.Add("Searching for " + TitleSearch.Text);
                query = "title = '" + TitleSearch.Text.ToLower() + "'";
                queryIndex++;
                //straight to SQL stuff

            }
            if (queryIndex == 0)
            {
                beginQuery = "SELECT * FROM moviedata;";
            }
            else
            {
                beginQuery = "SELECT * FROM moviedata WHERE " + query + ";";
             
            }

            //Put code here to query
            MySqlConnection connect = new MySqlConnection("SERVER=localhost; user id=root; password=root; database=movies");
            MySqlCommand cmd = new MySqlCommand(beginQuery);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connect;
            connect.Open();
            try
            {
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    this.Output.Items.Add(new MyItem { Title = dr.GetString(0), Year = dr.GetString(1), Owner = dr.GetString(2), Genre = dr.GetString(3), MPAA_Rating = dr.GetString(4), Owner_Rating = dr.GetString(5), RT = dr.GetString(6) });
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

            //Output.Items.Add(beginQuery);
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
            ListMode.IsChecked = true;
        }

        private void Output_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWindow winAdd = new AddWindow();
            winAdd.Show();
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            {
                if (Output.SelectedItems.Count <= 0)
                {
                    return;
                }
                MyItem delItem = (MyItem)Output.SelectedItems[0];
                String dT = delItem.Title;
                String dO = delItem.Owner;

                                //Put code here to query
                MySqlConnection connect = new MySqlConnection("SERVER=localhost; user id=root; password=root; database=movies");
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM moviedata WHERE title = '{delItem.Title}' AND owner = '{delItem.Owner}';");
                //MessageBox.Show($"DELETE FROM moviedata WHERE title = '{delItem.Title}' AND owner = '{delItem.Owner}';");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connect;
                connect.Open();
                cmd.ExecuteNonQuery();

                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }

                Output.Items.Remove(Output.SelectedItems[0]);
            }
        }

        private void TitleSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchMode.IsChecked = true;
        }

        private void OwnerDrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void addnewowner_Click(object sender, RoutedEventArgs e)
        {
            addUser winAdd = new addUser();
            winAdd.Show();
            Close();
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

        private void Close()
        {
            throw new NotImplementedException();
        }
    }
}
