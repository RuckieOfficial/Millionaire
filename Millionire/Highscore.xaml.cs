using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Highscore : Window {

        static string pathHS = @"../../Json/Highscore.json";
        static JsonSerializerSettings settings = new JsonSerializerSettings {
            TypeNameHandling = TypeNameHandling.All
        };
        static string jsonFromFile = File.ReadAllText(pathHS);
        //static List<HighScore_items> highscore = new List<HighScore_items>();
        static List<HighScore_items> highscore = JsonConvert.DeserializeObject<List<HighScore_items>>(jsonFromFile, settings);
        int momentalniscore2;

        public Highscore(int momentalniscore) {
            InitializeComponent();
            momentalniscore2 = momentalniscore;
            score();
            //reset();
        }

        void Send_name(object sender, RoutedEventArgs e) {
            MainWindow main = new MainWindow();
            highscore.Add(new HighScore_items(momentalniscore2, jmeno.Text));

            string jsonToFile = JsonConvert.SerializeObject(highscore, settings);
            File.WriteAllText(pathHS, jsonToFile);
            this.Close();
            main.Show();
        }

        void domex(object sender, RoutedEventArgs e) {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

            void score() {
            var serazene = highscore.OrderBy(n => n.score).Reverse().ToList();
            jmeno1.Content = serazene[0].nick + " " + serazene[0].score;
            jmeno2.Content = serazene[1].nick + " " + serazene[1].score;
            jmeno3.Content = serazene[2].nick + " " + serazene[2].score;
            jmeno4.Content = serazene[3].nick + " " + serazene[3].score;
            jmeno5.Content = serazene[4].nick + " " + serazene[4].score;
            jmeno6.Content = serazene[5].nick + " " + serazene[5].score;
            jmeno7.Content = serazene[6].nick + " " + serazene[6].score;
            jmeno8.Content = serazene[7].nick + " " + serazene[7].score;
            jmeno9.Content = serazene[8].nick + " " + serazene[8].score;
            jmeno10.Content = serazene[9].nick + " " + serazene[9].score;
        }
        void reset() {
           List<HighScore_items> highscore = new List<HighScore_items>();
           highscore.Add(new HighScore_items(0, null));
           highscore.Add(new HighScore_items(0, null));
           highscore.Add(new HighScore_items(0, null));
           highscore.Add(new HighScore_items(0, null));
           highscore.Add(new HighScore_items(0, null));
           highscore.Add(new HighScore_items(0, null));
           highscore.Add(new HighScore_items(0, null));
           highscore.Add(new HighScore_items(0, null));
           highscore.Add(new HighScore_items(0, null));
           highscore.Add(new HighScore_items(0, null));
           highscore.Add(new HighScore_items(0, null));
           string jsonToFile = JsonConvert.SerializeObject(highscore, settings);
           File.WriteAllText(pathHS, jsonToFile);
        }
    }
}
