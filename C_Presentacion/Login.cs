using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace C_Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {

        }
        public SqlConnection conxion = new SqlConnection("server = DESKTOP-RTHQME0\\MSSQLSERVER01; database = Transporte; integrated security = true;");

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conxion.Open();
            string acceso = $"select * from Usuario where Usuarios = '{Username.Text}' and contrasena = '{password.Text}';";
            SqlCommand command = new SqlCommand(acceso, conxion);
            SqlDataReader sql = command.ExecuteReader();
            mensaje.Text = "";
            if (sql.Read())
            {
                int derecho = Convert.ToInt32(sql["derechos"]);
                if (derecho == 1)
                {
                    Admin mat = new Admin();
                    conxion.Close();
                    this.Hide();
                    mat.Show();

                }
                else
                {

                    User mat = new User();
                    conxion.Close();
                    this.Hide();
                    mat.Show();
                }
            }
            else
            {
                mensaje.Text = "Usuario o Contraseña invalidos";
                conxion.Close();
            }


        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
}
