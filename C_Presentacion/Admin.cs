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
using C_Entidad;
using C_Negocios;

namespace C_Presentacion
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            time.Format = DateTimePickerFormat.Short;
        }

        bool chofer = true;
        bool bus = false;
        bool ruta = false;
        bool buscars = false;

        N_Chofer driver = new N_Chofer();
        N_Ruta rutas = new N_Ruta();
        N_Bus auto = new N_Bus();

        private void bunifuGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChoferListar_Click(object sender, EventArgs e)
        {
            chofer = true;
            bus = false;
            ruta = false;
            Listar();

        }

        private void Bus_Click(object sender, EventArgs e)
        {
            chofer = false;
            bus = true;
            ruta = false;
            Listar();
        }

        private void rutalistar_Click(object sender, EventArgs e)
        {
            chofer = false;
            bus = false;
            ruta = true;
            Listar();
        }
        void Listar()
        {

            if (chofer)
            {
                Vista.DataSource = driver.Listar();
                choferI.Visible = true;
                BusI.Visible = false;
                RutaI.Visible = false;

            }
            else if (bus)
            {
                Vista.DataSource = auto.Listar();
                choferI.Visible = false;
                BusI.Visible = true;
                RutaI.Visible = false;
            }
            else
            {
                Vista.DataSource = rutas.Listar();
                choferI.Visible = false;
                BusI.Visible = false;
                RutaI.Visible = true;
            }
        }

        private void bbuscar_Click(object sender, EventArgs e)
        {
            if(Buscar.Text !="Buscar" && Buscar.Text != "")
            {
                if (chofer)
                {
                    Vista.DataSource = driver.Buscar(Buscar.Text);
                    
                }else if (bus)
                {
                    Vista.DataSource = auto.Buscar(Buscar.Text);
                }
                else
                {
                    Vista.DataSource = rutas.Buscar(Buscar.Text);
                }
                buscars = false;
            }
            else
            {
                Listar();
                buscars = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            Listar();
            Limpiar();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            Buscar.Text = "";
            buscars = true;
        }

        private void Buscar_Leave(object sender, EventArgs e)
        {
            Buscar.Text = "Buscar";
            buscars = false;
        }

        private void Buscar_OnValueChanged(object sender, EventArgs e)
        {

        }
        public void Limpiar()
        {
            //ocultamos los elementos
            l1.Visible = false;
            l2.Visible = false;
            l3.Visible = false;
            l4.Visible = false;
            l5.Visible = false;

            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = false;
            a5.Visible = false;
            c1.Visible = false;
            c2.Visible = false;
            c3.Visible = false;

            T1.Visible = false;
            t2.Visible = false;
            t3.Visible = false;
            t4.Visible = false;
            t5.Visible = false;
            time.Visible = false;

            agregar.Visible = false;

            //limpiamos los texbox
            T1.Text = "";
            t2.Text = "";
            t3.Text = "";
            t4.Text = "";
            t5.Text = "";

            //limpiamos los combobox
            c1.Items.Clear();
            c2.Items.Clear();
            c3.Items.Clear();
            c1.Text = "";
            c2.Text = "";
            c3.Text = "";


            



        }
        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limpiar();
            panel2.Visible = true;
            agregar.Visible = true;
            if (chofer)
            {
                //mostramos los labels
                l1.Visible = true;
                l2.Visible = true;
                l3.Visible = true;
                l4.Visible = true;

                //damos valor
                l1.Text = "Nombre";
                l2.Text = "Apellido";
                l3.Text = "Fecha de nacido";
                l4.Text = "Cedula";

                //mostramos los text box y time
                T1.Visible = true;
                t2.Visible = true;
                t3.Visible = true;
                time.Visible = true;





            }
            else if (bus)
            {
                //mostramos los labels
                l1.Visible = true;
                l2.Visible = true;
                l3.Visible = true;
                l4.Visible = true;
                l5.Visible = true;


                //damos valor
                l1.Text = "Marca";
                l2.Text = "Modelo";
                l3.Text = "Año";
                l4.Text = "Color";
                l5.Text = "Placa";

                //mostramos los text box y time
                c1.Visible = true;
                c2.Visible = true;
                t5.Visible = true;
                t3.Visible = true;
                t4.Visible = true;


                //anadimos los datos a los combobox
                string[] add = auto.Marca().Split('\n');
                foreach (string i in add)
                {
                    c1.Items.Add(i.Replace("  ", string.Empty));
                }


            }
            else
            {
                //mostramos elementos
                l1.Visible = true;
                l2.Visible = true;
                l3.Visible = true;
                c2.Visible = true;
                c3.Visible = true;
                T1.Visible = true;
                c2.Size = new Size(c2.Size.Width, c2.Size.Height + 50);

                //Texto a los labels
                l1.Text = "Nombre";
                l2.Text = "Chofer";
                l3.Text = "Autobus";

                string[] add = driver.Chofer().Split('\n');
                foreach (string i in add)
                {
                    c2.Items.Add(i.Replace("  ", string.Empty));
                }
                string[] addbus = driver.Chofer().Split('\n');
                foreach (string i in addbus)
                {
                    c3.Items.Add(i.Replace("  ", string.Empty));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            Limpiar();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void c1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c2.Items.Clear();
            if (c1.SelectedItem != "" || c1.SelectedItem != "Disponible" || c1.SelectedItem != null)
            {
                string[] add = auto.Modelo(c1.SelectedItem.ToString().Replace("  ", string.Empty)).Split('\n');
                foreach (string i in add)
                {
                    c2.Items.Add(i);
                }
                c2.SelectedIndex = 0;
            }
        }

        private void agregar_Click(object sender, EventArgs e)
        {
            if (chofer)
            {
                if (T1.Text != "" && t2.Text != "" && t3.Text != "" && time.Value.Year < DateTime.Now.Year - 18)
                {
                    Chofer nuevo = new Chofer();
                    nuevo.Nombre1 = T1.Text;
                    nuevo.Apellido1 = t2.Text;
                    nuevo.Fecha1 = time.Text;
                    nuevo.Cedula1 = t3.Text;
                    nuevo.Ruta1 = null;
                    driver.Insertar(nuevo);
                    panel2.Visible = false;
                    Listar();
                }
                else
                {
                    a1.Visible = (T1.Text.Length > 2) ? false : true;
                    a2.Visible = (t2.Text.Length > 2) ? false : true;
                    a3.Visible = (time.Value.Year < DateTime.Now.Year - 18) ? false : true;
                    a4.Visible = (t3.Text.Length > 2) ? false : true;

                }

            }
            else if (bus)
            {

                if (c1.Text != "" && c2.Text != "" && t4.Text!="" && t3.Text !=""&& t5.Text.Length==4)
                {
                    Bus nuevo = new Bus();
                    nuevo.Marca1 = c1.Text;
                    nuevo.Modelo1 = c2.Text;
                    nuevo.Ano1 = t5.Text;
                    nuevo.Color1 = t3.Text;
                    nuevo.Placa1 = t4.Text;
                    nuevo.IDruta1 = null;
                    auto.Insertar(nuevo);
                    panel2.Visible = false;
                    Listar();
                }
                else
                {
                    int n = 0;
                    a1.Visible = (c1.Text.Length > 2) ? false : true;
                    a2.Visible = (c2.Text.Length > 2) ? false : true;
                    a3.Visible = (t5.Text.Length == 4&& Convert.ToInt32(t5.Text)<DateTime.Now.Year+2 && int.TryParse(t5.Text, out n)) ? false : true;
                    a4.Visible = (t3.Text.Length > 2) ? false : true;
                    a5.Visible = (t4.Text.Length > 2) ? false : true;
                }
            }
        }
    }
}
