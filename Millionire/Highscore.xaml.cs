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

        public Highscore() {
            InitializeComponent();
            Score();
        }

        void Send_name(object sender, RoutedEventArgs e) {
            string xJmeno = jmeno.ToString();
            MessageBox.Show(xJmeno);
        }

        void Score() {
            string pathHS = @"../../Json/Highscore.json";
            JsonSerializerSettings settings = new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.All
            };

            string jsonFromFile = File.ReadAllText(pathHS);
            List<HighScore_items> ukol = JsonConvert.DeserializeObject<List<HighScore_items>>(jsonFromFile, settings);
        }

    }
}
