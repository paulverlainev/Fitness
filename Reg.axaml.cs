using System;
using System.Linq;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;

namespace FitnessCenter;

public partial class Reg: Window
{
    private List<Client> Cl;
    private Client NewClient;
    private string connString = "server=localhost; database=FitnessCentre; port=3306; User Id=root; password=123456";
    private MySqlConnection conn;
    public Reg(Client newClient, List<Client> cl)
    {
        InitializeComponent();
        NewClient = new Client();
        this.DataContext = newClient;
        Cl = cl;
    }

    public void Regg(object? sender, RoutedEventArgs e)
    {
        if (client == null)
        {
            conn = new MySqlConnection(connString);
            conn.Open();
            string add = "INSERT INTO `Client` (surname, name, number, dateofbirth, gender, discount, password) VALUES ('"+Surname.Text+"', '"+Name.Text+"', '"+Number.Text+"',  '"+Date.Text+"', '"+Convert.ToInt32(Gender.Text)+"', '"+Convert.ToInt32(Discount.Text)+"','"+Password.Text+"');";
            MySqlCommand cmd = new MySqlCommand(add, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}