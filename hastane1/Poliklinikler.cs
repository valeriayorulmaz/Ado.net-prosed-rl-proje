using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hastane1
{
    public partial class Poliklinikler : Form
    {
        public Poliklinikler()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-8RSV7HJ\\SQLKODLAMALAB;Database=hastane;Integrated Security=true;");
        public void Listeleme()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Plistele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow; //güncelsatırı satir a ata 
            textBox1.Tag = satir.Cells //tag ID tutuyor
                ["PoliklinikNo"].Value.ToString();
            textBox1.Text = satir.Cells
               ["PoliklinikAdi"].Value.ToString();
            textBox2.Text = satir.Cells
                ["UzmanSayisi"].Value.ToString();
            textBox3.Text = satir.Cells["HemsireSayisi"].Value.ToString();
            textBox4.Text = satir.Cells["YatakSayisi"].Value.ToString();
            comboBox1.Text = satir.Cells["HastaNo"].Value.ToString();
            comboBox2.Text = satir.Cells["DoktorNo"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PEkle";

            komut.Parameters.AddWithValue("PoliklinikAdi", textBox1.Text);
            komut.Parameters.AddWithValue("UzmanSayisi", textBox2.Text);
            komut.Parameters.AddWithValue("HemsireSayisi", textBox3.Text);
            komut.Parameters.AddWithValue("YatakSayisi", textBox4.Text);
            komut.Parameters.AddWithValue("HastaNo", comboBox1.Text);
            komut.Parameters.AddWithValue("DoktorNo", comboBox2.Text);

            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PYenile";

            komut.Parameters.AddWithValue("PoliklinikNo", textBox1.Tag);
            komut.Parameters.AddWithValue("PoliklinikAdi", textBox1.Text);
            komut.Parameters.AddWithValue("UzmanSayisi", textBox2.Text);
            komut.Parameters.AddWithValue("HemsireSayisi", textBox3.Text);
            komut.Parameters.AddWithValue("YatakSayisi", textBox4.Text);
            komut.Parameters.AddWithValue("HastaNo", comboBox1.Text);
            komut.Parameters.AddWithValue("DoktorNo", comboBox2.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Listeleme();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PSil";
            komut.Parameters.AddWithValue("PoliklinikNo", textBox1.Tag);
            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PAra";


            komut.Parameters.AddWithValue("PoliklinikNo", textBox5.Text);

            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 don = new Form2();
            don.Show();
            this.Hide();
        }

        private void Poliklinikler_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select*From Doktor", conn);
            conn.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["DoktorNo"]);
            }
            conn.Close();

            SqlCommand cmd1 = new SqlCommand("Select*From Hasta", conn);
            conn.Open();
            SqlDataReader dr1;
            dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["HastaNo"]);
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
