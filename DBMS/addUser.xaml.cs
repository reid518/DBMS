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
    /// <summary>
    /// Interaction logic for addUser.xaml
    /// </summary>
    public partial class addUser : Window
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String beginQuery = $"INSERT INTO `users` (`owner`) VALUES ('{oname.Text}');";
            MySqlConnection connect2 = new MySqlConnection("SERVER=localhost; user id=root; password=root; database=movies");
            MySqlCommand cmd2 = new MySqlCommand(beginQuery);
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = connect2;
            connect2.Open();
            cmd2.ExecuteNonQuery();

            if (connect2.State == ConnectionState.Open)
            {
                connect2.Close();
            }
            MainWindow mWin = new MainWindow();
            mWin.Show();
            Close();
        }
    }
}
