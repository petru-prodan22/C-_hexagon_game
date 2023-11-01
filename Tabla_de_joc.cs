using System;
using System.Collections.Generic;
using System.Drawing;

namespace POO_proiect_cu_clase
{
    public class Tabla_de_joc
    {Random k = new Random();
        public static int dim;
        public int dificultate;
        public Hexagon[,] matricehex = new Hexagon[12,12 ];

        public Tabla_de_joc()
        { //dim=2;
            dificultate= 0;
        }

        public void DrawHexagonalChessBoard(Graphics graphics, Hexagon[,] matricehexcentru)
        { int telp = 0,obs=0,cuf=0,cufr=0;
            Brush brush = Brushes.White;
            Pen pen = Pens.Black;

            for (int row = 0; row < dim; row++)
            {
                for (int col = 0; col < dim; col++)
                {int p=k.Next(0,dim*dim);
                    if (row + col > dim / 2 - 1 && row + col < dim / 2 + dim)
                    {
                        double x = 1.75 * Hexagon.HorizontalOffset + 1.75 * Hexagon.HexSize * col + 1.75 * (Hexagon.HexSize / 2 * row);
                        double y = 1.55 * Hexagon.VerticalOffset + 1.55 * Hexagon.HexSize * row;
                        if (row == dim/2 & col == 0)
                        {
                            Start hexagon = new Start();
                            hexagon.DrawHexagon1(graphics, pen, brush, x, y, Hexagon.HexSize);
                            matricehexcentru[row, col] = hexagon;
                        }
                        else if(col==dim-1 &&row==dim/2)
                        {
                            Finish hexagon = new Finish();
                            hexagon.DrawHexagon1(graphics, pen, brush, x, y, Hexagon.HexSize);
                            matricehexcentru[row, col] = hexagon;
                        }
                        else if ( telp<2&&p % 5 == 4)
                        {
                            Teleport hexagon = new Teleport();
                            hexagon.DrawHexagon1(graphics, pen, brush, x, y, Hexagon.HexSize);
                            matricehexcentru[row, col] = hexagon;
                            telp++;
                        }
                        else if(obs<5||p%5==0)
                        {
                            Obstacol hexagon = new Obstacol();
                            hexagon.DrawHexagon1(graphics, pen, brush, x, y, Hexagon.HexSize);
                            obs++;
                            matricehexcentru[row, col] = hexagon;
                        }
                        else if(cuf<3 || p % 5 == 1)
                        {
                            cuf++;
                            Cufar hexagon = new Cufar();
                            hexagon.DrawHexagon1(graphics, pen, brush, x, y, Hexagon.HexSize);
                            matricehexcentru[row, col] = hexagon;
                        }
                        else if (cufr < 2 || p % 5 == 2)
                        {
                            cufr++;
                            Cufarrand hexagon = new Cufarrand();
                            hexagon.DrawHexagon1(graphics, pen, brush, x, y, Hexagon.HexSize);
                            matricehexcentru[row, col] = hexagon;
                        }
                        else
                        {
                          
                            Scor_de_adunat hexagon = new Scor_de_adunat();
                            hexagon.DrawHexagon1(graphics, pen, brush, x, y, Hexagon.HexSize);
                            matricehexcentru[row, col] = hexagon;
                        }
                    }
                }
            }
           // matricehexcentru = matricehex;
        }
    }
}
