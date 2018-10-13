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
using System.Data;
namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\PrpyectosdeTerceros\ProyectoJuanFerHospital\WindowsFormsApp1\WindowsFormsApp1\Tabla.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From [Table] where Username='" + textBox1.Text + "' and Password ='" + textBox2.Text + "' and Id ='" + textBox3.Text + "'", con);

            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);


            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Table]", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);

                string expression;
                expression = "[ID]= '"+textBox3.Text+"'";
                DataRow[] dr;
                dr = dt1.Select(expression);
                var name = dr[0]["name"].ToString();
                var rol = dr[0]["role"].ToString();


                if (rol == "Administrador")
                {
                    Form fmr1 = new Form1();
                    this.Hide();

                    fmr1.Show();
                        
                } else if(rol == "Paciente")
                {
                    Main ss = new Main();
                    this.Hide();

                    ss.Show();
                } else if(rol == "Doctor")
                {
                    Form doct = new MainDoctor();
                    doct.Show();
                    this.Hide();

                }

            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
