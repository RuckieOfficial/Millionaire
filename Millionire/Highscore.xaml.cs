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

        public Highscore() {
            InitializeComponent();
            Score();
        }

        void Send_name(object sender, RoutedEventArgs e) {
            highscore.Add(new HighScore_items(1000, jmeno.Text));

            string jsonToFile = JsonConvert.SerializeObject(highscore, settings);
            File.WriteAllText(pathHS, jsonToFile);
        }

        void Score() {
            foreach (var item in highscore) {
                jmeno1.Content = item.nick + " " + item.score;
            } 

        }

    }
}
