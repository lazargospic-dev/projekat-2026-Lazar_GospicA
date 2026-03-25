using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekat_2026_Lazar_GospicA
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // Lazar Gospic
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Morate uneti email i lozinku!");
            }
            else
            {
                SqlConnection veza = Konekcija.Connect();
                DataTable podaci = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM korisnik WHERE email= '" + txtName.Text+ "'", veza);
                adapter.Fill(podaci);
                int count = podaci.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("Email ne postoji");
                }
                else
                {
                    /*
                    string prvi = podaci.Rows[0]["pass"].ToString();
                    string drugi = txtPass.Text;
                    bool isti = prvi.Equals(drugi);
                    bool jednaki = String.Equals(prvi, drugi);
                    bool jednaki = String.Compare(prvi, drugi);
                    */
                    if (podaci.Rows[0]["pass"].ToString() == txtPass.Text) 
                    {
                        MessageBox.Show("Uspesno ste se ulogovali");
                        this.Hide();
                        Glavna forma = new Glavna();
                        forma.Show();
                    }
                    else 
                    {
                        MessageBox.Show("Pogresna Lozinka");
                    }
                }
            }
        }
    }
}
