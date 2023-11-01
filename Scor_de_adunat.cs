using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_proiect_cu_clase
{
    internal class Scor_de_adunat:Hexagon
    {
        public Scor_de_adunat()
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
            int labelWidth = HexSize - 10; // Ajustați dimensiunea în funcție de preferințe
            int labelHeight = 20; // Ajustați dimensiunea în funcție de preferințe
            int labelX = (int)(x - labelWidth / 2);
            int labelY = (int)(y - labelHeight / 2);
            Random random = new Random();
            int randomValue = random.Next(-20, 21);
            string text = randomValue.ToString();
            if (randomValue > 0)
                text = "+" + randomValue.ToString();
            Font font = new Font("Arial", 6); // Ajustați fontul în funcție de preferințe

            // Setarea alinierii pentru a centra textul în controlul Label
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            // Desenarea textului în hexagon
            graphics.DrawString(text, font, Brushes.Black, new Rectangle(labelX, labelY, labelWidth, labelHeight), stringFormat);
        }
    }
    internal class Start : Hexagon
    {
        public Image obstacleImage = Image.FromFile("C:\\Users\\ASUS\\Desktop\\Linux-cursuri\\start.png");
        public Start()
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
    internal class Finish : Hexagon
    {
        public Image obstacleImage = Image.FromFile("C:\\Users\\ASUS\\Desktop\\Linux-cursuri\\stop.jpg");
        public Finish()
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
    internal class Cufar : Hexagon
    {
        int points = 100;
        public Image obstacleImage = Image.FromFile("C:\\Users\\ASUS\\Desktop\\Linux-cursuri\\cufar.png");
        public Cufar()
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
    internal class Cufarrand : Hexagon
    {
        int points;
        public Image obstacleImage = Image.FromFile("C:\\Users\\ASUS\\Desktop\\Linux-cursuri\\cufarrand.jpg");
        public Cufarrand()
        {
            Random random1=new Random();
            int points = random1.Next(-100, 100);
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
    internal class Teleport : Hexagon
    {
        public Image obstacleImage = Image.FromFile("C:\\Users\\ASUS\\Desktop\\Linux-cursuri\\teleport.png");
        public Teleport()
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
}
