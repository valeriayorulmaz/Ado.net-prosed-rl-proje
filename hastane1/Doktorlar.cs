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
    public partial class Doktorlar : Form
    {
        public Doktorlar()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-8RSV7HJ\\SQLKODLAMALAB;Database=hastane;Integrated Security=true;");
        public void Listeleme()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Dlistele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "DEkle";
            komut.Parameters.AddWithValue("DTCNo", textBox1.Text);
            komut.Parameters.AddWithValue("DAdSoyad", textBox2.Text);
            komut.Parameters.AddWithValue("UzmanlikAlani", textBox3.Text);
            komut.Parameters.AddWithValue("PoliklinikNo", comboBox1.Text);
            komut.Parameters.AddWithValue("Telefon", textBox4.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "DYenile";
            komut.Parameters.AddWithValue("DoktorNo", textBox1.Tag);
            komut.Parameters.AddWithValue("DTCNo", textBox1.Text);
            komut.Parameters.AddWithValue("DAdSoyad", textBox2.Text);
            komut.Parameters.AddWithValue("UzmanlikAlani", textBox3.Text);
            komut.Parameters.AddWithValue("PoliklinikNo", comboBox1.Text);
            komut.Parameters.AddWithValue("Telefon", textBox4.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Listeleme();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow; //güncelsatırı satir a ata 
            textBox1.Tag = satir.Cells //tag ID tutuyor
                ["PoliklinikNo"].Value.ToString();
            textBox1.Text = satir.Cells
                ["DTCNo"].Value.ToString();
            textBox2.Text = satir.Cells["DAdSoyad"].Value.ToString();
            //satırımın dadsoyad hücresinin değerini yazdır - 2.textbox ın textine ata
            textBox3.Text = satir.Cells["UzmanlikAlani"].Value.ToString();
            textBox4.Text = satir.Cells["Telefon"].Value.ToString();
            comboBox1.Text = satir.Cells["PoliklinikNo"].Value.ToString();

        }

        private void SİL(object sender, EventArgs e)
        {
            //KULLANMA BUTON5 BU
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "DSil";
            komut.Parameters.AddWithValue("DoktorNo", textBox1.Tag);
            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Doktor No")
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "DAra1";
               

                komut.Parameters.AddWithValue("DoktorNo", textBox5.Text);

                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                dr.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "DAra";
                komut.Parameters.AddWithValue("DAdSoyad", textBox5.Text);

                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                dr.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void Doktorlar_Load(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 don = new Form2();
            don.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
