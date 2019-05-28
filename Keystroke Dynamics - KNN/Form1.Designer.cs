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
            // 
            // errorLabel
            // 
            this.errorLabel.AllowDrop = true;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(548, 85);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(65, 19);
            this.errorLabel.TabIndex = 7;
            this.errorLabel.Text = "ERROR";
            this.errorLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

