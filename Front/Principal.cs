using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;


namespace Front
{
    public partial class Principal : Form
    {
        int asiertos = 0, posicion = 0, intentos = 1;
        Logic logica = new Logic();

        public Principal()
        {
            InitializeComponent();
        }

        private void txtCifras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) 
            {
                e.Handled = true;
                btnAceptar_Click(sender, e);
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            // Hago que todos los labels dentro del panel de intentos
            // tengan un string vacio y que no sean visibes.
            foreach (Control control  in pDatos.Controls)
            {
                if (control is Panel)
                {
                    Panel panelHijo = (Panel)control;
                    foreach (Control c in panelHijo.Controls) 
                    {
                        if (c is Label) 
                        {
                            ((Label)c).Text = string.Empty;
                            ((Label)c).Visible = false;
                        }
                    }
                }
            }
            
            string txt = logica.cargar();
            lblValor.Visible = false;
            lblValor.Text = txt;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            asiertos = 0;
            posicion = 0;
            string cifras = string.Join("|", txtCifras.Text.ToCharArray());

            if (intentos <= 10)
            {
                logica.verificar(txtCifras.Text, ref asiertos, ref posicion);
                string lblIntento = "lblIntento" + (intentos);
                Label etiqueta = pIntentos.Controls[lblIntento] as Label;

                if (etiqueta.Text == string.Empty)
                {
                    etiqueta.Text = cifras;
                    etiqueta.Visible = true;
                }
                string lblAsiertos = "lblAsiertos" + intentos;
                string lblPosicion = "lblPosicion" + intentos;
                etiqueta = pAsiertos.Controls[lblAsiertos] as Label;
                if (etiqueta.Text == string.Empty)
                {
                    etiqueta.Text = asiertos.ToString();
                    etiqueta.Visible = true;
                }
                etiqueta = pPosicion.Controls[lblPosicion] as Label;
                if (etiqueta.Text == string.Empty)
                {
                    etiqueta.Text = posicion.ToString();
                    etiqueta.Visible = true;
                }
                // elimino el contenido del cuadro de texto
                txtCifras.Text = string.Empty;


                // verifico si acerto los numeros
                if (posicion == 4 && asiertos == 4)
                {
                    lblValor.Visible = true;
                    MessageBox.Show("Ganaste el juego");
                    Close();
                }
            }
            /*else if (intentos == 10 && posicion == 4 && asiertos == 4)
            {
                MessageBox.Show("Ganaste el juego");
                Close();
            }*/
            else
            {
                lblValor.Visible = true;
                MessageBox.Show("lo siento, perdiste");
                Close();
            }
            intentos++;

        }



    }
}
