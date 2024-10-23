namespace AprenderIdioma
{
    partial class aprenderIdiomasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aprenderIdiomasForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mostrarImagenPicturBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.retrocederUnoButton = new System.Windows.Forms.Button();
            this.avanzarUnoButton = new System.Windows.Forms.Button();
            this.retrocerInicioButton = new System.Windows.Forms.Button();
            this.AvanzarFinalButton = new System.Windows.Forms.Button();
            this.ItalianoButton = new System.Windows.Forms.Button();
            this.FrancesButton = new System.Windows.Forms.Button();
            this.InglesButton = new System.Windows.Forms.Button();
            this.TituloPrincipalLabel = new System.Windows.Forms.Label();
            this.puntucionLabel = new System.Windows.Forms.Label();
            this.verPuntucionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarImagenPicturBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "perro.jpg");
            this.imageList1.Images.SetKeyName(1, "gato.jpg");
            this.imageList1.Images.SetKeyName(2, "coche.jpg");
            this.imageList1.Images.SetKeyName(3, "arbol.jpg");
            this.imageList1.Images.SetKeyName(4, "montaña.jpg");
            this.imageList1.Images.SetKeyName(5, "mariposa.jpg");
            this.imageList1.Images.SetKeyName(6, "telefono.jpeg");
            this.imageList1.Images.SetKeyName(7, "pizza.jpg");
            this.imageList1.Images.SetKeyName(8, "guitarra.jpg");
            this.imageList1.Images.SetKeyName(9, "pelota.jpg");
            // 
            // mostrarImagenPicturBox
            // 
            this.mostrarImagenPicturBox.Location = new System.Drawing.Point(218, 117);
            this.mostrarImagenPicturBox.Name = "mostrarImagenPicturBox";
            this.mostrarImagenPicturBox.Size = new System.Drawing.Size(320, 200);
            this.mostrarImagenPicturBox.TabIndex = 0;
            this.mostrarImagenPicturBox.TabStop = false;
            this.mostrarImagenPicturBox.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(328, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(440, 325);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // retrocederUnoButton
            // 
            this.retrocederUnoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.retrocederUnoButton.Location = new System.Drawing.Point(167, 209);
            this.retrocederUnoButton.Name = "retrocederUnoButton";
            this.retrocederUnoButton.Size = new System.Drawing.Size(45, 49);
            this.retrocederUnoButton.TabIndex = 4;
            this.retrocederUnoButton.Text = "◀️";
            this.retrocederUnoButton.UseVisualStyleBackColor = true;
            this.retrocederUnoButton.Visible = false;
            this.retrocederUnoButton.Click += new System.EventHandler(this.retrocederUnoButton_Click);
            // 
            // avanzarUnoButton
            // 
            this.avanzarUnoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.avanzarUnoButton.Location = new System.Drawing.Point(544, 208);
            this.avanzarUnoButton.Name = "avanzarUnoButton";
            this.avanzarUnoButton.Size = new System.Drawing.Size(45, 49);
            this.avanzarUnoButton.TabIndex = 5;
            this.avanzarUnoButton.Text = "▶️";
            this.avanzarUnoButton.UseVisualStyleBackColor = true;
            this.avanzarUnoButton.Visible = false;
            this.avanzarUnoButton.Click += new System.EventHandler(this.avanzarUnoButton_Click);
            // 
            // retrocerInicioButton
            // 
            this.retrocerInicioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.retrocerInicioButton.Location = new System.Drawing.Point(43, 209);
            this.retrocerInicioButton.Name = "retrocerInicioButton";
            this.retrocerInicioButton.Size = new System.Drawing.Size(61, 50);
            this.retrocerInicioButton.TabIndex = 6;
            this.retrocerInicioButton.Text = "⏪";
            this.retrocerInicioButton.UseVisualStyleBackColor = true;
            this.retrocerInicioButton.Visible = false;
            this.retrocerInicioButton.Click += new System.EventHandler(this.retrocerInicioButton_Click);
            // 
            // AvanzarFinalButton
            // 
            this.AvanzarFinalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.AvanzarFinalButton.Location = new System.Drawing.Point(652, 209);
            this.AvanzarFinalButton.Name = "AvanzarFinalButton";
            this.AvanzarFinalButton.Size = new System.Drawing.Size(61, 49);
            this.AvanzarFinalButton.TabIndex = 7;
            this.AvanzarFinalButton.Text = "⏩";
            this.AvanzarFinalButton.UseVisualStyleBackColor = true;
            this.AvanzarFinalButton.Visible = false;
            this.AvanzarFinalButton.Click += new System.EventHandler(this.AvanzarFinalButton_Click);
            // 
            // ItalianoButton
            // 
            this.ItalianoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ItalianoButton.Location = new System.Drawing.Point(242, 699);
            this.ItalianoButton.Name = "ItalianoButton";
            this.ItalianoButton.Size = new System.Drawing.Size(302, 121);
            this.ItalianoButton.TabIndex = 11;
            this.ItalianoButton.Text = "Italiano";
            this.ItalianoButton.UseVisualStyleBackColor = true;
            this.ItalianoButton.Click += new System.EventHandler(this.ItalianoButton_Click);
            // 
            // FrancesButton
            // 
            this.FrancesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.FrancesButton.Location = new System.Drawing.Point(242, 572);
            this.FrancesButton.Name = "FrancesButton";
            this.FrancesButton.Size = new System.Drawing.Size(302, 121);
            this.FrancesButton.TabIndex = 10;
            this.FrancesButton.Text = "Francés";
            this.FrancesButton.UseVisualStyleBackColor = true;
            this.FrancesButton.Click += new System.EventHandler(this.FrancesButton_Click);
            // 
            // InglesButton
            // 
            this.InglesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.InglesButton.Location = new System.Drawing.Point(242, 445);
            this.InglesButton.Name = "InglesButton";
            this.InglesButton.Size = new System.Drawing.Size(302, 121);
            this.InglesButton.TabIndex = 9;
            this.InglesButton.Text = "Inglés";
            this.InglesButton.UseVisualStyleBackColor = true;
            this.InglesButton.Click += new System.EventHandler(this.InglesButton_Click);
            // 
            // TituloPrincipalLabel
            // 
            this.TituloPrincipalLabel.AutoSize = true;
            this.TituloPrincipalLabel.BackColor = System.Drawing.Color.Transparent;
            this.TituloPrincipalLabel.Font = new System.Drawing.Font("Elephant", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloPrincipalLabel.Location = new System.Drawing.Point(126, 399);
            this.TituloPrincipalLabel.Name = "TituloPrincipalLabel";
            this.TituloPrincipalLabel.Size = new System.Drawing.Size(544, 42);
            this.TituloPrincipalLabel.TabIndex = 8;
            this.TituloPrincipalLabel.Text = "¿Qué idioma deseas aprender?";
            // 
            // puntucionLabel
            // 
            this.puntucionLabel.AutoSize = true;
            this.puntucionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.puntucionLabel.Location = new System.Drawing.Point(215, 478);
            this.puntucionLabel.Name = "puntucionLabel";
            this.puntucionLabel.Size = new System.Drawing.Size(86, 31);
            this.puntucionLabel.TabIndex = 12;
            this.puntucionLabel.Text = "label1";
            this.puntucionLabel.Visible = false;
            // 
            // verPuntucionButton
            // 
            this.verPuntucionButton.Location = new System.Drawing.Point(281, 379);
            this.verPuntucionButton.Name = "verPuntucionButton";
            this.verPuntucionButton.Size = new System.Drawing.Size(184, 78);
            this.verPuntucionButton.TabIndex = 13;
            this.verPuntucionButton.Text = "VER PUNTUCIÓN";
            this.verPuntucionButton.UseVisualStyleBackColor = true;
            this.verPuntucionButton.Visible = false;
            this.verPuntucionButton.Click += new System.EventHandler(this.verPuntucionButton_Click);
            // 
            // aprenderIdiomasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AprenderIdioma.Properties.Resources.aprenderIdiomas;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(755, 574);
            this.Controls.Add(this.verPuntucionButton);
            this.Controls.Add(this.puntucionLabel);
            this.Controls.Add(this.ItalianoButton);
            this.Controls.Add(this.FrancesButton);
            this.Controls.Add(this.InglesButton);
            this.Controls.Add(this.TituloPrincipalLabel);
            this.Controls.Add(this.AvanzarFinalButton);
            this.Controls.Add(this.retrocerInicioButton);
            this.Controls.Add(this.avanzarUnoButton);
            this.Controls.Add(this.retrocederUnoButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mostrarImagenPicturBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "aprenderIdiomasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aprender Idiomas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cerrando);
            ((System.ComponentModel.ISupportInitialize)(this.mostrarImagenPicturBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox mostrarImagenPicturBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button retrocederUnoButton;
        private System.Windows.Forms.Button avanzarUnoButton;
        private System.Windows.Forms.Button retrocerInicioButton;
        private System.Windows.Forms.Button AvanzarFinalButton;
        private System.Windows.Forms.Button ItalianoButton;
        private System.Windows.Forms.Button FrancesButton;
        private System.Windows.Forms.Button InglesButton;
        private System.Windows.Forms.Label TituloPrincipalLabel;
        private System.Windows.Forms.Label puntucionLabel;
        private System.Windows.Forms.Button verPuntucionButton;
    }
}

