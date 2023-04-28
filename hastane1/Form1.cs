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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-8RSV7HJ\\SQLKODLAMALAB;Database=hastane;Integrated Security=true;");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(); //sql komudu yaz demek
            komut.Connection = conn;//veri tabanı 
            komut.CommandType = CommandType.StoredProcedure; //komutun tipi =procedure

            komut.CommandText = "Giris"; //procedure ismi
            komut.Parameters.AddWithValue("kad", textBox1.Text); //parametleri gir prosedurdeki
            komut.Parameters.AddWithValue("Sifre", textBox2.Text);//parametleri gir prosedurdeki

            conn.Open(); //parametreyi aç
            SqlDataReader dr; //sql deki dataları oku
            dr=komut.ExecuteReader();   //satır satır oku
            
            if (dr.Read())//eğer okuduysa
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız");
                Form2 arayuz =new Form2();
                arayuz.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınız veya şifreniz yanlış");
                textBox1.Clear(); 
                textBox2.Clear();

            }
            conn.Close();

        }
        public void Listeleme()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Klistele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            

        }
        private void button2_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "KEkle";
            komut.Parameters.AddWithValue("KullaniciAdi", textBox3.Text);

            komut.Parameters.AddWithValue("Sifre", textBox4.Text);
            komut.Parameters.AddWithValue("TelefonNo", textBox5.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            Listeleme();

            MessageBox.Show("Üye oldunuz! Lütfen giriş yapınız.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
