using System;
using System.Collections.Generic;
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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WPF_ZooManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["WPF_ZooManager.Properties.Settings.PanjutorialsDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            ShowZoos();
            ShowAllAnimals();
        }

        private void ShowAllAnimals()
        {
            string query = "select * from Animal";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            using (sqlDataAdapter)
            {
                DataTable animalTable = new DataTable();
                sqlDataAdapter.Fill(animalTable);

                listAllAnimals.DisplayMemberPath = "Name";
                listAllAnimals.SelectedValuePath = "Id";
                listAllAnimals.ItemsSource = animalTable.DefaultView;
            }

        }

        private void ShowZoos()
        {
            string query = "select * from Zoo";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

            using (sqlDataAdapter)
            {
                DataTable zooTable = new DataTable();
                sqlDataAdapter.Fill(zooTable);

                listZoos.DisplayMemberPath = "Location";
                listZoos.SelectedValuePath = "Id";
                listZoos.ItemsSource = zooTable.DefaultView;
            }

        }

        private void ShowAssociatedAnimals()
        {
            
            try
            {
                string query = "select * from Animal a inner join ZooAnimal " +
                               "za on za.AnimalId = a.Id where za.ZooId = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);

                    listAssociatedAnimals.DisplayMemberPath = "Name";
                    listAssociatedAnimals.SelectedValuePath = "Id";
                    listAssociatedAnimals.ItemsSource = animalTable.DefaultView;
                }
            }

            catch (Exception e)
            {

            }

            

        }

        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowAssociatedAnimals();
            ShowSelectedZooInTextBox();
        }

        private void DeleteZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Zoo where Id = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                sqlCommand.ExecuteScalar();

                sqlConnection.Close();
                ShowZoos();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
            
        }

        private void AddZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Zoo values (@Location)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);

                sqlCommand.ExecuteScalar();

                sqlConnection.Close();
                ShowZoos();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void addAnimalToZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into ZooAnimal values (@ZooId, @AnimalId)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);

                sqlCommand.ExecuteScalar();

                sqlConnection.Close();
                ShowAssociatedAnimals();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlConnection.Close();
                ShowAssociatedAnimals();
            }
        }

        private void updateZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update Zoo Set Location = @Location where Id = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);

                sqlCommand.ExecuteScalar();

                sqlConnection.Close();
                ShowZoos();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void updateAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update Animal Set Name = @Name where Id = @AnimalId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);

                sqlCommand.ExecuteScalar();

                sqlConnection.Close();
                ShowAllAnimals();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlConnection.Close();
                ShowAllAnimals();
            }
        }

        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Animal where Id = @AnimalId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);

                sqlCommand.ExecuteScalar();

                sqlConnection.Close();
                ShowZoos();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlConnection.Close();
                ShowAllAnimals();
            }
        }

        private void ShowSelectedZooInTextBox()
        {
            try
            {
                string query = "select Location from Zoo where Id = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    DataTable zooDataTable = new DataTable();
                    sqlDataAdapter.Fill(zooDataTable);

                    myTextBox.Text = zooDataTable.Rows[0]["Location"].ToString();
                }
            }

            catch (Exception e)
            {

            }
        }

        private void ShowSelectedAnimalInTextBox()
        {
            try
            {
                string query = "select Name from Animal where Id = @AnimalId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);

                    DataTable animalDataTable = new DataTable();
                    sqlDataAdapter.Fill(animalDataTable);

                    myTextBox.Text = animalDataTable.Rows[0]["Name"].ToString();
                }
            }

            catch (Exception e)
            {

            }
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Animal values (@Name)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);

                sqlCommand.ExecuteScalar();

                sqlConnection.Close();
                ShowZoos();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                sqlConnection.Close();
                ShowAllAnimals();
            }
        }

        private void listAllAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedAnimalInTextBox();
        }
    }
}
