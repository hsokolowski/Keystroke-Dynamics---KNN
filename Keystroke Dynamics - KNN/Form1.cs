using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keystroke_Dynamics___KNN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Stopwatch sw = new Stopwatch();
        string haslo = "BIOMETRIA JEST NAJLEPSZA";
        int[] profil = new int[27];
        int[] profilLicznik = new int[27];
        private void WpisywanieTextBox_TextChanged(object sender, EventArgs e)
        {
            
            if(WpisywanieTextBox.Text.Length!=0 && WpisywanieTextBox.Text[WpisywanieTextBox.Text.Length-1]!=haslo[WpisywanieTextBox.Text.Length-1])
            {
                ClearTB();
            }
            else
            {
                errorLabel.Visible = false;
            }
        }
        private void ClearTB()
        {
            WpisywanieTextBox.Text = "";
            errorLabel.Visible = true;
            for (int i = 0; i < 27; i++)
                profil[i] = 0;

        }
        private void WpisywanieTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            sw.Start();

        }

        private void WpisywanieTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            sw.Stop();
            //Spacja
            if (WpisywanieTextBox.Text.Length != 0 && WpisywanieTextBox.Text[WpisywanieTextBox.Text.Length - 1] == ' ')
            {
                profil[26] += sw.Elapsed.Milliseconds;
                profilLicznik[26]++;
            }
            //Literka
            else if (WpisywanieTextBox.Text.Length != 0)
            {
                int literka = (int)WpisywanieTextBox.Text[WpisywanieTextBox.Text.Length - 1] - 65;
                profil[literka] += sw.Elapsed.Milliseconds;
                profilLicznik[literka]++;
            }
            sw.Reset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 27; i++)
            {
                profil[i] = 0;
                profilLicznik[i] = 0;
            }
        }
        private void liczSrednia()
        {
            for(int i=0;i<27;i++)
                if(profilLicznik[i]>1)
                {
                    profil[i] /= profilLicznik[i];
                }
        }
        private void generujPlik()
        {
            int licznik = 0;            
            string fileName = "C:\\Image\\" + NickTextBox.Text.ToString() + licznik.ToString()+ ".txt";
            string wszystko = "";
            for(int i=0;i<27;i++)
            {
                wszystko += i.ToString() + ". " + profil[i] +"-"+ (char)(i+65) + Environment.NewLine;
            }
            while(File.Exists(fileName))
            {
                licznik++;
                fileName = "C:\\Image\\" + NickTextBox.Text.ToString() + licznik.ToString() + ".txt";
            }
        
            File.WriteAllText(fileName, wszystko);
           
        }
        private void ZatwierdzButton_Click(object sender, EventArgs e)
        {
            liczSrednia();
            generujPlik();
        }
    }
}
