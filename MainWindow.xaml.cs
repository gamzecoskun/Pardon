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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PardonEntities db;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new PardonEntities();
            dgCustomer.ItemsSource = db.Customers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Ekleme
        {
            Customer newCustomer = new Customer();
            newCustomer.ID = Convert.ToInt32(txtID.Text);
            newCustomer.Name = txtName.Text;
            newCustomer.Address = txtAddress.Text;
            newCustomer.Description = txtDescription.Text;
            db.Customers.Add(newCustomer);
            db.SaveChanges();
            dgCustomer.ItemsSource = db.Customers.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //Silme
        {
            int silinecek = Convert.ToInt32(txtID.Text);
            var silinecekKisi = db.Customers.Where(w => w.ID == silinecek).FirstOrDefault();
            db.Customers.Remove(silinecekKisi);
            db.SaveChanges();
            dgCustomer.ItemsSource = db.Customers.ToList();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Güncelleme
        {
            int guncelle = Convert.ToInt32(txtID.Text);
            var guncellenecekKisi = db.Customers.Where(w => w.ID == guncelle).FirstOrDefault();
            guncellenecekKisi.Name = txtName.Text;
            guncellenecekKisi.Address = txtAddress.Text;
            guncellenecekKisi.Description = txtDescription.Text;
            db.SaveChanges();
            dgCustomer.ItemsSource = db.Customers.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dgCustomer.ItemsSource = db.Customers.ToList().Where(x => x.Name == txtName.Text);
        }
    }
}
