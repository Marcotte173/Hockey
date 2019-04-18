using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey_Text_Game
{
    
    class Program
    {                                                                                    //shot, pass, stick, run, def, save, school
        public static List<Player> TeamSB = new List<Player>() { new Player("Beau", 8, 7, 8, 7, 7, 4, 7), new Player("Suhail", 5, 5, 5, 6, 7, 3, 8), new Player("Trook", 8, 7, 7, 6, 7, 3, 6), new Player("Parth", 7, 7, 6, 6, 6, 8, 6) };
        public static List<Player> TeamLinden = new List<Player>() { new Player("Linden", 8, 7, 8, 7, 7, 4, 7), new Player("Freeman", 5, 5, 5, 6, 7, 3, 8), new Player("Yashmeet", 8, 7, 7, 6, 7, 3, 6), new Player("Cohen", 7, 7, 6, 6, 6, 8, 6) };
        public static List<Player> TeamAustin = new List<Player>() { new Player("Austin", 7, 7, 8, 7, 7, 4, 8), new Player("Haroon", 4, 4, 4, 6, 6, 6, 8), new Player("Pratsilopotchli", 4, 4, 4, 4, 5, 5, 8), new Player("Junaid", 7, 7, 6, 6, 6, 8, 6) };
        public static List<Player> TeamMarcus = new List<Player>() { new Player("Marcus", 6, 5, 5, 8, 6, 4, 8), new Player("Mankirat", 6, 6, 6, 6, 6, 4, 8), new Player("Paris", 6, 6, 6, 6, 6, 3, 8), new Player("Maclean", 4, 4, 4, 6, 5, 4, 8) };
        public static List<Player> TeamZaim = new List<Player>() { new Player("Zaim", 4, 4, 3, 7, 5, 6, 7), new Player("Lofstrand", 5, 5, 5, 6, 7, 4, 6), new Player("Anwesh", 4, 4, 3, 5, 5, 3, 7), new Player("Aditya", 3, 3, 3, 5, 5, 3, 7) };
        public static List<Player> TeamLewis = new List<Player>() {new Player("Lewis",8,7,7,7,7,4,7), new Player("Ayanah",5,5,5,6,7,3,8), new Player("Bell", 8,7,7,6,7,3,6), new Player("Tristan",7,7,7,7,7,8,6)  };
        public static List<string> TeamName = new List<string>() { "Team Austin", "Team Linden", "Team Lewis", "Team Marcus", "Team Suhail & Beau", "Team Zaim" };
        public static List<string> TeamsPlaying = new List<string>() { };
        public static List<Player> TeamRoster0 = new List<Player>() { };
        public static List<Player> TeamRoster1 = new List<Player>() { };
        public static List<Player> gameRoster0 = new List<Player>() { };
        public static List<Player> gameRoster1 = new List<Player>() { };
        private static Random rand = new Random();
        public static int period = 1;
        public static int team0Def;
        public static int team1Def;
        public static int team0Chances;
        public static int totalTeam0Chances;
        public static int team1Chances;
        public static int totalTeam1Chances;
        private static List<List<Player>> testList;

        static void Main(string[] args)
        {
            Start();
        }

        public static void CreateTeamList()
        {
            testList = new List<List<Player>>() { TeamAustin, TeamLinden, TeamLewis, TeamMarcus, TeamSB, TeamZaim };
        }

        private static void Start()
        {
            CreateTeamList();
            Console.WriteLine("Marcotte's Hockey Simulator!");
            Console.WriteLine("(S)tart  (Q)uit");
            string input = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (input == "s")
                PickTeam();
            if (input == "q")
                Environment.Exit(0);
            else Start();
        }

        private static void PickTeam()
        {
            if (TeamsPlaying.Count == 2)
                Game();
            Console.Clear();
            Console.WriteLine("Please Pick a team");
            for (int i = 0; i < TeamName.Count; i++)
            {
                Console.WriteLine($"({i}){TeamName[i]}");
            }
            Console.WriteLine("");
            int input;
            do
            {
                
            } while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString().ToLower(), out input));
            if (input > TeamName.Count() - 1)
                PickTeam();
            Console.WriteLine($"You have seleted {TeamName[input]}");
            Console.WriteLine($"{TeamName[input]}'s roster consists of: ");
            if (TeamsPlaying.Count == 0)
            {
                TeamRoster0 = testList[input];
                testList.Remove(testList[input]);
                for (int i = 0; i < TeamRoster0.Count; i++)
                {
                    Console.WriteLine($"({i}){TeamRoster0[i].getName()}");
                }
            }
            if (TeamsPlaying.Count == 1)
            {
                TeamRoster1 = testList[input];
                testList.Remove(testList[input]);
                for (int i = 0; i < TeamRoster1.Count; i++)
                {
                    Console.WriteLine($"({i}){TeamRoster1[i].getName()}");
                }
            }
            Keypress();
            TeamsPlaying.Add(TeamName[input]);
            TeamName.Remove(TeamName[input]);
            PickTeam();
        }

        private static void Game()
        {
            Console.Clear();
            Console.WriteLine($"Get ready guys! {TeamsPlaying[0]} Vs {TeamsPlaying[1]} is about to begin!");
            Keypress();
            PlayerCheck();
        }
        
        private static void PlayerCheck()
        {
            Console.WriteLine($"\n\n{TeamsPlaying[0]} Roster check!");
            for (int i = 0; i < TeamRoster0.Count; i++)
            {
                int roll = rand.Next(1, 11);
                Console.Write($"\n{TeamRoster0[i].getName()}....");
                bool canPlay = (roll <= TeamRoster0[i].getSchool()) ? true : false;
                if (canPlay)
                {
                    Console.Write("can play!");
                    gameRoster0.Add(TeamRoster0[i]);
                }

                else
                    Console.Write("has to do homework!");
            }
            Console.WriteLine($"\n\n\n\n{TeamsPlaying[1]} Roster check!");
            for (int i = 0; i < TeamRoster1.Count; i++)
            {
                int roll = rand.Next(1, 11);
                Console.Write($"\n{TeamRoster1[i].getName()}....");
                bool canPlay = (roll <= TeamRoster1[i].getSchool()) ? true : false;
                if (canPlay)
                {
                    Console.Write("can play!");
                    gameRoster1.Add(TeamRoster1[i]);
                }
                else
                    Console.Write("has to do homework!");
            }
            Keypress();
            Period();
                                       
        }

        private static void Keypress()
        {
            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey(true);
        }

        private static void GenerateChances()
        {
            {
                for (int i = 0; i < (gameRoster0.Count); i++)
                {
                    team0Def += gameRoster0[i].getDef();
                    totalTeam0Chances += gameRoster0[i].getStick() + gameRoster0[i].getRun();

                }
                for (int i = 0; i < gameRoster1.Count; i++)
                {
                    team1Def += gameRoster1[i].getDef();
                    totalTeam1Chances += gameRoster1[i].getStick() + gameRoster1[i].getRun();
                }
                team0Def /= gameRoster0.Count;
                team1Def /= gameRoster1.Count;
                team0Chances = totalTeam0Chances / gameRoster0.Count;
                team1Chances = totalTeam1Chances / gameRoster1.Count;
                team0Chances -= team1Def;
                team1Chances -= team0Def;
            }
        }

        private static void AssignChances()
        {
            do
            {
                int roll = rand.Next(1, 11);
                for (int x= 0; x < gameRoster0.Count; x++)
                {
                    if (roll <= (gameRoster0[x].getRun()+ gameRoster0[x].getRun()) / 2)
                    {
                        gameRoster0[x].setChances(gameRoster0[x].getChances() + 1);
                        team0Chances--;
                        if (team0Chances == 0)
                            break;
                    }
                }
             } while (team0Chances>0);
            do
            {
                int roll = rand.Next(1, 11);
                for (int x = 0; x < gameRoster1.Count; x++)
                {
                    if (roll <= (gameRoster1[x].getRun() + gameRoster1[x].getRun()) / 2)
                    {
                        gameRoster1[x].setChances(gameRoster1[x].getChances() + 1);
                        team1Chances--;
                        if (team1Chances == 0)
                            break;
                    }
                }
            } while (team1Chances > 0);
        }

        private static void Period()
        {
            Console.Clear();
            Console.WriteLine($"It is Period {period}");
            GenerateChances();
            AssignChances();
            for (int i = 0; i < (gameRoster0.Count); i++)
            {
                Console.WriteLine($"{gameRoster0[i].getName()} gets {gameRoster0[i].getChances()} shots");

            }
            for (int i = 0; i < gameRoster1.Count; i++)
            {
                Console.WriteLine($"{gameRoster1[i].getName()} gets {gameRoster1[i].getChances()} shots");
            }
            Keypress();
            period++;
            if (period > 3)
                GameEvaluate();
            Period();
        }

        private static void GameEvaluate()
        {
            Console.Clear();
            Console.WriteLine("Next thing to do");
        }
    }
}