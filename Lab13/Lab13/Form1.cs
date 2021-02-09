using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab13
{
    public partial class Form1 : Form
    {
        string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\FINALLY\Lab13\Lab13\Database1.mdf;Integrated Security = True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Initialize
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Cities", CONNECTION_STRING);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }
        //Remove
        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentCell.Value);
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Cities WHERE Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            string query = "SELECT * FROM Cities WHERE[Population] > 9000000";

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query, connection);
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }
        // add new item
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            string query = "INSERT INTO Cities ([Name], Population, County, Capital, Port)";
            query += " VALUES (@Name,@Population,@County,@Capital,@Port)";

            SqlCommand myCommand = new SqlCommand(query, connection);
            myCommand.Parameters.AddWithValue("@Name", textBox1.Text);
            myCommand.Parameters.AddWithValue("@Population", textBox2.Text);
            myCommand.Parameters.AddWithValue("@County", textBox3.Text);
            myCommand.Parameters.AddWithValue("@Capital", textBox4.Text);
            myCommand.Parameters.AddWithValue("@Port", textBox5.Text);
            myCommand.ExecuteNonQuery();
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            string query = "SELECT * FROM Cities WHERE[Port] = 'Yes'";

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query, connection);
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            string query = "SELECT * FROM Cities WHERE[Capital] = 'Yes'";

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query, connection);
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            string query = "SELECT * FROM Cities ORDER BY Name ASC";

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query, connection);
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            string query = "SELECT * FROM Cities ORDER BY Name DESC";

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query, connection);
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }
    }
}
