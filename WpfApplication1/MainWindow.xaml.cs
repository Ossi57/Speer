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

namespace WpfApplication1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        //initalize SpeechRecognizer
        static int[] array = Enumerable.Range(1, 100).ToArray();
        static CultureInfo ci = new CultureInfo("de-DE");
        static SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);

        bool selected = false;

        public int currbestand { get; set; }
        public int artikelid { get; set; }
        public string artikelname { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += sre_SpeechRecognized;
            Grammar g_HelloGoodbye = GetHelloGoodbyeGrammar();
            sre.LoadGrammarAsync(g_HelloGoodbye);
            sre.RecognizeAsync(RecognizeMode.Multiple);

         


            LagerDBEntities1 dataEntities = new LagerDBEntities1();          
            var query =
                from product in dataEntities.Artikel
                select new { product.Id, product.artikelname, product.bestand };            
            dataGrid1.ItemsSource = query.ToList();            
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

        /*
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox2.Checked == true)
                sre.RecognizeAsync(RecognizeMode.Multiple);
            else if (checkBox2.Checked == false) // Turn off
                sre.RecognizeAsyncCancel();
                
        }
        */

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
                    this.Hide();
                    

                }
                else if (txt.Equals("Auslagern") && selected == true)
                {
                    sre.RecognizeAsyncCancel();

                    btnAuslagern.Background = new SolidColorBrush(Colors.LightSkyBlue);
                    Wait(0.5);
                    btnAuslagern.Background = new SolidColorBrush(Colors.White);
                    Window2 Auslagern = new Window2(currbestand, artikelid, artikelname);
                    Auslagern.Show();                   
                    this.Hide();
                    
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
            var dg = sender as DataGrid;
            if (dg == null) return;
            var index = dg.SelectedIndex;
            //here we get the actual row at selected index
            DataGridRow row = dg.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;

            //here we get the actual data item behind the selected row

            var item = dg.ItemContainerGenerator.ItemFromContainer(row);

            string[] meineStrings = item.ToString().Split(new Char[] { ',', '=', '}' });



            artikelid = Int32.Parse(meineStrings[1]);
            artikelname = meineStrings[3];
            currbestand = Int32.Parse(meineStrings[5]);



            //MessageBox.Show(artikelname.ToString());



            //MessageBox.Show(item.ToString().Trim(new Char[] { '{', '}', }));
        }
    }
}


    

