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

namespace AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // UI-Thread
            MessageBox.Show("Start");
            textBoxWert.Text = "Anfang";
            await Task.Run(() => // Task-Thread
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(100);
                    Dispatcher.Invoke(() => progressBarWert.Value = i);
                }
            }).ConfigureAwait(false);

            // nach dem await ein wechsel ZURÜCK in den UI-Thread
            textBoxWert.Text = "Ende";


            // t1.Wait(); // Deadlock
            MessageBox.Show("Ende");

            //string uhrzeit = GetString().Result; // Blockierend
            //string uhrzeit = await GetString(); // Blockiert nicht !
            //MessageBox.Show(uhrzeit);
        }

        private Task<string> GetString()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(5000);
                return DateTime.Now.ToLongTimeString();
            });
        }
    }
}
