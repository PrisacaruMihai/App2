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

namespace App2
{
    public partial class Form1 : Form
    {
        int nrmodificari = 0; SqlConnection co;
        public Form1()
        {
            InitializeComponent();

            
        
   co = new SqlConnection(@"Data Source=(local);Initial Catalog=Angajati;Integrated Security=True;");

            co.Open();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertsql;
            insertsql = "insert into Agent (Id_Agent,NumeAgent,PrenumeAgent,Vechime,Salariu) values ('"; insertsql+=textBox1.Text+
                "', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+textBox4.Text + "','" + textBox5.Text + "')";
            SqlCommand cmd = new SqlCommand(insertsql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
            textBox6.Text = Convert.ToString(nrmodificari);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectSQL = "SELECT * FROM Agent";
            SqlCommand cmd = new SqlCommand(selectSQL, co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Agent");
            label8.Text = "Nume"; label9.Text = "Prenume"; label10.Text = "Vechime"; label11.Text =
            "Salariu";
            foreach (DataRow r in ds.Tables["Agent"].Rows)
            {
                label8.Text = label8.Text + "\n" + r["NumeAgent"] + "\n";
                label9.Text = label9.Text + "\n" + r["PrenumeAgent"] + "\n";
                label10.Text = label10.Text + "\n" + r["Vechime"] + "\n";
                label11.Text = label11.Text + "\n" + r["Salariu"] + "\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deletesql;
            deletesql = "delete from Agent where NumeAgent='"; deletesql += textBox7.Text + "'";
            SqlCommand cmd = new SqlCommand(deletesql, co);
            nrmodificari = nrmodificari + cmd.ExecuteNonQuery();
            textBox6.Text = Convert.ToString(nrmodificari);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            decimal suma;
            SqlCommand cmd = new SqlCommand("select SUM(Salariu) FROM Agent", co);
            suma = (decimal)cmd.ExecuteScalar();
            textBox8.Text = Convert.ToString(suma);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string min;
            SqlCommand cmd = new SqlCommand("select min(Vechime) FROM Agent", co);
            min = (string)cmd.ExecuteScalar();
            textBox9.Text = Convert.ToString(min);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            decimal max;
            SqlCommand cmd = new SqlCommand("select max(Salariu) FROM Agent", co);
            max = (decimal)cmd.ExecuteScalar();
            textBox10.Text = Convert.ToString(max);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string selectSQL = "select * FROM Agent ORDER BY NumeAgent ASC";
            SqlCommand cmmd = new SqlCommand(selectSQL, co);
            SqlDataAdapter adapter = new SqlDataAdapter(cmmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Agent");
            label8.Text = "Nume"; label9.Text = "Prenume"; label10.Text = "Vechime"; label11.Text = "Salariu";
            foreach (DataRow r in ds.Tables["Agent"].Rows)
            {
                label8.Text = label8.Text + "\n" + r["NumeAgent"] + "\n";
                label9.Text = label9.Text + "\n" + r["PrenumeAgent"] + "\n";

                
            label10.Text = label10.Text + "\n" + r["Vechime"] + "\n";
                label11.Text = label11.Text + "\n" + r["Salariu"] + "\n";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
    

