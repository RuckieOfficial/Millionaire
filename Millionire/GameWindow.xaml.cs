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
using Newtonsoft.Json;
using System.Net;

namespace Millionire
{
    public partial class GameWindow : Window
    {
        public int level = 1;
        int vyhra;
        public static bool CheckForInternetConnection() {
            try {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204")) {
                    return true;
                }
            } catch {
                return false;
            }
        }

        Random r = new Random();
        int rodpoved2;
        static string pathQaA = @"../../Json/QaA.json";
        static string pathL1 = @"../../Sound/level1-4.wav";
        static string pathL2 = @"../../Sound/level4-7.wav";
        static string pathL3 = @"../../Sound/level7-9.wav";
        static string pathL4 = @"../../Sound/level10.wav";
        static string path2 = @"../../Sound/lose.wav";
        static string path3 = @"../../Sound/internet_surf.wav";
        public int momentalniscore;
        static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        static string jsonFromFile = File.ReadAllText(pathQaA);
        //List<QaA> item = new List<QaA>();
        static List<QaA> ukol = JsonConvert.DeserializeObject<List<QaA>>(jsonFromFile, settings);
        //static List<QaA> ukol = new List<QaA>();
        SoundPlayer hudbaL1 = new SoundPlayer(pathL1);
        SoundPlayer hudbaL2 = new SoundPlayer(pathL2);
        SoundPlayer hudbaL3 = new SoundPlayer(pathL3);
        SoundPlayer hudbaL4 = new SoundPlayer(pathL4);
        SoundPlayer hudba2 = new SoundPlayer(path2);
        SoundPlayer hudba3 = new SoundPlayer(path3);

        Internet internet = new Internet();
        Gameover gameover = new Gameover();

        void Scoreboard() {
            void MomentalLVL() {
                if (level == 1) {
                    Poz1.Background = new SolidColorBrush(Colors.OrangeRed);
                }
                if (level == 2) {
                    Poz1.Background = new SolidColorBrush(Colors.Green);
                    Poz2.Background = new SolidColorBrush(Colors.OrangeRed);
                }
                if (level == 3) {
                    Poz2.Background = new SolidColorBrush(Colors.Green);
                    Poz3.Background = new SolidColorBrush(Colors.OrangeRed);
                }
                if (level == 4) {
                    Poz3.Background = new SolidColorBrush(Colors.Green);
                    Poz4.Background = new SolidColorBrush(Colors.OrangeRed);
                }
                if (level == 5) {
                    Poz4.Background = new SolidColorBrush(Colors.Green);
                    Poz5.Background = new SolidColorBrush(Colors.OrangeRed);
                }
                if (level == 6) {
                    Poz5.Background = new SolidColorBrush(Colors.Green);
                    Poz6.Background = new SolidColorBrush(Colors.OrangeRed);
                }
                if (level == 7) {
                    Poz6.Background = new SolidColorBrush(Colors.Green);
                    Poz7.Background = new SolidColorBrush(Colors.OrangeRed);
                }
                if (level == 8) {
                    Poz7.Background = new SolidColorBrush(Colors.Green);
                    Poz8.Background = new SolidColorBrush(Colors.OrangeRed);
                }
                if (level == 9) {
                    Poz8.Background = new SolidColorBrush(Colors.Green);
                    Poz9.Background = new SolidColorBrush(Colors.OrangeRed);
                }
                if (level == 10){
                    Poz9.Background = new SolidColorBrush(Colors.Green);
                    Poz10.Background = new SolidColorBrush(Colors.OrangeRed);
                }
            }
            MomentalLVL();
        }

        void NewG(object sender, RoutedEventArgs e) {
            CreateQaA();
            ZvukLevely();
            FifFif.IsEnabled = true;
            InternetHLP.IsEnabled = true;
            Publik.IsEnabled = true;
            level = 1;
        }
        void CreateQaA() {
            if (level == 5) {
                momentalniscore = 50000;
            }
            if (level == 8) {
                momentalniscore = 500000;
            }
            //Výhra
            if (level == 11) {
                Highscore score = new Highscore(momentalniscore);
                momentalniscore = 5000000;
                this.Close();
                score.Show();
            }

            if (level < 11) {
                if (File.Exists(pathQaA)) {
                    if (ukol.Count != 0) {
                        //Otázky, Odpovědi a obtížnost
                        //ukol.Add(new QaA("Jaký je rok?", "2010", "2020", "2015", "2018", 1));

                        //string jsonToFile = JsonConvert.SerializeObject(ukol, settings);
                        //File.WriteAllText(pathQaA, jsonToFile);

                        //Tohle ne
                        procenta1.Visibility = Visibility.Hidden;
                        procenta2.Visibility = Visibility.Hidden;
                        procenta3.Visibility = Visibility.Hidden;
                        procenta4.Visibility = Visibility.Hidden;

                        //Vše zobrazit
                        A.Visibility = Visibility.Visible;
                        odpoved1.Visibility = Visibility.Visible;
                        A1.IsEnabled = true;
                        B.Visibility = Visibility.Visible;
                        odpoved2.Visibility = Visibility.Visible;
                        A2.IsEnabled = true;
                        C.Visibility = Visibility.Visible;
                        odpoved3.Visibility = Visibility.Visible;
                        A3.IsEnabled = true;
                        D.Visibility = Visibility.Visible;
                        odpoved4.Visibility = Visibility.Visible;
                        A4.IsEnabled = true;

                        if (CheckForInternetConnection() == false) {
                            InternetHLP.Content = "50/50" + (char)0xB2;
                        }
                        //Skore
                        Scoreboard();

                        //Zvuky
                        ZvukLevely();

                        //Vypsání
                        var shoda = ukol.Where(n => n.obtiznost == level).ToList();
                        int rotazka = r.Next(shoda.Count());
                        int rodpoved = r.Next(0, 4);
                        rodpoved2 = rodpoved;
                        otazka.Content = shoda[rotazka].otazka;

                        if (rodpoved == 0) {
                            odpoved1.Content = shoda[rotazka].odpoved1;
                            odpoved2.Content = shoda[rotazka].odpoved2;
                            odpoved3.Content = shoda[rotazka].odpoved3;
                            odpoved4.Content = shoda[rotazka].odpoved4;
                            vyhra = 4;
                        }
                        if (rodpoved == 1) {
                            odpoved1.Content = shoda[rotazka].odpoved4;
                            odpoved2.Content = shoda[rotazka].odpoved1;
                            odpoved3.Content = shoda[rotazka].odpoved2;
                            odpoved4.Content = shoda[rotazka].odpoved3;
                            vyhra = 1;
                        }
                        if (rodpoved == 2) {
                            odpoved1.Content = shoda[rotazka].odpoved3;
                            odpoved2.Content = shoda[rotazka].odpoved4;
                            odpoved3.Content = shoda[rotazka].odpoved1;
                            odpoved4.Content = shoda[rotazka].odpoved2;
                            vyhra = 2;
                        }
                        if (rodpoved == 3) {
                            odpoved1.Content = shoda[rotazka].odpoved2;
                            odpoved2.Content = shoda[rotazka].odpoved3;
                            odpoved3.Content = shoda[rotazka].odpoved4;
                            odpoved4.Content = shoda[rotazka].odpoved1;
                            vyhra = 3;
                        }

                    } else {
                        string jsonToFile = JsonConvert.SerializeObject(ukol, settings);
                        File.WriteAllText(pathQaA, jsonToFile);
                    }
                } else {
                    string jsonToFile = JsonConvert.SerializeObject(ukol, settings);
                    File.WriteAllText(pathQaA, jsonToFile);
                }
            }

        }

        void Help_Fifty(object sender, RoutedEventArgs e) {
            var tagnew = ((Button)sender).Tag;
            string xnew = tagnew.ToString();
            if (xnew == "Fif") {
                FifFif.IsEnabled = false;
            }
            if (xnew == "Nevermind") {
                InternetHLP.IsEnabled = false;
                //InternetHLP.Background = null;
            }
            if (rodpoved2 == 0) {
                A.Visibility = Visibility.Hidden;
                odpoved1.Visibility = Visibility.Hidden;
                procenta1.Visibility = Visibility.Hidden;
                A1.IsEnabled = false;
                B.Visibility = Visibility.Hidden;
                odpoved2.Visibility = Visibility.Hidden;
                procenta2.Visibility = Visibility.Hidden;
                A2.IsEnabled = false;
            }
            if (rodpoved2 == 1) {
                B.Visibility = Visibility.Hidden;
                odpoved2.Visibility = Visibility.Hidden;
                procenta2.Visibility = Visibility.Hidden;
                A2.IsEnabled = false;
                D.Visibility = Visibility.Hidden;
                odpoved4.Visibility = Visibility.Hidden;
                procenta4.Visibility = Visibility.Hidden;
                A4.IsEnabled = false;
            }
            if (rodpoved2 == 2) {
                A.Visibility = Visibility.Hidden;
                odpoved1.Visibility = Visibility.Hidden;
                procenta1.Visibility = Visibility.Hidden;
                A1.IsEnabled = false;
                D.Visibility = Visibility.Hidden;
                odpoved4.Visibility = Visibility.Hidden;
                procenta4.Visibility = Visibility.Hidden;
                A4.IsEnabled = false;
            }
            if (rodpoved2 == 3) {
                B.Visibility = Visibility.Hidden;
                odpoved2.Visibility = Visibility.Hidden;
                procenta2.Visibility = Visibility.Hidden;
                A2.IsEnabled = false;
                A.Visibility = Visibility.Hidden;
                odpoved1.Visibility = Visibility.Hidden;
                procenta1.Visibility = Visibility.Hidden;
                A1.IsEnabled = false;
            }
        }

        void Help_Bois(object sender, RoutedEventArgs e)  {
            Publik.IsEnabled = false;
            if (A1.IsEnabled) {
                procenta1.Visibility = Visibility.Visible;
            }
            if (A2.IsEnabled) {
                procenta2.Visibility = Visibility.Visible;
            }
            if (A3.IsEnabled) {
                procenta3.Visibility = Visibility.Visible;
            }
            if (A4.IsEnabled) {
                procenta4.Visibility = Visibility.Visible;
            }
            int sancenavyhru = r.Next(0,101);
            int pomuze = r.Next(50, 60);
            int neznama1 = r.Next(0, 100 - (pomuze*(12/10)));
            int neznama2 = r.Next(0, 100 - (pomuze) - neznama1);
            int neznama3 = 100 - pomuze - neznama1 - neznama2;
            int nepomuze = r.Next(10, 30);
            int neznama1a = r.Next(0, 100 - nepomuze*2);
            int neznama2a = r.Next(0, 100 - neznama1a - nepomuze);
            int neznama3a = 100 - nepomuze - neznama1a - neznama2a;
            if (sancenavyhru < 70) {
                if (vyhra == 4) {
                    procenta1.Content = neznama1 +"%";
                    procenta2.Content = neznama2 + "%";
                    procenta3.Content = neznama3 + "%";
                    procenta4.Content = pomuze + "%";
                }
                if (vyhra == 3)
                {
                    procenta4.Content = neznama3 + "%";
                    procenta1.Content = neznama2 + "%";
                    procenta2.Content = neznama1 + "%";
                    procenta3.Content = pomuze + "%";
                }
                if (vyhra == 2)
                {
                    procenta3.Content = neznama2 + "%";
                    procenta4.Content = neznama1 + "%";
                    procenta1.Content = neznama3 + "%";
                    procenta2.Content = pomuze + "%";
                }
                if (vyhra == 1)
                {
                    procenta2.Content = neznama1 + "%";
                    procenta3.Content = neznama3 + "%";
                    procenta4.Content = neznama2 + "%";
                    procenta1.Content = pomuze + "%";
                }
            } else {
                if (vyhra == 4)
                {
                    procenta1.Content = neznama1a + "%";
                    procenta2.Content = neznama2a + "%";
                    procenta3.Content = neznama3a + "%";
                    procenta4.Content = nepomuze + "%";
                }
                if (vyhra == 3)
                {
                    procenta4.Content = neznama3a + "%";
                    procenta1.Content = neznama2a + "%";
                    procenta2.Content = neznama1a + "%";
                    procenta3.Content = nepomuze + "%";
                }
                if (vyhra == 2)
                {
                    procenta3.Content = neznama2a + "%";
                    procenta4.Content = neznama1a + "%";
                    procenta1.Content = neznama3a + "%";
                    procenta2.Content = nepomuze + "%";
                }
                if (vyhra == 1)
                {
                    procenta2.Content = neznama1a + "%";
                    procenta3.Content = neznama3a + "%";
                    procenta4.Content = neznama2a + "%";
                    procenta1.Content = nepomuze + "%";
                }
            }
        }

        void Highscore() {

        }

        void Answer(object sender, RoutedEventArgs e) {
            Highscore score = new Highscore(momentalniscore);
            var tag = ((Button)sender).Tag;
            string x = tag.ToString();
            int kliknuto = Int32.Parse(x);
            if (kliknuto == 1) {
                if (vyhra == 1) {
                    level++;
                    StopZvukLevely();
                    CreateQaA();
                }
                else {
                    if (level < 5) {
                        GG();
                    } else {
                        this.Close();
                        score.Show();
                    }
                }
            }
            if (kliknuto == 2) {
                if (vyhra == 2) {
                    level++;
                    StopZvukLevely();
                    CreateQaA();
                }
                else {
                    if (level < 5) {
                        GG();
                    } else {
                        this.Close();
                        score.Show();
                    }
                }
            }
            if (kliknuto == 3) {
                if (vyhra == 3) {
                    level++;
                    StopZvukLevely();
                    CreateQaA();
                }
                else {
                    if (level < 5) {
                        GG();
                    } else {
                        this.Close();
                        score.Show();
                    }
                }
            }
            if (kliknuto == 4) {
                if (vyhra == 4) {
                    level++;
                    StopZvukLevely();
                    CreateQaA();
                }
                else {
                    if (level < 5) {
                        GG();
                    } else {
                        this.Close();
                        score.Show();
                    }
                }
            }
        }

        void GG() {
            StopZvukLevely();
            hudba2.Play();
            gameover.Show();
            this.Close();
        }

        void HighScore(object sender, RoutedEventArgs e) {
        }

        void Exit(object sender, RoutedEventArgs e) {
            System.Windows.Application.Current.Shutdown();
        }

        void Help_Internet(object sender, RoutedEventArgs e) {
            //Internet
            if (CheckForInternetConnection() == false) {
                Help_Fifty((Button)sender, e);
            } else {
                InternetHLP.IsEnabled = false;
                Zvuk3();
                internet.Show();
            }
        }

        void StopZvukLevely()
        {
            /*hudbaL1.Stop();
            hudbaL2.Stop();
            hudbaL3.Stop();
            hudbaL4.Stop();*/
        }

        void ZvukLevely()
        {
            if (level == 1 || level == 2  || level == 3 || level == 4) {
                hudbaL1.Play();
            }
            if (level == 5 || level == 6 || level == 7) {
                hudbaL2.Play();
            }
            if (level == 8 || level == 9)
            {
                hudbaL3.Play();
            }
            if (level == 10)
            {
                hudbaL4.Play();
            }
        }

        void Zvuk2()
        {
            hudba2.Play();
        }

        void Zvuk3()
        {
            hudba3.Play();
        }

        public GameWindow()
        {
            InitializeComponent();
            CreateQaA(); //Vytvoření Otázek a odpovědí
        }
    }
}
