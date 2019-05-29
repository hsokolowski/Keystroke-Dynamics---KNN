namespace Keystroke_Dynamics___KNN
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.WpisywanieTextBox = new System.Windows.Forms.TextBox();
            this.NickTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ZatwierdzButton = new System.Windows.Forms.Button();
            this.CzastextBox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.sprawdz = new System.Windows.Forms.Button();
            this.literkiErrorLabel = new System.Windows.Forms.Label();
            this.motywujacyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "BIOMETRIA JEST NAJLEPSZA";
            // 
            // WpisywanieTextBox
            // 
            this.WpisywanieTextBox.Location = new System.Drawing.Point(223, 85);
            this.WpisywanieTextBox.Name = "WpisywanieTextBox";
            this.WpisywanieTextBox.Size = new System.Drawing.Size(319, 22);
            this.WpisywanieTextBox.TabIndex = 1;
            this.WpisywanieTextBox.TextChanged += new System.EventHandler(this.WpisywanieTextBox_TextChanged);
            this.WpisywanieTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WpisywanieTextBox_KeyDown);
            this.WpisywanieTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WpisywanieTextBox_KeyUp);
            // 
            // NickTextBox
            // 
            this.NickTextBox.Location = new System.Drawing.Point(223, 143);
            this.NickTextBox.Name = "NickTextBox";
            this.NickTextBox.Size = new System.Drawing.Size(319, 22);
            this.NickTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wpisz zdanie:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Wpisz nick:";
            // 
            // ZatwierdzButton
            // 
            this.ZatwierdzButton.Location = new System.Drawing.Point(337, 198);
            this.ZatwierdzButton.Name = "ZatwierdzButton";
            this.ZatwierdzButton.Size = new System.Drawing.Size(88, 23);
            this.ZatwierdzButton.TabIndex = 5;
            this.ZatwierdzButton.Text = "Zatwierdz";
            this.ZatwierdzButton.UseVisualStyleBackColor = true;
            this.ZatwierdzButton.Click += new System.EventHandler(this.ZatwierdzButton_Click);
            // 
            // CzastextBox
            // 
            this.CzastextBox.Location = new System.Drawing.Point(223, 291);
            this.CzastextBox.Name = "CzastextBox";
            this.CzastextBox.Size = new System.Drawing.Size(319, 22);
            this.CzastextBox.TabIndex = 6;
            this.CzastextBox.TextChanged += new System.EventHandler(this.CzastextBox_TextChanged);
            // 
            // errorLabel
            // 
            this.errorLabel.AllowDrop = true;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(573, 69);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(108, 19);
            this.errorLabel.TabIndex = 7;
            this.errorLabel.Text = "ZLA LITERKA";
            this.errorLabel.Visible = false;
            // 
            // sprawdz
            // 
            this.sprawdz.Location = new System.Drawing.Point(446, 197);
            this.sprawdz.Name = "sprawdz";
            this.sprawdz.Size = new System.Drawing.Size(96, 24);
            this.sprawdz.TabIndex = 8;
            this.sprawdz.Text = "Sprawdź";
            this.sprawdz.UseVisualStyleBackColor = true;
            this.sprawdz.Click += new System.EventHandler(this.sprawdz_Click);
            // 
            // literkiErrorLabel
            // 
            this.literkiErrorLabel.AllowDrop = true;
            this.literkiErrorLabel.AutoSize = true;
            this.literkiErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.literkiErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.literkiErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.literkiErrorLabel.Location = new System.Drawing.Point(583, 102);
            this.literkiErrorLabel.Name = "literkiErrorLabel";
            this.literkiErrorLabel.Size = new System.Drawing.Size(82, 19);
            this.literkiErrorLabel.TabIndex = 9;
            this.literkiErrorLabel.Text = "2 LITERKI";
            this.literkiErrorLabel.Visible = false;
            // 
            // motywujacyLabel
            // 
            this.motywujacyLabel.AllowDrop = true;
            this.motywujacyLabel.AutoSize = true;
            this.motywujacyLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.motywujacyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.motywujacyLabel.ForeColor = System.Drawing.Color.Green;
            this.motywujacyLabel.Location = new System.Drawing.Point(326, 63);
            this.motywujacyLabel.Name = "motywujacyLabel";
            this.motywujacyLabel.Size = new System.Drawing.Size(137, 19);
            this.motywujacyLabel.TabIndex = 10;
            this.motywujacyLabel.Text = "DOBRZE CI IDZIE";
            this.motywujacyLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.motywujacyLabel);
            this.Controls.Add(this.literkiErrorLabel);
            this.Controls.Add(this.sprawdz);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.CzastextBox);
            this.Controls.Add(this.ZatwierdzButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NickTextBox);
            this.Controls.Add(this.WpisywanieTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WpisywanieTextBox;
        private System.Windows.Forms.TextBox NickTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ZatwierdzButton;
        private System.Windows.Forms.TextBox CzastextBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button sprawdz;
        private System.Windows.Forms.Label literkiErrorLabel;
        private System.Windows.Forms.Label motywujacyLabel;
    }
}

