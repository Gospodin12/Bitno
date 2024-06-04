using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace FlappyBirdIgra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Muzika muzika = new Muzika();
        double rezultat=0;
        int gravitacija=8;
        bool smrt;
        Rect FlapicHit;
        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += GlavnaFunkcija;
            timer.Interval =TimeSpan.FromMilliseconds(20);
            Start();
        }

        private void GlavnaFunkcija(object sender, EventArgs e)
        {
            Rezultat.Content = "Score: "+ rezultat;
            FlapicHit = new Rect(Canvas.GetLeft(ptica),Canvas.GetTop(ptica), ptica.Width,ptica.Height);
            Canvas.SetTop(ptica,Canvas.GetTop(ptica)+gravitacija);

            if(Canvas.GetTop(ptica)<-20 || Canvas.GetTop(ptica)>458)
            {
                GameOver();
            }

            foreach(var x in Kanvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "cev1" || (string)x.Tag == "cev2" || (string)x.Tag == "cev3")
                {
                    Rect CevHit = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if(CevHit.IntersectsWith(FlapicHit))
                        GameOver();
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5);
                    if (Canvas.GetLeft(x) < -100)
                    {
                        Canvas.SetLeft(x, 800);
                        rezultat++;
                        Rezultat.Content = "Score: "+rezultat;
                    }
                }
                if ((string)x.Tag == "oblak")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 2);
                    if (Canvas.GetLeft(x) < -200)
                        Canvas.SetLeft(x, 500);
                }


            }
        }
        private void TasterGore(object sender, KeyEventArgs e)
        {
                ptica.RenderTransform = new RotateTransform(5, ptica.Width / 2, ptica.Height / 2);
                gravitacija = 8;
        }
        private void TasterDole(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                ptica.RenderTransform = new RotateTransform(-20, ptica.Width/2,ptica.Height/2);
                gravitacija = -8;
            }
            if (e.Key == Key.R && smrt == true)
                Start();
        }
        private void Start()
        {
            muzika.Pusti();
            Kanvas.Focus();
            rezultat = 0;
            smrt = false;
            Canvas.SetTop(ptica, 190);
            ptica.Source = new BitmapImage(new Uri(@"images/flappyBird.png", UriKind.Relative));

            foreach (var x in Kanvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "cev1")
                    Canvas.SetLeft(x, 500);
                if ((string)x.Tag == "cev2")
                    Canvas.SetLeft(x, 800);
                if ((string)x.Tag == "cev3")
                    Canvas.SetLeft(x, 1100);
            }
            timer.Start();
        }
        private void GameOver()
        {
            muzika.PustiDugo();

            timer.Stop();
            ptica.Source = new BitmapImage(new Uri(@"images/flappyBird2.png", UriKind.Relative));
            smrt = true;
            Rezultat.Content += "  -  Kraj igre! Pritisnite R da nastavite.";

        }
    }
}
