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

                //Put code here to query
                string connectionString = ("Data Source=dbms4430_project; Initial Catalog=testdata; User ID=dbms_admin; Password=testpass");

                using (SqlConnection _con = new SqlConnection(connectionString))
                {
                    string queryStatement = "SELECT TOP 5 * FROM dbo.Customers ORDER BY CustomerID";

                    using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                    {
                        System.Data.DataTable customerTable = new System.Data.DataTable("Top5Customers");

                        SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                        _con.Open();
                        _dap.Fill(customerTable);
                        _con.Close();

                    }
                }

            }
            else if (SearchMode.IsChecked == true)
            {
                OwnerDrop.SelectedIndex = 0;
                GenreDrop.SelectedIndex = 0;
                RatedDrop.SelectedIndex = 0;
                OwnRateDrop.SelectedIndex = 0;
                Output.Items.Add("Searching for " + TitleSearch.Text);
                //straight to SQL stuff
                
            }
        }

        private void Output_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
