using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.Diagnostics;

namespace Hotel_App
{
    public partial class AddReservation : Form
    {

        public void UpdateComboBox()
        {
            comboBox1.Items.Clear();

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=Hotel-Habbo;User Id=postgres;Password=1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT id FROM rooms";

            NpgsqlDataReader dr = comm.ExecuteReader();


            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetValue("id"));
            }
            
            comm.Dispose();
            conn.Close();
        }


        public AddReservation()
        {
            InitializeComponent();
            UpdateComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var phone = textBox2.Text;
            var from = (dateTimePicker1.Value.Year+"-"+dateTimePicker1.Value.Month+"-"+dateTimePicker1.Value.Day);
            var to = (dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day);
            var room = comboBox1.SelectedItem;

            Debug.WriteLine(room);

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=Hotel-Habbo;User Id=postgres;Password=1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            //comm.CommandText = "INSERT INTO reservations(name,phone,startdate,enddate,room_id) VALUES('"+name+"''"+phone+"''"+from+"''"+to+"'"+room+");";
            comm.CommandText = "INSERT INTO reservations(name,phone,startdate,enddate,room_id) VALUES(@name,@phone,@from,@to,room);";
            Debug.WriteLine("INSERT INTO reservations(name,phone,startdate,enddate,room_id) VALUES('" + name + "','" + phone + "','" + from + "','" + to + "'," + room + ");");
            NpgsqlDataReader dr = comm.ExecuteReader();

            comm.Dispose();
            conn.Close();
        }
    }
}
