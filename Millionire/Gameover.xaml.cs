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

namespace Millionire {
    public partial class Gameover : Window {
        static string path2 = @"../../Sound/lose.wav";
        SoundPlayer hudba2 = new SoundPlayer(path2);

        void Zvuk2() {
            hudba2.Play();
        }

        void Exit(object sender, RoutedEventArgs e) {
            System.Windows.Application.Current.Shutdown();
        }

        void NewG(object sender, RoutedEventArgs e) {
            GameWindow hlavni = new GameWindow();
            hlavni.level = 1;
            this.Close();
            hlavni.Show();
        }

        void Menu(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

        public Gameover() {
            InitializeComponent();
            Zvuk2();
        }
    }
}
