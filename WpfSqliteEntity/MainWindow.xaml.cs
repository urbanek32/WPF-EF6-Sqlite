using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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

namespace WpfSqliteEntity
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadUsersFromDb();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var addUserWindow = new AddUserWindow();
            var result = addUserWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                label1.Text = "New user added to db";
                LoadUsersFromDb();
            }
        }

        private async void LoadUsersFromDb()
        {
            using (var db = new DatabaseContext())
            {
                label1.Text = "Loading users";
                listBox.Items.Clear();
                var users = await db.User.ToListAsync();
                foreach (var user in users)
                {
                    listBox.Items.Add(user);
                }
                label1.Text = $"Loaded users: {users.Count}";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedUser = listBox.SelectedItem as User;
            if (selectedUser != null)
            {
                using (var db = new DatabaseContext())
                {
                    var userToDelete = db.User.First(u => u.Id == selectedUser.Id);
                    db.User.Remove(userToDelete);
                    db.SaveChanges();
                    label1.Text = $"Deleted user: {userToDelete.FirstName}. \nReload user list!";
                }
            }
        }
    }
}
