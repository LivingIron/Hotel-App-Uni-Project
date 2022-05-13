using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.Collections;

namespace Hotel_App
{
    public partial class EditRoom : Form
    {

        public void UpdateComboBox()
        {
            comboBox1.Items.Clear();
          
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=Hotel-Habbo;User Id=postgres;Password=1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT name FROM rooms";

            NpgsqlDataReader dr = comm.ExecuteReader();


            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetValue("name"));
            }
            comm.Dispose();
            conn.Close();
        }

        public EditRoom()
        {
            InitializeComponent();
            UpdateComboBox();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=Hotel-Habbo;User Id=postgres;Password=1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "INSERT INTO rooms(name) VALUES('"+name+"');";

            NpgsqlDataReader dr = comm.ExecuteReader();

            UpdateComboBox();

            comm.Dispose();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedItem = comboBox1.SelectedItem;

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=Hotel-Habbo;User Id=postgres;Password=1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "DELETE FROM rooms WHERE name = '"+selectedItem+"';";

            NpgsqlDataReader dr = comm.ExecuteReader();
            UpdateComboBox();

            comm.Dispose();
            conn.Close();

        }

        private void EditRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
