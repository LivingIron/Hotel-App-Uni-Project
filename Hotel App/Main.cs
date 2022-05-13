using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_App
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var AddRes = new AddReservation();
            AddRes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ShowRes = new ShowReservations();
            ShowRes.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ShowStats = new ShowStatistics();
            ShowStats.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var EditRoom = new EditRoom();
            EditRoom.Show();
        }
    }
}
