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
        int[] klasy;
        int iloscUzytkownikow=0, iloscProbek=0;
        string[] nicki;
        private void WpisywanieTextBox_TextChanged(object sender, EventArgs e)
        {
            if(haslo.Length==WpisywanieTextBox.Text.Length)
            {
                liczSrednia();
            }
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
            for (int i = 0; i < 30; i++)
            {
                //klasy[i] = -1;
                //if (i < 10) nicki[i] = " ";
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
            string fileName = "C:\\Users\\Hubert\\Desktop\\Image\\" + NickTextBox.Text.ToString() + licznik.ToString()+ ".txt";
            string wszystko = "";
            for(int i=0;i<27;i++)
            {
                wszystko += i.ToString() + ". " + profil[i] +"-"+ (char)(i+65) + Environment.NewLine;
            }
            while(File.Exists(fileName))
            {
                licznik++;
                fileName = "C:\\Users\\Hubert\\Desktop\\Image\\" + NickTextBox.Text.ToString() + licznik.ToString() + ".txt";
            }
        
            File.WriteAllText(fileName, wszystko);
           
        }
        private void ZatwierdzButton_Click(object sender, EventArgs e)
        {
            //liczSrednia();
            zapiszuzytkownika();
            zaktualizujBaze();
            generujPlik(); // dodanie do bazy
            ++iloscProbek;
            ClearTB();
        }

        private void zapiszuzytkownika()
        {
            string fileName = "C:\\Users\\Hubert\\Desktop\\Image\\uzytkownicy.txt";
            using (StreamReader file = new StreamReader(fileName))
            {
                string line;
                bool czyByluzytkownilk=false;
                string wszystko = "";
                
                while ((line = file.ReadLine()) != null)
                {
                    if(line == NickTextBox.Text.ToString())
                    {
                        czyByluzytkownilk= true;
                    }
                    wszystko += line+Environment.NewLine;
                }
                file.Close();
                if(!czyByluzytkownilk)
                {
                    wszystko += NickTextBox.Text.ToString();
                    File.WriteAllText("C:\\Users\\Hubert\\Desktop\\Image\\uzytkownicy.txt", wszystko);
                }
               
            }
        }

        private void zaktualizujBaze()
        {
            string fileName = "C:\\Users\\Hubert\\Desktop\\Image\\uzytkownicy.txt";
            string fileNameWektor = "C:\\Users\\Hubert\\Desktop\\Image\\wektorKlas.txt";
            using (StreamReader file = new StreamReader(fileName))
            {
                string line;
                int licznikKlas = 0;
                int numerklasy=0 ;

                while ((line = file.ReadLine()) != null)
                {          
                    
                    if (line == NickTextBox.Text.ToString()) numerklasy = licznikKlas;
                    licznikKlas++;
                }

                file.Close();

                File.AppendAllText(fileNameWektor, numerklasy.ToString()+" ");
                    klasy = new int[licznikKlas];
                for (int i = 0; i < klasy.Length; i++)
                {
                    klasy[i] = i;
                }
                
            }
        }
        private void CzastextBox_TextChanged(object sender, EventArgs e)
        {

        }
        //METRYKI
        private static double euklides(int[] x, int[] y) //pobrany i w bazie
        {
            double suma = 0;
            for (int i = 0; i < x.Length; i++)
            {
                suma += (x[i] - y[i]) * (x[i] - y[i]);
            }

            return Math.Sqrt(suma);
        }
        private static int manhatan(int[] x, int[] y) //pobrany i w bazie
        {
            int suma = 0;
            for (int i = 0; i < x.Length; i++)
            {
                suma +=Math.Abs(x[i] - y[i]);
            }

            return suma;
        }
        private static int czebyszew(int[] x, int[] y) //pobrany i w bazie
        {
            int suma = -1;
            for (int i = 0; i < x.Length; i++)
            {
                suma = Math.Max(suma,Math.Abs(x[i] - y[i]));
            }

            return suma;
        }
        private static double baycurtis(int[] x, int[] y) //pobrany i w bazie
        {
            double suma = 0, suma2=0;
            for (int i = 0; i < x.Length; i++)
            {
                suma += Math.Abs(x[i] - y[i]);
            }
            for (int i = 0; i < x.Length; i++)
            {
                suma2 += x[i] + y[i];
            }

            return suma/suma2;
        }
        private static int AA(int[] x, int[] y) //pobrany i w bazie
        {
            int suma = 0;
            for (int i = 0; i < x.Length; i++)
            {
                suma += Math.Abs(x[i] - y[i]);
            }

            return suma;
        }

        private int[] pobierzWektror(string plik)
        {
            int[] tmp=new int[27];
            int counter = 0;
            string fileName = plik;
            string wszystko = "";
            using (StreamReader file = new StreamReader(fileName))
            {
                string line;
                int pFrom;
                int pTo;

                while ((line=file.ReadLine())!=null)
                {
                    pFrom = line.IndexOf(" ") + " ".Length;
                    pTo = line.LastIndexOf("-");
                    tmp[counter++] = Int32.Parse(line.Substring(pFrom, pTo - pFrom));
                    wszystko +=Int32.Parse(line.Substring(pFrom, pTo - pFrom))+Environment.NewLine;
                }
                File.WriteAllText("C:\\Users\\Hubert\\Desktop\\Image\\TEST" + ".txt", wszystko);
            }

            return tmp;
        }

        

        private void sprawdz_Click(object sender, EventArgs e)
        {
            string[] klasy;
            int[] x = profil;
            
            string nickDoSprawdzenia;
            int[] y;
            int[] tmp = new int[8];
            int tmpLicznik1 = 0;
            int licznik = 0;
            string listaWektorow = "C:\\Users\\Hubert\\Desktop\\Image\\wektorKlas.txt";
            string uzytkownicy = "C:\\Users\\Hubert\\Desktop\\Image\\uzytkownicy.txt";
            using (StreamReader file = new StreamReader(listaWektorow))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {

                    line.TrimEnd();
                    klasy = line.Split(new char[] { ' ' });
                }
            }
            using (StreamReader file = new StreamReader(uzytkownicy))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    nickDoSprawdzenia = line;

                    string plikDoPorownania = "C:\\Users\\Hubert\\Desktop\\Image\\" + nickDoSprawdzenia + licznik.ToString() + ".txt";
                    while (File.Exists(plikDoPorownania))
                    {
                        y = pobierzWektror(plikDoPorownania);

                        int man = manhatan(x, y);
                        tmp[tmpLicznik1] = man;
                        licznik++;
                        tmpLicznik1++;
                        plikDoPorownania = "C:\\Users\\Hubert\\Desktop\\Image\\" + nickDoSprawdzenia + licznik.ToString() + ".txt";
                    }



                }
            }

            CzastextBox.Text = tmp[0].ToString() +" "+ tmp[1].ToString() + " " + tmp[2].ToString();
        }
    }
}
