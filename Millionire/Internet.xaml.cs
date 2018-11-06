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
using System.Media;
using System.IO;
using System.Windows.Threading;

namespace Millionire {
    public partial class Internet : Window {
        public DispatcherTimer timer = new DispatcherTimer();
        public DispatcherTimer timer2 = new DispatcherTimer();

        private int pridavani = 13;
        private void exit(object sender, EventArgs e)
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 13000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += new EventHandler(timer_Tick2);
            timer2.Start();

        }

        void timer_Tick(object sender, EventArgs e) {
            this.Close();
            timer.Stop();
        }

        void timer_Tick2(object sender, EventArgs e) {
            pridavani--;
            if (pridavani < 4) {
                Tajm.Foreground = Brushes.PaleVioletRed;
            }
            Tajm.Content = pridavani.ToString();
        }


        public Internet() {
            InitializeComponent();
        }
    }

}
