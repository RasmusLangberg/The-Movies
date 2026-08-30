using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using The_Movies.Repository;
using The_Movies.Model;
using The_Movies.ViewModel;
using System.Collections.ObjectModel;
using The_Movies.Services;

namespace The_Movies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var repo = new MovieRepository();
            var _msg = new MessageService();
            DataContext = new MainViewModel();


        }

       
    }
}   