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
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;


namespace KozpontiApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        static bool settingsReturn, refreshReturn;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void setProxy(string proxycím, int állapot, string popup = "")
        {
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            registry.SetValue("ProxyEnable", állapot);
            registry.SetValue("ProxyServer", proxycím);

            // These lines implement the Interface in the beginning of program 
            // They cause the OS to refresh the settings, causing IP to realy update
            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
            MessageBox.Show(popup);
        }

        private void Mosogepek_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            try
            {
                new mosogepek().Show();
            }
            catch
            {
                MessageBox.Show("Ez a funkció csak kolis proxyval, a KK-n belüli vezetékes hálózaton működik!!!");
            }
        }

        private void KoliProxy_Click(object sender, RoutedEventArgs e)
        {
            setProxy("proxy.vekoll.uni-pannon.hu:3128", 1, "Koli proxy beállítva!");
        }

        private void ProxyKi_Click(object sender, RoutedEventArgs e)
        {
            setProxy("", 0, "Proxy kikapcsolva!");
        }

        private void MásProxy_Click(object sender, RoutedEventArgs e)
        {
            new MásikProxy().Show();
        }

        private void Kondi_Click(object sender, RoutedEventArgs e)
        {
            new Kondi(Kondi);
            //MessageBox.Show("Ez a funkció még nincs kész, de érkezik :)");
        }

        private void Nyomtatós_Click(object sender, RoutedEventArgs e)
        {
            new Nyomtatós(Nyomtatós);
            //MessageBox.Show("Ez a funkció még nincs kész, de érkezik :)");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://info.kozpontikoli.hu/");
        }

        private void Időzítő_Click(object sender, RoutedEventArgs e)
        {
            new Idozito().Show();
        }
    }
}
