using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_proiect_cu_clase
{
    internal class Obstacol : Hexagon
    {
        public Image obstacleImage = Image.FromFile("C:\\Users\\ASUS\\Desktop\\Linux-cursuri\\tree.png");
        public Obstacol()
        {

        }
        public void DrawHexagon1(Graphics graphics, Pen pen, Brush brush, double x, double y, int size)
        {
            PointF[] hexagonPoints = new PointF[6];
            double angle = 2.0 * Math.PI / 6;

            // Offset the angle to rotate the hexagon
            double angleOffset = Math.PI / 6; // Rotate 30 degrees (π/6 radians)

            for (int i = 0; i < 6; i++)
            {
                double theta = angle * i + angleOffset; // Add the angle offset
                float hx = (float)x + size * (float)Math.Cos(theta);
                float hy = (float)y + size * (float)Math.Sin(theta);
                hexagonPoints[i] = new PointF(hx, hy);
            }

            graphics.FillPolygon(brush, hexagonPoints);
            graphics.DrawPolygon(pen, hexagonPoints);
            float imageSize = HexSize * 1.3f;
            float imageX = (float)(x - imageSize / 2);
            float imageY = (float)(y - imageSize / 2);
            graphics.DrawImage(obstacleImage, imageX, imageY, imageSize, imageSize);
        }
    }
    public class Leaderboard
    {
        private const string FileName = "leaderboard.txt";

        public static void AddScore(string playerName, int score)
        {
            string entry = $"{playerName}:{score}";
            File.AppendAllText(FileName, entry + Environment.NewLine);
        }

        public static List<LeaderboardEntry> GetLeaderboard()
        {
            List<LeaderboardEntry> leaderboard = new List<LeaderboardEntry>();

            if (File.Exists("C:\\Users\\ASUS\\source\\repos\\Proiect_poo_sesiune\\Proiect_poo_sesiune\\TextFile1.txt"))
            {
                string[] lines = File.ReadAllLines("C:\\Users\\ASUS\\source\\repos\\Proiect_poo_sesiune\\Proiect_poo_sesiune\\TextFile1.txt");

                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');

                    if (parts.Length == 3)
                    {
                        string playerName = parts[0];
                        int score = int.Parse(parts[1]);
                        string data = parts[2];
                        LeaderboardEntry entry = new LeaderboardEntry(playerName, score, data);
                        leaderboard.Add(entry);
                    }
                }

                // Sortează clasamentul după scor în ordine descrescătoare
                leaderboard = leaderboard.OrderByDescending(entry => entry.Score).ToList();

                // Afisează doar primii 10 jucători din clasament
                leaderboard = leaderboard.Take(10).ToList();
            }
            else
            {
                // Adăugați scorurile implicite
                // leaderboard.Add(new LeaderboardEntry("John", 100));
                // leaderboard.Add(new LeaderboardEntry("Jane", 200));
                // leaderboard.Add(new LeaderboardEntry("Mike", 150));
            }

            return leaderboard;
        }


    }

    public class LeaderboardEntry
    {public LeaderboardEntry() { }  
        public string PlayerName { get; set; }
        public int Score { get; set; }
        
        public string data { get; set; }
        public LeaderboardEntry(string playerName, int score, string data)
        {
            PlayerName = playerName;
            Score = score;
            this.data = data;
        }
    }

}
