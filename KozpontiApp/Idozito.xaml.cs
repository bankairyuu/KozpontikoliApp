using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace KozpontiApp
{
    /// <summary>
    /// Interaction logic for Idozito.xaml
    /// </summary>
    public partial class Idozito : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        int time = 0;
        int hours = 0;
        int minutes = 0;
        int seconds = 0;

        public Idozito()
        {
            InitializeComponent();
            visszaszámláló.Visibility = System.Windows.Visibility.Hidden;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                hours   = Int32.Parse(óra.Text);
                minutes = Int32.Parse(perc.Text);
                seconds = Int32.Parse(mperc.Text);
            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.Message);
            }

            if (minutes >= 60 || seconds >= 60)
            {
                MessageBox.Show("Nem érvényes a megadott idő, kérlek add meg valid óra, perc, másodperc formában!");
                return;
            }

            time = hours * 3600 + minutes * 60 + seconds;

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            óra.Visibility = System.Windows.Visibility.Hidden;
            perc.Visibility = System.Windows.Visibility.Hidden;
            mperc.Visibility = System.Windows.Visibility.Hidden;
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                int h = time / 3600;
                int m = time / 60 - h * 60;
                int s = time - m * 60 - h * 3600;
                visszaszámláló.Visibility = System.Windows.Visibility.Visible;
                visszaszámláló.Content = string.Format("{0} : {1} : {2}", h, m, s);
            }
            else
            {
                dispatcherTimer.Stop();
                óra.Visibility = System.Windows.Visibility.Visible;
                perc.Visibility = System.Windows.Visibility.Visible;
                mperc.Visibility = System.Windows.Visibility.Visible;
                visszaszámláló.Visibility = System.Windows.Visibility.Hidden;

                SystemSounds.Beep.Play();
                MessageBox.Show("Lejárt az idő!");
                
            }

        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            óra.Visibility = System.Windows.Visibility.Visible;
            perc.Visibility = System.Windows.Visibility.Visible;
            mperc.Visibility = System.Windows.Visibility.Visible;
            visszaszámláló.Visibility = System.Windows.Visibility.Hidden;
        }

        private void óra_MouseDown(object sender, MouseButtonEventArgs e)
        {
            nulláz(óra);
        }

        private void perc_MouseDown(object sender, MouseButtonEventArgs e)
        {
            nulláz(perc);
        }

        private void mperc_MouseDown(object sender, MouseButtonEventArgs e)
        {
            nulláz(mperc);
        }

        private void nulláz(TextBox tb)
        {
            tb.Text = "";
        }
    }
}
