using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientReservasi.ServiceReference1;

namespace ClientReservasi
{
    public partial class Login : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Login()
        {
            InitializeComponent();
        }

        public Service1Client Service { get => service; set => service = value; }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            string kategori = Service.Login(username, password);

            if (kategori == "admin")
            {
                Register fm = new Register();
                this.Hide();
                fm.Show();
            }
            else if (kategori == "resepsionis")
            {
                Form1 fm = new Form1();
                this.Hide();
                fm.Show();
            }
            else
            {
                MessageBox.Show("Username dan Password Invalid, Silahkan hubungi admin.");
                textBoxUsername.Clear();
                textBoxPassword.Clear();
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}