using System;
using System.Linq;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Platform;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;

namespace FitnessCenter;

public partial class MainWindow : Window
{
    private string connString = "server=localhost; database=FitnessCentre; port=3306; User Id=root; password=123456";
    public MainWindow()
    {
        InitializeComponent();
    }

    public void Autorization(object? sender, RoutedEventArgs e)
    {
        string login = Log.Text;
        string password = Pass.Text;
        if (login == "root" && password == "root")
        {
            Cl cl = new Cl();
            cl.Show();
            this.Close();
        }
        if (login == "QWERTY" && password == "QWERTY")
        {
            Cl2 cl2 = new Cl2();
            cl2.Show();
            this.Close();
        }
    }
    public void Registration(object? sender, RoutedEventArgs e)
    {
        
    }

}