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
    /// <summary>x
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : MetroWindow
    {
        public int currentbestand;
        public int artikelid;
        public string artikelname;
        public int ValueS;
        public static int i2 = 0;

        static CultureInfo ci = new CultureInfo("de-DE");
        static SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);

        MainWindow mainwindow = new MainWindow();

        public Window1(int currentbestand, int artikelid, string artikelname)
        {
            InitializeComponent();
            mainwindow.Form1_Load1();            

            if (i2 != 0)
            {
                sre.RecognizeAsyncCancel();

                i2++;
            }

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
            foreach (KeyValuePair<string, int> pair in mainwindow.textNumber)
            {
                ch_Stck.Add(pair.Key.ToString());
            }
            GrammarBuilder gb_result = new GrammarBuilder(ch_Stck);
            Grammar g_result = new Grammar(gb_result);
            return g_result;
        }

        public void sre_SpeechRecognized(object sender,
          SpeechRecognizedEventArgs e)
        {


            string txt = e.Result.Text;
            float conf = e.Result.Confidence;
            if (conf < 0.65) return;

            if (mainwindow.textNumber.ContainsKey(txt))
            {
                int value = mainwindow.textNumber[txt];
                ValueS = value;

                this.Dispatcher.Invoke(() =>
                {
                    Einlager_Menge.Text = ValueS.ToString();

                }); // WinForm specific
                    //  Console.WriteLine(value);
            } else if (txt.Equals("weiter") && Einlager_Menge.Text != "") {
                i2++;
                sre.RecognizeAsyncCancel();
                btnWeiter.Background = new SolidColorBrush(Colors.LightSkyBlue);
                MainWindow.Wait(0.3);
                btnWeiter.Background = new SolidColorBrush(Colors.White);

                int counter = currentbestand + ValueS;


               
               SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Oguzhan\Documents\GitHub\Speer\WpfApplication1\LagerDB.mdf;Integrated Security=True");
                try
                {
                    con.Open();
                    string Query = "update Artikel set bestand='" + counter + "' where id='" + artikelid + "' ";
                    SqlCommand createCommand = new SqlCommand(Query, con);
                    createCommand.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                EinlagerPop EPop = new EinlagerPop();
                EPop.Show();
                MainWindow.Wait(7.1);
                EPop.Close();


                MainWindow Main = new MainWindow();
                Main.Show();
                this.Hide();

            }else if (txt.Equals("zurück"))
                {
                    i2++;
                    sre.RecognizeAsyncCancel();
                    btnZurück.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    MainWindow.Wait(0.3);
                    btnZurück.Background = new SolidColorBrush(Colors.White);
                    MainWindow Main = new MainWindow();
                    Main.Show();
                    this.Close();
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