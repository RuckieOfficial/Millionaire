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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Millionire
{
    public partial class MainWindow : Window
    {
        static string path2 = @"../../Sound/bg_sound.wav";
        SoundPlayer hudba2 = new SoundPlayer(path2);
        int momentalniscore;

        static bool IsAlive = true;

        void Zvuk2() {
            hudba2.Play();
        }

        void Exit(object sender, RoutedEventArgs e) {
            System.Windows.Application.Current.Shutdown();
        }

        void HighScore(object sender, RoutedEventArgs e) {
            Highscore score = new Highscore(momentalniscore);
            IsAlive = false;
            this.Close();
            score.Show();
        }

            void NewG(object sender, RoutedEventArgs e) {
            GameWindow hlavni = new GameWindow();
            IsAlive = false;
            hlavni.level = 1;
            this.Close();
            hlavni.Show();
        }

        private void Konecvidea(object sender, RoutedEventArgs e) {
            Intro.Visibility = Visibility.Hidden;
            Skip.Visibility = Visibility.Hidden;    
            Mizeni.Fill = Brushes.White;
            Pruhlednost();
        }

        public void Pruhlednost() {
            var animace = new DoubleAnimation {
                To = 0,
                BeginTime = TimeSpan.FromSeconds(1),
                Duration = TimeSpan.FromSeconds(0.5),
                FillBehavior = FillBehavior.Stop
            };
            animace.Completed += (s, a) => Mizeni.Visibility = Visibility.Hidden;
            Mizeni.BeginAnimation(UIElement.OpacityProperty, animace);
        }

        public MainWindow() {
            InitializeComponent();
            if (IsAlive == true) {
                IsAlive = false;
               Intro.Play();
               Intro.MediaEnded += Konecvidea;
            } else {
                Mizeni.Visibility = Visibility.Hidden;
                Skip.Visibility = Visibility.Hidden;
            }
            Zvuk2();
        }

        private void Skipit(object sender, RoutedEventArgs e) {
            Intro.Stop();
            Intro.Visibility = Visibility.Hidden;
            Mizeni.Visibility = Visibility.Hidden;
            Skip.Visibility = Visibility.Hidden;
        }
    }
}
