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

            if (ListMode.IsChecked == true)
            {
                TitleSearch.Clear();
                Output.Items.Add("Searching with filters...");
                //case statements galore
                switch (OwnerDrop.SelectedIndex)
                {
                    case 1:
                        Output.Items.Add("Mike");
                        break;
                    case 2:
                        Output.Items.Add("Nathan");
                        break;
                    case 3:
                        Output.Items.Add("Reid");
                        break;
                    default:
                        Output.Items.Add("All Owners");
                        break;
                }

                switch (GenreDrop.SelectedIndex)
                {
                    case 1:
                        Output.Items.Add("Action");
                        break;
                    case 2:
                        Output.Items.Add("Comedy");
                        break;
                    case 3:
                        Output.Items.Add("Drama");
                        break;
                    case 4:
                        Output.Items.Add("Rom-Com");
                        break;
                    case 5:
                        Output.Items.Add("Sci-Fi");
                        break;
                    case 6:
                        Output.Items.Add("Horror");
                        break;
                    case 7:
                        Output.Items.Add("Thriller");
                        break;
                    case 8:
                        Output.Items.Add("Western");
                        break;
                    case 9:
                        Output.Items.Add("Animated");
                        break;
                    default:
                        Output.Items.Add("All Genres");
                        break;
                }

                switch (RatedDrop.SelectedIndex)
                {
                    case 1:
                        Output.Items.Add("NR");
                        break;
                    case 2:
                        Output.Items.Add("NC-17");
                        break;
                    case 3:
                        Output.Items.Add("R");
                        break;
                    case 4:
                        Output.Items.Add("PG-13");
                        break;
                    case 5:
                        Output.Items.Add("PG");
                        break;
                    case 6:
                        Output.Items.Add("G");
                        break;
                    default:
                        Output.Items.Add("All Ratings");
                        break;
                }

                switch (OwnRateDrop.SelectedIndex)
                {
                    case 1:
                        Output.Items.Add("5");
                        break;
                    case 2:
                        Output.Items.Add("4");
                        break;
                    case 3:
                        Output.Items.Add("3");
                        break;
                    case 4:
                        Output.Items.Add("2");
                        break;
                    case 5:
                        Output.Items.Add("1");
                        break;
                    default:
                        Output.Items.Add("All Owner Ratings");
                        break;
                }

        switch (RottenToDrop.SelectedIndex)
                {
                    case 1:
                        Output.Items.Add("100-90");
                        break;
                    case 2:
                        Output.Items.Add("89-80");
                        break;
                    case 3:
                        Output.Items.Add("79-70");
                        break;
                    case 4:
                        Output.Items.Add("69-60");
                        break;
                    case 5:
                        Output.Items.Add("59-50");
                        break;
                    case 6:
                        Output.Items.Add("49-40");
                        break;
                    case 7:
                        Output.Items.Add("39-30");
                        break;
                    case 8:
                        Output.Items.Add("29-20");
                        break;
                    case 9:
                        Output.Items.Add("19-10");
                        break;
                    case 10:
                        Output.Items.Add("9-0");
                        break;
                    default:
                        Output.Items.Add("All Tomatoe Ratings");
                        break;
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow winAdd = new AddWindow();
            winAdd.Show();
            this.Close();
        }
    }
}
