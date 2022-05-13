using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace Hotel_App
{
    public partial class ShowReservations : Form
    {
        public ShowReservations()
        {
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=Hotel-Habbo;User Id=postgres;Password=1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT * FROM rooms";

            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }
    }
}
