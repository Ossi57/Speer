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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Speech.Recognition;
using System.Globalization;
using MahApps.Metro.Controls;
using System.Threading;
using System.Windows.Threading;
using System.Data;
using System.Data.SqlClient;

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        //initalize SpeechRecognizer
        static CultureInfo ci = new CultureInfo("de-DE");
        static SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);

        bool selected = false;

        public int currbestand { get; set; }
        public int artikelid { get; set; }
        public string artikelname { get; set; }

        public Dictionary<string, int> textNumber;

        public MainWindow()
        {


            InitializeComponent();
            LoadDataGrid();
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += sre_SpeechRecognized;
            Grammar g_HelloGoodbye = GetHelloGoodbyeGrammar();
            sre.LoadGrammarAsync(g_HelloGoodbye);
            sre.RecognizeAsync(RecognizeMode.Multiple);
                                           
        }

        public void Form1_Load1()
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

        public void LoadDataGrid()
        {
            
            //String path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //MessageBox.Show(path);      

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Oguzhan\Documents\GitHub\Speer\WpfApplication1\LagerDB.mdf;Integrated Security=True");
            SqlDataAdapter Query = new SqlDataAdapter(@"SELECT Id, artikelname, bestand FROM Artikel", con);
            DataTable dt = new DataTable();

            Query.Fill(dt);

            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        static Grammar GetHelloGoodbyeGrammar()
        {
            Choices ch_HelloGoodbye = new Choices();
            ch_HelloGoodbye.Add("Einlagern");
            ch_HelloGoodbye.Add("Auslagern");
            GrammarBuilder gb_result =
              new GrammarBuilder(ch_HelloGoodbye);
            Grammar g_result = new Grammar(gb_result);
            return g_result;
        }

        void sre_SpeechRecognized(object sender,
          SpeechRecognizedEventArgs e)
        {

            string txt = e.Result.Text;
            float conf = e.Result.Confidence;
            if (conf < 0.65) return;

            if (txt != null)
            {
                if (txt.Equals("Einlagern") && selected == true)
                {
                    sre.RecognizeAsyncCancel();
                    btnEinlagern.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    Wait(0.3);
                    btnEinlagern.Background = new SolidColorBrush(Colors.White);
                    Window1 Einlagern = new Window1(currbestand,artikelid,artikelname);
                    Einlagern.Show();
                    this.Close();
                    

                }
                else if (txt.Equals("Auslagern") && selected == true)
                {
                    sre.RecognizeAsyncCancel();

                    btnAuslagern.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    Wait(0.5);
                    btnAuslagern.Background = new SolidColorBrush(Colors.White);
                    Window2 Auslagern = new Window2(currbestand, artikelid, artikelname);
                    Auslagern.Show();
                    this.Close();
                    
                }
            }
        }

        public static void Wait(double seconds)
        {
            var frame = new DispatcherFrame();
            new Thread((ThreadStart)(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(seconds));
                frame.Continue = false;
            })).Start();
            Dispatcher.PushFrame(frame);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected = true;

            DataRowView oDataRowView = dataGrid1.SelectedItem as DataRowView;
            string sValue = string.Empty;

            if (oDataRowView != null)
            {
                artikelid = (int)oDataRowView.Row["Id"];
                artikelname = oDataRowView.Row["artikelname"] as string;
                currbestand = (int)oDataRowView.Row["bestand"];
            }
        }
    }
}