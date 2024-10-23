using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juegoDelColgado
{
    public partial class JuegoAhorcado : Form
    {
        private List<string> frases = new List<string>() {"Amor", "Supercalifragilisticoespialidoso", "Terror", "Navidad", "Soleado", "Computadora", "Felicidad",
    "Aventura", "Libertad", "Misterio", "Refrigerador", "Energia", "Montaña", "Cancion", "Invierno", "Espectacular", "Paz", "Viaje", "Chocolate", "Verano"};
        private int aleatorio;
        private String fraseEscogida, frase;
        private TextBox[] textBox;
        private int contador, contadorLetra;
        private List<char> listaCaracteres;
        public JuegoAhorcado()
        {
            InitializeComponent();
            aleatorio = new Random().Next(0, frases.Count);
            contador = 5;
            contadorLetra = 0;
            generarBox();
            fraseEscogida = frases[aleatorio];
            frase = "";
            //continuar = true;
            listaCaracteres = new List<char>();

        }

        private void generarBox()
        {
            labelInformacion.Visible = true;
            fraseEscogida = frases[aleatorio];
            labelInformacion.Text = "INTENTOS RESTANTES: " + (contador + 1);


            textBox = new TextBox[fraseEscogida.Length];
            for (int i = 0; i < fraseEscogida.Length; i++)
            {
                textBox[i] = new TextBox();
                // Establecer propiedades para el TextBox
                if (i < 16)
                {
                    textBox[i].Location = new System.Drawing.Point(12 * i * 3, 25); // Posición
                }
                else if (i < 32)
                {
                    textBox[i].Location = new System.Drawing.Point(12 * (i - 16) * 3, 55); // Posición
                }
                else
                {
                    textBox[i].Location = new System.Drawing.Point(12 * (i - 32) * 3, 95); // Posición
                }
                textBox[i].Size = new System.Drawing.Size(30, 20); // Tamaño
                textBox[i].Text = " "; // Texto inicial
                textBox[i].Visible = true;
                textBox[i].ReadOnly = true;

                // Agregar el TextBox al formulario
                this.Controls.Add(textBox[i]);
            }
        }

        private void buttonJugar_Click(object sender, EventArgs e)
        {
            try
            {
                char letra = textBoxLetra.Text[0];
                letra = char.ToUpper(letra);
                if (esConsonante(letra))
                {
                    letrasUsadasLabel.Visible = true;
                    if (!letraUsada(letra))
                    {
                        accionButton(letra);
                        haGanado();
                    }
                }
                textBoxLetra.Text = "";
            } catch (IndexOutOfRangeException)
            {

            }

        }
        private bool esConsonante(char mensaje)
        {
            String consonantes = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZÇ";
            return consonantes.Contains(char.ToUpper(mensaje));
        }

        private bool letraUsada(char letra)
        {
            if (listaCaracteres.Contains(letra))
            {
                return true;
            }
            else
            {
                listaCaracteres.Add(letra);
                frase += letra.ToString() + " ";
                letrasUsadasLabel.Text = frase;

                return false;
            }
        }
        private void accionButton(char letra)
        {
            bool letraAdivinada = false; // Para rastrear si se adivinó alguna letra

            for (int i = 0; i < fraseEscogida.Length; i++)
            {
                if (string.Equals(fraseEscogida[i].ToString(), letra.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    textBox[i].Text = letra.ToString().ToUpper();
                    letraAdivinada = true;
                    contadorLetra++;
                }
            }

            if (!letraAdivinada)
            {
                mostrarAhorcado(contador--);
            }

            if (contador == -1)
            {
                desahabilitar();
                fraseSeleccionadaLabel.Text = "La palabra era: \n" + fraseEscogida;
            }
        }

        private void desahabilitar()
        {
            textBoxLetra.Enabled = false;
            buttonJugar.Enabled = false;
            fraseSeleccionadaLabel.Visible = true;
        }

        

        private void mostrarAhorcado(int i)
        {
            switch (i)
            {
                case 0:
                    imagenesAhorcados.Image = ahoracados.Images[i];
                    labelInformacion.Text = "INTENTOS RESTANTES: " + i;
                    break;
                case 1:
                    imagenesAhorcados.Image = ahoracados.Images[i];
                    labelInformacion.Text = "INTENTOS RESTANTES: " + i;
                    break;
                case 2:
                    imagenesAhorcados.Image = ahoracados.Images[i];
                    labelInformacion.Text = "INTENTOS RESTANTES: " + i;
                    break;
                case 3:
                    imagenesAhorcados.Image = ahoracados.Images[i];
                    labelInformacion.Text = "INTENTOS RESTANTES: " + i;
                    break;
                case 4:
                    imagenesAhorcados.Image = ahoracados.Images[i];
                    labelInformacion.Text = "INTENTOS RESTANTES: " + i;
                    break;
                case 5:
                    imagenesAhorcados.Image = ahoracados.Images[i];
                    labelInformacion.Text = "INTENTOS RESTANTES: " + i;
                    break;
            }
        }
        private void haGanado()
        {
            if (contadorLetra == fraseEscogida.Length)
            {
                desahabilitar();
                fraseSeleccionadaLabel.Text = "Felicidades has ganado";

            }
        }
        
        private void cerrando(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
