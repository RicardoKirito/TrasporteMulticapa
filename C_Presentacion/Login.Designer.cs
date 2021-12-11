
namespace C_Presentacion
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cerrar = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mensaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cerrar
            // 
            this.cerrar.Location = new System.Drawing.Point(846, 0);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(61, 48);
            this.cerrar.TabIndex = 1;
            this.cerrar.Text = "X";
            this.cerrar.UseVisualStyleBackColor = true;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(630, 214);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(195, 22);
            this.Username.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(627, 178);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(67, 20);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(627, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pasword";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(631, 312);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(195, 22);
            this.password.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(688, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Log in";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mensaje
            // 
            this.mensaje.AutoSize = true;
            this.mensaje.ForeColor = System.Drawing.Color.Coral;
            this.mensaje.Location = new System.Drawing.Point(630, 341);
            this.mensaje.Name = "mensaje";
            this.mensaje.Size = new System.Drawing.Size(0, 17);
            this.mensaje.TabIndex = 7;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 557);
            this.Controls.Add(this.mensaje);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.cerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label mensaje;
    }
}