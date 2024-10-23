using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AprenderIdioma
{
    public partial class aprenderIdiomasForm : Form
    {
        private int pos, posFinal;
        List<string> listaCorrectaIngles = new List<string> { "Dog", "Cat", "Car", "Tree", "Mountain", "Butterfly", "Phone", "Pizza", "Guitar", "Ball" };
        List<string> listaIncorrectaIngles1 = new List<string> { "Banana", "Chair", "Sun", "Laptop", "Ocean", "Elephant", "Hat", "Juice", "Book", "Watch" };
        List<string> listaIncorrectaIngles2 = new List<string> { "Apple", "Table", "Moon", "Bicycle", "Desert", "Dragonfly", "Television", "Hamburger", "Violin", "Soccer" };

        List<string> listaCorrectaItaliano = new List<string> { "Cane", "Gatto", "Auto", "Albero", "Montagna", "Farfalla", "Telefono", "Pizza", "Chitarra", "Palla" };
        List<string> listaIncorrectaItaliano1 = new List<string> { "Banana", "Sedia", "Sole", "Computer", "Oceano", "Elefante", "Cappello", "Succo", "Libro", "Orologio" };
        List<string> listaIncorrectaItaliano2 = new List<string> { "Mela", "Tavolo", "Luna", "Bicicletta", "Deserto", "Libellula", "Televisione", "Hamburger", "Violino", "Calcio" };

        List<string> listaCorrectaFrances = new List<string> { "Chien", "Chat", "Voiture", "Arbre", "Montagne", "Papillon", "Téléphone", "Pizza", "Guitare", "Balle" };
        List<string> listaIncorrectaFrances1 = new List<string> { "Banane", "Chaise", "Soleil", "Ordinateur", "Océan", "Éléphant", "Chapeau", "Jus", "Livre", "Montre" };
        List<string> listaIncorrectaFrances2 = new List<string> { "Pomme", "Table", "Lune", "Vélo", "Désert", "Libellule", "Télévision", "Hamburger", "Violon", "Football" };
        private int aciertos;
        private Random random = new Random();
        private int opcion;


        public aprenderIdiomasForm()
        {
            pos = 0;
            posFinal = listaCorrectaIngles.Count - 1;
            InitializeComponent();
            retrocederUnoButton.Enabled = false;
            retrocerInicioButton.Enabled = false;
            aciertos = 0;
            cambiarPosRandon(random.Next(1, 4));
            TituloPrincipalLabel.Location = new Point(50, 50);
            ItalianoButton.Location = new Point(162, 90);
            InglesButton.Location = new Point(162, 200);
            FrancesButton.Location = new Point(162, 310);
        }
        private void InglesButton_Click(object sender, EventArgs e)
        {
            opcion = 1;
            mostrarImagenes();
            esconderAparecer();
        }

        private void FrancesButton_Click(object sender, EventArgs e)
        {
            opcion = 2;
            mostrarImagenes();
            esconderAparecer();
        }

        private void ItalianoButton_Click(object sender, EventArgs e)
        {
            opcion = 3;
            mostrarImagenes();
            esconderAparecer();
        }
        private void esconderAparecer()
        {
            TituloPrincipalLabel.Visible = false;
            ItalianoButton.Visible = false;
            InglesButton.Visible = false;
            FrancesButton.Visible = false;

            avanzarUnoButton.Visible = true;
            AvanzarFinalButton.Visible = true;
            retrocederUnoButton.Visible = true;
            retrocerInicioButton.Visible = true;
            mostrarImagenPicturBox.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }

        private void avanzarUnoButton_Click(object sender, EventArgs e)
        {
            ++pos;
            mostrarImagenes();
            desHabilitarAvanece();
            desHabilitarRetroceso();
            habilitarButton();
            cambiarPosRandon(random.Next(1, 4));
        }
        private void AvanzarFinalButton_Click(object sender, EventArgs e)
        {
            pos = posFinal;
            mostrarImagenes();
            desHabilitarAvanece();
            desHabilitarRetroceso();
            habilitarButton();
            cambiarPosRandon(random.Next(1, 4));

        }

        private void retrocederUnoButton_Click(object sender, EventArgs e)
        {
            --pos;
            mostrarImagenes();
            desHabilitarRetroceso();
            desHabilitarAvanece();
            --aciertos;

        }

        private void retrocerInicioButton_Click(object sender, EventArgs e)
        {
            pos = 0;
            mostrarImagenes();
            desHabilitarAvanece();
            desHabilitarRetroceso();
            aciertos = 0;
        }
        private void mostrarImagenes()
        {
            mostrarImagenPicturBox.Image = imageList1.Images[pos];
            elegirIdioma();
        }


        private void elegirIdioma()
        {
            switch (opcion)
            {
                case 1:
                    button1.Text = listaCorrectaIngles[pos];
                    button2.Text = listaIncorrectaIngles1[pos];
                    button3.Text = listaIncorrectaIngles2[pos];
                    elegirBandera("../../imagenes/baderaInglesa.png");
                    break;
                case 2:
                    button1.Text = listaCorrectaFrances[pos];
                    button2.Text = listaIncorrectaFrances1[pos];
                    button3.Text = listaIncorrectaFrances2[pos];
                    elegirBandera("../../imagenes/banderaFrancesa.png");
                    break;
                case 3:
                    button1.Text = listaCorrectaItaliano[pos];
                    button2.Text = listaIncorrectaItaliano1[pos];
                    button3.Text = listaIncorrectaItaliano2[pos];
                    elegirBandera("../../imagenes/baderaItaliana.png");
                    break;
            }
        }
        private void elegirBandera(String ruta)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Image.FromFile(ruta);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
            ++aciertos;
            deshabilitarButton();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
            deshabilitarButton();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
            deshabilitarButton();
        }

        private void deshabilitarButton()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

        }
        private void habilitarButton()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
        }

        private void desHabilitarAvanece()
        {
            if (pos != posFinal)
            {
                avanzarUnoButton.Enabled = true;
                AvanzarFinalButton.Enabled = true;
                verPuntucionButton.Visible = false;
            }
            else
            {
                retrocederUnoButton.Enabled = false;
                retrocerInicioButton.Enabled = false;
                avanzarUnoButton.Enabled = false;
                AvanzarFinalButton.Enabled = false;
                verPuntucionButton.Visible = true;
            }
        }

        private void verPuntucionButton_Click(object sender, EventArgs e)
        {
            retrocederUnoButton.Enabled = false;
            retrocerInicioButton.Enabled = false;
            avanzarUnoButton.Enabled = false;
            AvanzarFinalButton.Enabled = false;
            puntucionLabel.Text = "Tu puntuación es: " + aciertos;
            puntucionLabel.Visible = true;
        }

        private void desHabilitarRetroceso()
        {
            if (pos != 0)
            {
                retrocederUnoButton.Enabled = true;
                retrocerInicioButton.Enabled = true;
            }
            else
            {
                retrocederUnoButton.Enabled = false;
                retrocerInicioButton.Enabled = false;
                avanzarUnoButton.Enabled = true;
                AvanzarFinalButton.Enabled = true;
            }
        }



        private void cambiarPosRandon(int num)
        {
            if (num == 2)
            {
                button1.Location = new Point(329, 264);
                button2.Location = new Point(165, 264);
                button3.Location = new Point(247, 264);
            }
            else if (num == 3)
            {
                button1.Location = new Point(247, 264);
                button2.Location = new Point(329, 264);
                button3.Location = new Point(165, 264);
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
