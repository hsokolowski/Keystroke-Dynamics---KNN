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
        string iloscProbekTxt = "C:\\Biometria\\iloscProbek.txt";
        string iloscUzytkownikowTxt = "C:\\Biometria\\iloscUzytkownikow.txt";
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
            for (int i = 0; i < iloscProbek; i++)
            {
                //klasy[i] = -1;
                //if (i < 10) nicki[i] = " ";
            }
           
            using (StreamReader file = new StreamReader(iloscProbekTxt))
            {
                string ilosc;
                while ((ilosc = file.ReadLine()) != null)
                {

                    CzastextBox.Text = ilosc;
                    iloscProbek = Convert.ToInt32(ilosc);
                    
                }
                file.Close();
            }
            using (StreamReader file = new StreamReader(iloscUzytkownikowTxt))
            {
                string ilosc;
                while ((ilosc = file.ReadLine()) != null)
                {

                    CzastextBox.Text = ilosc;
                    iloscUzytkownikow = Convert.ToInt32(ilosc);

                }
                file.Close();
            }
            infoDoKLabel.Text = "Max: " + iloscProbek;
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
                infoDoKLabel.Text = "Max: " + iloscProbek;
                File.WriteAllText("C:\\Biometria\\iloscUzytkownikow.txt",iloscUzytkownikow.ToString());
                File.WriteAllText("C:\\Biometria\\iloscProbek.txt", iloscProbek.ToString());
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
                    iloscUzytkownikow++;
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
        private static int euklides(int[] x, int[] y) //pobrany i w bazie
        {
            double suma = 0;
            for (int i = 0; i < x.Length; i++)
            {
                suma += (x[i] - y[i]) * (x[i] - y[i]);
            }

            return (int)Math.Sqrt(suma);
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
        int iloscMax;
        private int zbadajListeTupli(List<Tuple<int, int>> lista)
        {
            int[] doWyboruNajlepszego = new int[iloscUzytkownikow];
            int indeks=0;
            int max=-1,maxindeks=0;
            iloscMax = 0;
            int k =Convert.ToInt32(KtextBOx.Text);
            int[] tmp = new int[iloscUzytkownikow];
            for (int i=0; i< iloscUzytkownikow; i++) // zerujemy tablice ktora zlicza ilosc wystopienia klas
            {
                tmp[i] = 0;
            }
            for(int i=0; i< k; i++) // tu ustalamy nasze k
            {
                tmp[lista[i].Item2]++;
            }

            for (int i = 0; i < iloscUzytkownikow; i++) // sprawdzamy ktora klasa najczesniej wystapila
            {
                if (tmp[i] > max) {

                    max = tmp[i];
                    maxindeks = i;
                }
               
            }
            for (int i = 0; i < iloscUzytkownikow; i++) // sprawdzamy czy sie powtarza
            {
                if (tmp[i] == max) iloscMax++;
            }
                indeks = maxindeks;
            int maxIndekPoPowtorzeniu=0, minPoPowtorzeniu=9999999;
            if (iloscMax > 1)
            {
                
                for (int i = 0; i < iloscUzytkownikow; i++) 
                {
                    doWyboruNajlepszego[i] = -1;
                }
               for (int i = 0; i < iloscUzytkownikow; i++)
                {
                    if(tmp[i]==max)
                    {
                        for (int j=0; j<k; j++)
                        {
                            if(lista[j].Item2==i)
                            {
                                if (lista[j].Item1 == 0) doWyboruNajlepszego[i] += 1;
                                doWyboruNajlepszego[i] += lista[j].Item1;
                            }
                        }
                    }
                }
                for (int i = 0; i < iloscUzytkownikow; i++) 
                {
                    if (doWyboruNajlepszego[i] < minPoPowtorzeniu && doWyboruNajlepszego[i]!=-1)
                    {

                        minPoPowtorzeniu = doWyboruNajlepszego[i];
                        maxIndekPoPowtorzeniu = i;
                    }

                }

                indeks = maxIndekPoPowtorzeniu;
            }
                return indeks;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Zbadaj_Click(object sender, EventArgs e)
        
        {
            string[] klasy = { };
            int[] x = profil;
            int indeksUzytkownikaMan, indeksUzytkownikaEuk, indeksUzytkownikaCze, indeksUzytkownikaBay;
            List<Tuple<int, int>> listaDosprawdzeniaMan, listaDosprawdzeniaEuk, listaDosprawdzeniaCze,listaDosprawdzeniaBay;
            string nickDoSprawdzenia;
            int[] y;
            int[] nazwyKlas = new int[iloscProbek];
            int[] odleglosciMan = new int[iloscProbek], odleglosciEuk = new int[iloscProbek], odleglosciCze = new int[iloscProbek], odleglosciBay = new int[iloscProbek];
            int jakoscMan = 0, jakoscEuk = 0, jakoscCze = 0,iloscDoJakosci=0, jakoscBay=0;
            double jakoscManP, jakoscEukP, jakoscCzeP, jakoscBayP;
            int kursorDoTablicy = 0;
            int licznikDoNicku = 0;
            string listaWektorow = "C:\\Biometria\\wektorKlas.txt";
            string uzytkownicy = "C:\\Biometria\\uzytkownicy.txt";
            int licznikDoPobieraniaX = 0;
            string nickDoX;
            string plikdoX;
            
         
               // x = pobierzWektror("C:\\Biometria\\SZYMON0.txt");
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

                using (StreamReader file2 = new StreamReader(uzytkownicy))
                {
                    string liniaPlikuUzytkownicyX;
                while ((liniaPlikuUzytkownicyX = file2.ReadLine()) != null)
                {
                    nickDoX = liniaPlikuUzytkownicyX;
                    plikdoX = "C:\\Biometria\\" + nickDoX + licznikDoPobieraniaX.ToString() + ".txt";
                    while (File.Exists(plikdoX))
                    {
                        x = pobierzWektror(plikdoX);
                        licznikDoPobieraniaX++;
                       // plikdoX = "C:\\Biometria\\" + nickDoX + licznikDoPobieraniaX.ToString() + ".txt";
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
                                    if (plikdoX == "C:\\Biometria\\MICHU2.txt")
                                    { int aaaa = 0; }

                                    int man = manhatan(x, y);
                                        odleglosciMan[kursorDoTablicy] = man;
                                        //odleglosciBay[kursorDoTablicy] = baycurtis(x, y);
                                        odleglosciCze[kursorDoTablicy] = czebyszew(x, y);
                                        odleglosciEuk[kursorDoTablicy] = euklides(x, y);
                                        licznikDoNicku++;
                                        kursorDoTablicy++;
                                    
                                        plikDoPorownania = "C:\\Biometria\\" + nickDoSprawdzenia + licznikDoNicku.ToString() + ".txt";
                                    
                                }
                                licznikDoNicku = 0;



                            }
                            for (int i = 0; i < klasy.Length ; i++)
                            {
                                nazwyKlas[i] = System.Convert.ToInt32(klasy[i]);
                            }
                            file.Close();
                        }
                        if (plikdoX == "C:\\Biometria\\MICHU2.txt")
                        { int aaaa = 0; }
                        listaDosprawdzeniaMan = stworzListeTupli(odleglosciMan, nazwyKlas);
                        indeksUzytkownikaMan = zbadajListeTupli(listaDosprawdzeniaMan);
                        if (plikdoX == "C:\\Biometria\\MICHU2.txt")
                        { int aaaa = 0; }
                        listaDosprawdzeniaCze = stworzListeTupli(odleglosciCze, nazwyKlas);
                        indeksUzytkownikaCze = zbadajListeTupli(listaDosprawdzeniaCze);

                        listaDosprawdzeniaEuk = stworzListeTupli(odleglosciEuk, nazwyKlas);
                        indeksUzytkownikaEuk = zbadajListeTupli(listaDosprawdzeniaEuk);

                        string nickWybranyMan = "", nickWybranyCze = "", nickWybranyEuk = "";
                        int licznikDoWybraniaNicku = 0;
                        using (StreamReader file = new StreamReader(uzytkownicy))
                        {
                            string liniaPlikuWektor;
                            while ((liniaPlikuWektor = file.ReadLine()) != null)
                            {
                                if (licznikDoWybraniaNicku == indeksUzytkownikaMan) nickWybranyMan = liniaPlikuWektor;
                                if (licznikDoWybraniaNicku == indeksUzytkownikaEuk) nickWybranyEuk = liniaPlikuWektor;
                                if (licznikDoWybraniaNicku == indeksUzytkownikaCze) nickWybranyCze = liniaPlikuWektor;
                                licznikDoWybraniaNicku++;


                            }
                        }
                        // CzastextBox.Text = "Man: " + nickWybranyMan + " Euk: " + nickWybranyEuk + " Cze: " + nickWybranyCze;
                        
                        if (nickDoX == nickWybranyMan) jakoscMan++;
                        if (nickDoX == nickWybranyEuk) jakoscEuk++;
                        if (nickDoX == nickWybranyCze) jakoscCze++;
                        iloscDoJakosci++;
                        jakoscCzeP =(double) jakoscCze / iloscDoJakosci;
                        jakoscEukP = (double)jakoscEuk / iloscDoJakosci;
                        jakoscManP = (double)jakoscMan / iloscDoJakosci;
                        jakoscCzeP = Math.Round(jakoscCzeP, 2);
                        jakoscEukP = Math.Round(jakoscEukP, 2);
                        jakoscManP = Math.Round(jakoscManP,2);
                        CzastextBox.Text = "Man: " + jakoscManP + " Euk: " + jakoscEukP + " Cze: " + jakoscCzeP+"Ilosc "+iloscDoJakosci;
                       
                        kursorDoTablicy = 0;
                        plikdoX = "C:\\Biometria\\" + nickDoX + licznikDoPobieraniaX.ToString() + ".txt";
                    }
                    licznikDoPobieraniaX = 0;
                }
            }
            int a = 0;
        }
        

        private void sprawdz_Click(object sender, EventArgs e)
        {
            string[] klasy= { };
            int[] x = profil;
            int indeksUzytkownikaMan, indeksUzytkownikaEuk, indeksUzytkownikaCze;
            List<Tuple<int, int>> listaDosprawdzeniaMan, listaDosprawdzeniaEuk, listaDosprawdzeniaCze;
            string nickDoSprawdzenia;
            int[] y;
            int[] nazwyKlas=new int[iloscProbek];
            int[] odleglosciMan = new int[iloscProbek], odleglosciEuk = new int[iloscProbek], odleglosciCze = new int[iloscProbek];
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
                        odleglosciMan[kursorDoTablicy] = man;
                        odleglosciCze[kursorDoTablicy] = czebyszew(x, y);
                        odleglosciEuk[kursorDoTablicy] = euklides(x, y);
                        licznikDoNicku++;
                        kursorDoTablicy++;
                        plikDoPorownania = "C:\\Biometria\\" + nickDoSprawdzenia + licznikDoNicku.ToString() + ".txt";
                    }
                    licznikDoNicku = 0;



                }
                for (int i=0; i<klasy.Length; i++)
                {
                    nazwyKlas[i] = System.Convert.ToInt32(klasy[i]);
                }
                file.Close();
            }
            listaDosprawdzeniaMan = stworzListeTupli(odleglosciMan,nazwyKlas);
            indeksUzytkownikaMan=zbadajListeTupli(listaDosprawdzeniaMan);

            listaDosprawdzeniaCze = stworzListeTupli(odleglosciCze, nazwyKlas);
            indeksUzytkownikaCze = zbadajListeTupli(listaDosprawdzeniaCze);

            listaDosprawdzeniaEuk = stworzListeTupli(odleglosciEuk, nazwyKlas);
            indeksUzytkownikaEuk = zbadajListeTupli(listaDosprawdzeniaEuk);
            
            string nickWybranyMan="", nickWybranyCze="", nickWybranyEuk="";
            int licznikDoWybraniaNicku = 0;
            using (StreamReader file = new StreamReader(uzytkownicy))
            {
                string liniaPlikuWektor;
                while ((liniaPlikuWektor = file.ReadLine()) != null)
                {
                    if (licznikDoWybraniaNicku == indeksUzytkownikaMan) nickWybranyMan = liniaPlikuWektor;
                    if (licznikDoWybraniaNicku == indeksUzytkownikaEuk) nickWybranyEuk = liniaPlikuWektor;
                    if (licznikDoWybraniaNicku == indeksUzytkownikaCze) nickWybranyCze = liniaPlikuWektor;
                    licznikDoWybraniaNicku++;
                    
                    
                }
            }
            CzastextBox.Text = "Man: "+nickWybranyMan+" Euk: "+nickWybranyEuk+" Cze: "+nickWybranyCze;
        }
    }
}
