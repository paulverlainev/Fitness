using System;
using System.Linq;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;

namespace FitnessCenter;

public partial class Cl : Window
{
    private List<Client> client;
    private List<Gender> gender;
    private MySqlConnection conn;
    private string connString = "server=localhost; database=FitnessCentre; port=3306; User Id=root; password=123456";
    public Cl()
    {
        InitializeComponent();
        ShowTable(full);
        FillGender();
    }

   private string full = "SELECT Client.id, Client.surname, Client.name, Client.number, Client.dateofbirth, Gender.gender Client.discount FROM `Client` JOIN `Gender` ON Gender.id;";

    private void ShowTable(full)
    {
        conn = new MySqlConnection(connString);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(full,conn);
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read() && reader.HasRows)
        {
            var Clientss = new Client()
            {
                id = reader.GetInt32("id"),
                surname = reader.GetString("surname"),
                name = reader.GetString("name"),
                number = reader.GetString("number"),
                dateofbirth = reader.GetString("dateofbirth"),
                gender = reader.GetString("gender"),
                discount = reader.GetInt32("discount")
            };
        }
        conn.Close();
        Clients.ItemsSource = client;
    }
    private void FillGender()
    {
        
    }

    public void Search(object? sender, RoutedEventArgs e)
    {
        var srn = client;
        srn = srn.Where(x => x.surname.Contains(Searchs.Text)).ToList();
        Clients.ItemsSource = srn;
    }

    public void Reset(object? sender, RoutedEventArgs e)
    {
        ShowTable(full);
        Searchs.Text = string.Empty;
    }
    private void Delete(object? sender, RoutedEventArgs e)
    {
        Client clientee = new Client();
        conn = new MySqlConnection(connString);
        conn.Open();
        
        try
        {
            if (client == null)
            {
                return;
            }
            string sql = "DELETE FROM `Client` WHERE id=" + clientee.id;
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            client.Remove(clientee);
            ShowTable(full);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
}