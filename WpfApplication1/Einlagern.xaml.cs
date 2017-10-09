using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Speech.Recognition;
using System.Globalization;
using MahApps.Metro.Controls;
using System.Data.SqlClient;

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : MetroWindow
    {
        static int[] array = Enumerable.Range(1, 100).ToArray();

        public int currentbestand;
        public int artikelid;
        public string artikelname;
        public int ValueS;

        static CultureInfo ci = new CultureInfo("de-DE");
        static SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);

        public Dictionary<string, int> textNumber;


        public Window1(int currentbestand, int artikelid, string artikelname)
        {
            InitializeComponent();
            Form1_Load1();
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += sre_SpeechRecognized;
            Grammar g_HelloGoodbye = GetHelloGoodbyeGrammar();
            Grammar g_stckZ = getStückzahl();
            sre.LoadGrammarAsync(g_HelloGoodbye);
            sre.LoadGrammarAsync(g_stckZ);
            sre.RecognizeAsync(RecognizeMode.Multiple);
            this.currentbestand = currentbestand;
            this.artikelid = artikelid;
            // sre.RecognizeAsync() is in CheckBox event

            ArtikelNrIns.Text = artikelid.ToString();
            ArtikelNameIns.Text = artikelname;
            StuckzahlIns.Text = currentbestand.ToString();
            //MessageBox.Show(currentbestand +" , "+artikelid+" , "+artikelname);
        }

    private void Form1_Load1()
        {
            textNumber = new Dictionary<string, int>();
            textNumber.Add("eins", 1);
            textNumber.Add("zwei", 2);
            textNumber.Add("drei", 3);
            textNumber.Add("vier", 4);
            textNumber.Add("fünf", 5);
            textNumber.Add("sechs", 6);
            textNumber.Add("sieben", 7);
            textNumber.Add("acht", 8);
            textNumber.Add("neun", 9);
            textNumber.Add("zehn", 10);
            textNumber.Add("elf", 11);
            textNumber.Add("zwölf", 12);
            textNumber.Add("dreizehn", 13);
            textNumber.Add("vierzehn", 14);
            textNumber.Add("fünfzehn", 15);
            textNumber.Add("sechszehn", 16);
            textNumber.Add("siebzehn", 17);
            textNumber.Add("achtzehn", 18);
            textNumber.Add("neunzehn", 19);
            textNumber.Add("zwanzig", 20);
            textNumber.Add("einundzwanzig", 21);
            textNumber.Add("zweiundzwanzig", 22);
            textNumber.Add("dreiundzwanzig", 23);
            textNumber.Add("vierundzwanzig", 24);
            textNumber.Add("fünfundzwanzig", 25);
            textNumber.Add("sechsundzwanzig", 26);
            textNumber.Add("siebenundzwanzig", 27);
            textNumber.Add("achtundzwanzig", 28);
            textNumber.Add("neunundzwanzig", 29);
            textNumber.Add("dreißig", 30);
            textNumber.Add("einunddreißig", 31);
            textNumber.Add("zweiunddreißig", 32);
            textNumber.Add("dreiunddreißig", 33);
            textNumber.Add("vierunddreißig", 34);
            textNumber.Add("fünfunddreißig", 35);
            textNumber.Add("sechsunddreißig", 36);
            textNumber.Add("siebenunddreißig", 37);
            textNumber.Add("achtunddreißig", 38);
            textNumber.Add("neununddreißig", 39);
            textNumber.Add("vierzig", 40);
            textNumber.Add("einundvierzig", 41);
            textNumber.Add("zweiundvierzig", 42);
            textNumber.Add("dreiundvierzig", 43);
            textNumber.Add("vierundvierzig", 44);
            textNumber.Add("fünfundvierzig", 45);
            textNumber.Add("sechsundvierzig", 46);
            textNumber.Add("siebenundvierzig", 47);
            textNumber.Add("achtundvierzig", 48);
            textNumber.Add("neunundvierzig", 49);
            textNumber.Add("fünfzig", 50);
            textNumber.Add("einundfünfzig", 51);
            textNumber.Add("zweiundfünfzig", 52);
            textNumber.Add("dreiundfünfzig", 53);
            textNumber.Add("viersundfünfzig", 54);
            textNumber.Add("Fünfundfünfzig", 55);
            textNumber.Add("sechsundfünfzig", 56);
            textNumber.Add("siebenundfünfzig", 57);
            textNumber.Add("achtundfünfzig", 58);
            textNumber.Add("neunundfünfzig", 59);
            textNumber.Add("sechzig", 60);
            textNumber.Add("einundsechzig", 61);
            textNumber.Add("zweiundsechzig", 62);
            textNumber.Add("dreiundsechzig", 63);
            textNumber.Add("viersundsechzig", 64);
            textNumber.Add("fünfundsechzig", 65);
            textNumber.Add("sechsundsechzig", 66);
            textNumber.Add("siebenundsechzig", 67);
            textNumber.Add("achtundsechzig", 68);
            textNumber.Add("neunundsechzig", 69);
            textNumber.Add("siebzig", 70);
            textNumber.Add("einundsiebzig", 71);
            textNumber.Add("zweiundsiebzig", 72);
            textNumber.Add("dreiundsiebzig", 73);
            textNumber.Add("vierundsiebzig", 74);
            textNumber.Add("fünfundsiebzig", 75);
            textNumber.Add("sechsundsiebzig", 76);
            textNumber.Add("siebenundsiebzig", 77);
            textNumber.Add("achtundsiebzig", 78);
            textNumber.Add("neunundsiebzig", 79);
            textNumber.Add("achtzig", 80);
            textNumber.Add("einundachtzig", 81);
            textNumber.Add("zweiundachtzig", 82);
            textNumber.Add("dreiundachtzig", 83);
            textNumber.Add("vierundachtzig", 84);
            textNumber.Add("fünfundachtzig", 85);
            textNumber.Add("sechsundachtzig", 86);
            textNumber.Add("siebenundachtzig", 87);
            textNumber.Add("achtundachtzig", 88);
            textNumber.Add("neunundachtzig", 89);
            textNumber.Add("Neunzig", 90);
            textNumber.Add("einundneunzig", 91);
            textNumber.Add("Zweiundneunzig", 92);
            textNumber.Add("dreiundneunzig", 93);
            textNumber.Add("vierundneunzig", 94);
            textNumber.Add("fünfundneunzig", 95);
            textNumber.Add("sechsundneunzig", 96);
            textNumber.Add("siebenundneunzig", 97);
            textNumber.Add("achtundneunzig", 98);
            textNumber.Add("neunundneunzig", 99);
            textNumber.Add("hundert", 100);
        }

        static Grammar GetHelloGoodbyeGrammar()
        {
            Choices ch_HelloGoodbye = new Choices();
            ch_HelloGoodbye.Add("zurück");
            ch_HelloGoodbye.Add("weiter");
            GrammarBuilder gb_result =
              new GrammarBuilder(ch_HelloGoodbye);
            Grammar g_result = new Grammar(gb_result);
            return g_result;
        }


        public Grammar getStückzahl()
        {
            Choices ch_Stck = new Choices();
            foreach (KeyValuePair<string, int> pair in textNumber)
            {
                ch_Stck.Add(pair.Key.ToString());
            }
            GrammarBuilder gb_result = new GrammarBuilder(ch_Stck);
            Grammar g_result = new Grammar(gb_result);
            return g_result;
        }

        private void getValues()
        {
           
        }

        /*
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox2.Checked == true)
                sre.RecognizeAsync(RecognizeMode.Multiple);
            else if (checkBox2.Checked == false) // Turn off
                sre.RecognizeAsyncCancel();
                
        }
        */



        public void sre_SpeechRecognized(object sender,
          SpeechRecognizedEventArgs e)
        {


            string txt = e.Result.Text;
            float conf = e.Result.Confidence;
            if (conf < 0.65) return;

            if (textNumber.ContainsKey(txt))
            {
                int value = textNumber[txt];
                ValueS = value;

                this.Dispatcher.Invoke(() =>
                {
                    Einlager_Menge.Text = ValueS.ToString();
                    
                }); // WinForm specific
                    //  Console.WriteLine(value);
            }
            else
            {
                if (txt.Equals("weiter"))
                {
                    sre.RecognizeAsyncCancel();
                    btnWeiter.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    MainWindow.Wait(0.3);
                    btnWeiter.Background = new SolidColorBrush(Colors.White);                   
                                    
                    int counter = currentbestand + ValueS;
                    


                    SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Oguzhan\Documents\GitHub\Speer\WpfApplication1\LagerDB.mdf; Integrated Security = True");
                    try
                    {
                        con.Open();
                        string Query = "update Artikel set bestand='" + counter + "' where id='" + artikelid + "' ";
                        SqlCommand createCommand = new SqlCommand(Query, con);
                        createCommand.ExecuteNonQuery();
                        //MessageBox.Show("abcd");
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    MainWindow Main = new MainWindow();
                    Main.Show();
                    this.Hide();

                }
                else if (txt.Equals("zurück"))
                {
                    sre.RecognizeAsyncCancel();
                    btnZurück.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    MainWindow.Wait(0.3);
                    btnZurück.Background = new SolidColorBrush(Colors.White);
                    MainWindow Main = new MainWindow();
                    Main.Show();
                    this.Hide();
                }
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEinlagern_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}