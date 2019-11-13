using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string beginQuery;
        private string query;
        private int queryIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
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
                Output.Items.Add("Searching with filters...");

                if(OwnerDrop.SelectedIndex != 0)
                {
                    query += "owner = " + OwnerDrop.Text.ToLower();
                    queryIndex++;
                }
                Output.Items.Add(OwnerDrop.Text);

                if (GenreDrop.SelectedIndex != 0)
                {
                    if(queryIndex > 0)
                    {
                        query += " AND ";
                    }
                    query += "genre = " + GenreDrop.Text.ToLower();
                    queryIndex++;
                }
                Output.Items.Add(GenreDrop.Text);

                if (RatedDrop.SelectedIndex != 0)
                {
                    if (queryIndex > 0)
                    {
                        query += " AND ";
                    }
                    query += "mpaa = " + RatedDrop.Text.ToLower();
                    queryIndex++;
                }
                Output.Items.Add(RatedDrop.Text);

                if (OwnRateDrop.SelectedIndex != 0)
                {
                    if (queryIndex > 0)
                    {
                        query += " AND ";
                    }
                    query += "ownrate = " + OwnRateDrop.Text.ToLower();
                    queryIndex++;
                }
                Output.Items.Add(OwnRateDrop.Text);

                if (RottenToDrop.SelectedIndex != 0)
                {
                    if (queryIndex > 0)
                    {
                        query += " AND ";
                    }
                    query += "rottentomatoes = " + RottenToDrop.Text.ToLower();
                    queryIndex++;
                }
                Output.Items.Add(RottenToDrop.Text);
            }
            else if (SearchMode.IsChecked == true)
            {
                OwnerDrop.SelectedIndex = 0;
                GenreDrop.SelectedIndex = 0;
                RatedDrop.SelectedIndex = 0;
                OwnRateDrop.SelectedIndex = 0;
                RottenToDrop.SelectedIndex = 0;
                Output.Items.Add("Searching for " + TitleSearch.Text);
                query = "title = " + TitleSearch.Text.ToLower();
                queryIndex++;
                //straight to SQL stuff

            }
            if(queryIndex == 0)
            {
                beginQuery = "SELECT * FROM table;";
            }
            else
            {
                beginQuery = "SELECT * FROM table WHERE " + query + ";";
            }
            Output.Items.Add(beginQuery);
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow winAdd = new AddWindow();
            winAdd.Show();
            this.Close();
        }

        private void TitleSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchMode.IsChecked = true;
        }
    }
}
