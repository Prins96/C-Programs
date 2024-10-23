namespace juegoDelColgado
{
    partial class JuegoAhorcado
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JuegoAhorcado));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelInformacion = new System.Windows.Forms.Label();
            this.buttonJugar = new System.Windows.Forms.Button();
            this.textBoxLetra = new System.Windows.Forms.TextBox();
            this.imagenesAhorcados = new System.Windows.Forms.PictureBox();
            this.ahoracados = new System.Windows.Forms.ImageList(this.components);
            this.letrasUsadasLabel = new System.Windows.Forms.Label();
            this.fraseSeleccionadaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imagenesAhorcados)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelTitulo.Location = new System.Drawing.Point(216, 331);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(217, 31);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Ingresa una letra";
            // 
            // labelInformacion
            // 
            this.labelInformacion.AutoSize = true;
            this.labelInformacion.Location = new System.Drawing.Point(77, 400);
            this.labelInformacion.Name = "labelInformacion";
            this.labelInformacion.Size = new System.Drawing.Size(168, 16);
            this.labelInformacion.TabIndex = 2;
            this.labelInformacion.Text = "información para el usuario";
            this.labelInformacion.Visible = false;
            // 
            // buttonJugar
            // 
            this.buttonJugar.BackColor = System.Drawing.Color.Lime;
            this.buttonJugar.Location = new System.Drawing.Point(188, 422);
            this.buttonJugar.Name = "buttonJugar";
            this.buttonJugar.Size = new System.Drawing.Size(258, 66);
            this.buttonJugar.TabIndex = 3;
            this.buttonJugar.Text = "JUGAR";
            this.buttonJugar.UseVisualStyleBackColor = false;
            this.buttonJugar.Click += new System.EventHandler(this.buttonJugar_Click);
            // 
            // textBoxLetra
            // 
            this.textBoxLetra.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBoxLetra.Location = new System.Drawing.Point(295, 365);
            this.textBoxLetra.MaxLength = 1;
            this.textBoxLetra.Multiline = true;
            this.textBoxLetra.Name = "textBoxLetra";
            this.textBoxLetra.Size = new System.Drawing.Size(57, 51);
            this.textBoxLetra.TabIndex = 0;
            // 
            // imagenesAhorcados
            // 
            this.imagenesAhorcados.Image = ((System.Drawing.Image)(resources.GetObject("imagenesAhorcados.Image")));
            this.imagenesAhorcados.Location = new System.Drawing.Point(476, 202);
            this.imagenesAhorcados.Name = "imagenesAhorcados";
            this.imagenesAhorcados.Size = new System.Drawing.Size(285, 250);
            this.imagenesAhorcados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagenesAhorcados.TabIndex = 4;
            this.imagenesAhorcados.TabStop = false;
            // 
            // ahoracados
            // 
            this.ahoracados.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ahoracados.ImageStream")));
            this.ahoracados.TransparentColor = System.Drawing.Color.Transparent;
            this.ahoracados.Images.SetKeyName(0, "sexto.png");
            this.ahoracados.Images.SetKeyName(1, "quinto.png");
            this.ahoracados.Images.SetKeyName(2, "cuarto.png");
            this.ahoracados.Images.SetKeyName(3, "tercero.png");
            this.ahoracados.Images.SetKeyName(4, "segundo.png");
            this.ahoracados.Images.SetKeyName(5, "primero.png");
            // 
            // letrasUsadasLabel
            // 
            this.letrasUsadasLabel.AutoSize = true;
            this.letrasUsadasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.letrasUsadasLabel.Location = new System.Drawing.Point(12, 148);
            this.letrasUsadasLabel.Name = "letrasUsadasLabel";
            this.letrasUsadasLabel.Size = new System.Drawing.Size(169, 29);
            this.letrasUsadasLabel.TabIndex = 5;
            this.letrasUsadasLabel.Text = "LetrasUsadas";
            this.letrasUsadasLabel.Visible = false;
            // 
            // fraseSeleccionadaLabel
            // 
            this.fraseSeleccionadaLabel.AutoSize = true;
            this.fraseSeleccionadaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.fraseSeleccionadaLabel.Location = new System.Drawing.Point(14, 234);
            this.fraseSeleccionadaLabel.Name = "fraseSeleccionadaLabel";
            this.fraseSeleccionadaLabel.Size = new System.Drawing.Size(293, 29);
            this.fraseSeleccionadaLabel.TabIndex = 6;
            this.fraseSeleccionadaLabel.Text = "la frase seleccionada es:";
            this.fraseSeleccionadaLabel.Visible = false;
            // 
            // JuegoAhorcado
            // 
            this.AcceptButton = this.buttonJugar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(773, 533);
            this.Controls.Add(this.fraseSeleccionadaLabel);
            this.Controls.Add(this.letrasUsadasLabel);
            this.Controls.Add(this.imagenesAhorcados);
            this.Controls.Add(this.buttonJugar);
            this.Controls.Add(this.labelInformacion);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.textBoxLetra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JuegoAhorcado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Juego Ahoracado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cerrando);
            ((System.ComponentModel.ISupportInitialize)(this.imagenesAhorcados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelInformacion;
        private System.Windows.Forms.Button buttonJugar;
        private System.Windows.Forms.TextBox textBoxLetra;
        private System.Windows.Forms.PictureBox imagenesAhorcados;
        private System.Windows.Forms.ImageList ahoracados;
        private System.Windows.Forms.Label letrasUsadasLabel;
        private System.Windows.Forms.Label fraseSeleccionadaLabel;
    }
}

