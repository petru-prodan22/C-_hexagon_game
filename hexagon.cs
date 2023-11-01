using System;
using System.Drawing;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Hexagon
{
    public const int HexSize = 50;
    public const int HorizontalOffset = 60;
    public const int VerticalOffset = 60;
    public Point centru;
    public Hexagon()
    {
      
        //
        // TODO: Add constructor logic here
        //
    }
    public Point Centru(double x, double y, int size)
    {
        float xs = 0, ys = 0;
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
            xs += hx;
            ys += hy;
        }
        return new Point((int)xs / 6, (int)ys / 6);
    }
    public void DrawHexagon1(Graphics graphics, Pen pen, Brush brush, double x, double y, int size)
    {
        float xs = 0, ys = 0;
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
            xs += hx;
            ys += hy;
        }
        centru = new Point((int)xs / 6, (int)ys / 6);
        graphics.FillPolygon(brush, hexagonPoints);
        graphics.DrawPolygon(pen, hexagonPoints);
        
    }
}
