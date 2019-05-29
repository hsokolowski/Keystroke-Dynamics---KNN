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
            literkiErrorLabel.Visible = false;
            errorLabel.Visible = false;
            motywujacyLabel.Text = "DOBRZE CI IDZIE";
            if(haslo.Length==WpisywanieTextBox.Text.Length)
            {
                liczSrednia();
            }
            if(WpisywanieTextBox.Text.Length!=0 && WpisywanieTextBox.Text[WpisywanieTextBox.Text.Length-1]!=haslo[WpisywanieTextBox.Text.Length-1])
            {
                ClearTB();
                errorLabel.Visible = true;
                motywujacyLabel.Visible = false;
            }
            else
            {
                errorLabel.Visible = false;
                motywujacyLabel.Visible = true;
            }
        }
        private void ClearTB()
        {
            WpisywanieTextBox.Text = "";
            
            for (int i = 0; i < 27; i++)
            {
                profil[i] = 0;
                profilLicznik[i] = 0;
            }
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
            string fileName = "C:\\Biometria\\" + NickTextBox.Text.ToString() + licznik.ToString()+ ".txt";
            string wszystko = "";
            for(int i=0;i<27;i++)
            {
                wszystko += i.ToString() + ". " + profil[i] +"-"+ (char)(i+65) + Environment.NewLine;
            }
            while(File.Exists(fileName))
            {
                licznik++;
                fileName = "C:\\Biometria\\" + NickTextBox.Text.ToString() + licznik.ToString() + ".txt";
            }
        
            File.WriteAllText(fileName, wszystko);
           
        }
        int[] iloscLiter = { 3, 1, 0, 0, 3, 0, 0, 0, 2, 2, 0, 1, 1, 1, 1, 1, 0, 1, 2, 2, 0, 0, 0, 0, 0, 1, 2 };
        private bool sprawdzPrzyciski()
        {
            for (int i = 0; i < 27; i++)
            {
                if (profilLicznik[i] != iloscLiter[i]) return false;
            }
            return true;
        }
        private void ZatwierdzButton_Click(object sender, EventArgs e)
        {
            liczSrednia();
            if (sprawdzPrzyciski())
            {
                zapiszuzytkownika();
                zaktualizujBaze();
                generujPlik(); // dodanie do bazy
                ++iloscProbek;
                ClearTB();
                motywujacyLabel.Text = "Elegancko";

            }
            else
            {
                ClearTB();
                motywujacyLabel.Visible = false;
                literkiErrorLabel.Visible = true;
            }
    }

        private void zapiszuzytkownika()
        {
            string fileName = "C:\\Biometria\\uzytkownicy.txt";
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
                    File.WriteAllText("C:\\Biometria\\uzytkownicy.txt", wszystko);
                }
               
            }
        }

        private void zaktualizujBaze()
        {
            string fileName = "C:\\Biometria\\uzytkownicy.txt";
            string fileNameWektor = "C:\\Biometria\\wektorKlas.txt";
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
                File.WriteAllText("C:\\Biometria\\TEST" + ".txt", wszystko);
            }

            return tmp;
        }

        private List<Tuple<int, int>> stworzListeTupli(int[] odleglosci, int[] nazwy)
        {
            var tupleList = new List<Tuple<int, int>>{    };
           
            for (int i=0; i<odleglosci.Length;i++)
            {
                tupleList.Add(Tuple.Create(odleglosci[i], nazwy[i]));

            }
            tupleList.Sort();
            int a = 0;
            return tupleList;
        }
        private int zbadajListeTupli(List<Tuple<int, int>> lista)
        {
            int indeks=0;
            int max=-1,maxindeks=0;

            int[] tmp = new int[10];
            for (int i=0; i<10; i++)
            {
                tmp[i] = 0;
            }
            for(int i=0; i<10; i++)
            {
                tmp[lista[i].Item2]++;
            }

            for (int i = 0; i < 10; i++)
            {
                if (tmp[i] > max) {

                    max = tmp[i];
                    maxindeks = i;
                }

            }

            indeks = maxindeks;
                return indeks;

        }
        private void sprawdz_Click(object sender, EventArgs e)
        {
            string[] klasy= { };
            int[] x = profil;
            int indeksUzytkownika;
            List<Tuple<int, int>> listaDosprawdzenia;
            string nickDoSprawdzenia;
            int[] y;
            int[] nazwyKlas=new int[30];
            int[] odleglosci = new int[30];
            int kursorDoTablicy = 0;
            int licznikDoNicku = 0;
            string listaWektorow = "C:\\Biometria\\wektorKlas.txt";
            string uzytkownicy = "C:\\Biometria\\uzytkownicy.txt";
            using (StreamReader file = new StreamReader(listaWektorow))
            {
                string liniaPlikuWektor;
                while ((liniaPlikuWektor = file.ReadLine()) != null)
                {

                    liniaPlikuWektor.TrimEnd();
                    klasy = liniaPlikuWektor.Split(new char[] { ' ' });
                }
                file.Close();
            }
           
            using (StreamReader file = new StreamReader(uzytkownicy))
            {
                string liniaPlikuUzytkownicy;

                while ((liniaPlikuUzytkownicy = file.ReadLine()) != null)
                {
                    nickDoSprawdzenia = liniaPlikuUzytkownicy;

                    string plikDoPorownania = "C:\\Biometria\\" + nickDoSprawdzenia + licznikDoNicku.ToString() + ".txt";
                    while (File.Exists(plikDoPorownania))
                    {
                        y = pobierzWektror(plikDoPorownania);

                        int man = manhatan(x, y);
                        odleglosci[kursorDoTablicy] = man;
                        licznikDoNicku++;
                        kursorDoTablicy++;
                        plikDoPorownania = "C:\\Biometria\\" + nickDoSprawdzenia + licznikDoNicku.ToString() + ".txt";
                    }
                    licznikDoNicku = 0;



                }
                for (int i=0; i<klasy.Length-1; i++)
                {
                    nazwyKlas[i] = System.Convert.ToInt32(klasy[i]);
                }
                file.Close();
            }
            listaDosprawdzenia = stworzListeTupli(odleglosci,nazwyKlas);
            indeksUzytkownika=zbadajListeTupli(listaDosprawdzenia);
            string nickWybrany="";
            int licznikDoWybraniaNicku = 0;
            using (StreamReader file = new StreamReader(uzytkownicy))
            {
                string liniaPlikuWektor;
                while ((liniaPlikuWektor = file.ReadLine()) != null)
                {
                    if (licznikDoWybraniaNicku == indeksUzytkownika) nickWybrany = liniaPlikuWektor;
                    licznikDoWybraniaNicku++;
                    
                    
                }
            }
            CzastextBox.Text = nickWybrany;
        }
    }
}
