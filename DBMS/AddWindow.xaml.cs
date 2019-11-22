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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private string text;
        public AddWindow()
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
                    OwnerDropAdd.Items.Add(dr.GetString(0));
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



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;

            if(TitleAdd.Text != "" && EnterYear.Text != "" && OwnerDropAdd.Text != "" && GenreDropAdd.Text != "" && RatedDropAdd.Text != "" && OwnRateDropAdd.Text != "" && TomatoeAdd.Text != "")
            { 
            MySqlConnection connect = new MySqlConnection("SERVER=localhost; user id=root; password=root; database=movies");
            MySqlCommand cmd = new MySqlCommand("select max(id) from moviedata;");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connect;
            connect.Open();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = dr.GetInt32(0) + 1;
            }
            if (connect.State == ConnectionState.Open)
            {
                connect.Close();
            }

            String beginQuery = $"INSERT INTO `moviedata` (`title`, `year`, `owner`, `genre`, `mpaar`, `ownerr`, `rottot`, `id`) VALUES ('{TitleAdd.Text}', '{EnterYear.Text}', '{OwnerDropAdd.Text}', '{GenreDropAdd.Text}', '{RatedDropAdd.Text}', '{OwnRateDropAdd.Text}', '{TomatoeAdd.Text}', '{id}');";
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

            text = TitleAdd.Text;
            MainWindow mWin = new MainWindow();
            mWin.Show();
            Close();
            }
            else
            {
                MessageBox.Show("Please enter all fields...");
            }
        }
    }
}
