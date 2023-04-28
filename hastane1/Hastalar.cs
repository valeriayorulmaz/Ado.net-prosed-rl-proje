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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Diagnostics.Eventing.Reader;

namespace hastane1
{
    public partial class Hastalar : Form
    {
        public Hastalar()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-8RSV7HJ\\SQLKODLAMALAB;Database=hastane;Integrated Security=true;");

        public void Listeleme()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Hlistele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Listeleme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "HEkle";
            komut.Parameters.AddWithValue("HAdSoyad", textBox1.Text);
            komut.Parameters.AddWithValue("HastaTCNo", textBox2.Text);
            komut.Parameters.AddWithValue("HDogumTarihi",Convert.ToDateTime(dateTimePicker1.Text));
            komut.Parameters.AddWithValue("Boy", textBox4.Text);
            komut.Parameters.AddWithValue("ReceteNo", textBox6.Text);
            komut.Parameters.AddWithValue("DoktorNo", textBox7.Text);

            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow satir = dataGridView1.CurrentRow; //güncelsatırı satir a ata 
            textBox1.Tag = satir.Cells //tag ID tutuyor
                ["HastaNo"].Value.ToString();
            textBox1.Text = satir.Cells
                ["HAdSoyad"].Value.ToString();
            textBox2.Text = satir.Cells["HastaTCNo"].Value.ToString();
            //satırımın dadsoyad hücresinin değerini yazdır - 2.textbox ın textine ata
            dateTimePicker1.Text = satir.Cells["HDogumTarihi"].Value.ToString();
            textBox3.Text = satir.Cells["Boy"].Value.ToString();
            textBox6.Text = satir.Cells["DoktorNo"].Value.ToString();
            textBox4.Text = satir.Cells["ReceteNo"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "HYenile";
            komut.Parameters.AddWithValue("HAdSoyad", textBox1.Text);
            komut.Parameters.AddWithValue("HastaTCNo", textBox2.Text);
            komut.Parameters.AddWithValue("HDogumTarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("Boy", textBox3.Text);
            komut.Parameters.AddWithValue("ReceteNo", textBox4.Text);
            komut.Parameters.AddWithValue("DoktorNo", textBox6.Text);

            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "HSil";
            komut.Parameters.AddWithValue("HastaNo", textBox1.Tag);
            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem=="AdSoyad")
            {
               SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "HAra1";


                komut.Parameters.AddWithValue("DoktorNo", textBox7.Text);

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
                komut.CommandText = "HAra";


                komut.Parameters.AddWithValue("DoktorNo", textBox7.Text);

                SqlDataAdapter dr = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                dr.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void Hastalar_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 don = new Form2();
            don.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
