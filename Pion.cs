using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace POO_proiect_cu_clase
{
    internal class JocSah
    {
        private int hexagonCurentX = -1;
        private int hexagonCurentY = -1;
        public Hexagon[,] matricehex = new Hexagon[12, 12];
        int w, h;
        Graphics g;
        List<Piesa> piese;
        Piesa piesaSelectata;
        int dx, dy;
        int cStart, lStart;
        //==============
        int l;
        Pen creion = new Pen(Color.Black, 1);//Pens.Black;
        Brush c1 = Brushes.Blue;
        Brush c2 = Brushes.Red;
        System.Drawing.Font f = new Font("Times New Roman", 18, FontStyle.Bold | FontStyle.Italic);
        StringFormat sf;
        public Tabla_de_joc T = new Tabla_de_joc();
        public JocSah(int w, int h, Graphics g)
        {
            this.w = w;
            this.h = h;
            this.g = g;
            l = w / 10;
            sf = new StringFormat();
            piese = new List<Piesa>();
            //piesaSelectata = null;
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    matricehex[i, j] = new Hexagon();
        }
        public void JocNou()
        {
            //piesaSelectata = null;
            adauga_piese();
            deseneaza();
        }
        void adauga_piese()
        {
            //piese=new List<Piesa>();
            for (int i = 1; i <= 1; i++)
            {
                Piesa pion = new Pion(0, 0, l / 2, l / 2);
                aseaza_piesa(pion, i, 1);
                piese.Add(pion);
            }
            for (int i = 1; i <= 0; i++)
            {
                Piesa pion = new Pion(0, 0, l / 2, l / 2);
                aseaza_piesa(pion, i, 7);
                piese.Add(pion);
            }
        }
        void aseaza_piesa(Piesa piesa, int linie, int coloana)
        {
            double x = 1.75 * Hexagon.HexSize * coloana + 1.75 * (Hexagon.HexSize / 2 * linie);
            double y = 1.55 * Hexagon.HexSize * linie;


            piesa.X = (int)x;
            piesa.Y = (int)y;
        }


        //===============================
        public void HexagonClicat(int x, int y)
        {
            if (piesaSelectata == null)
            {
                selecteaza_piesa(x, y);
            }
            else
            {
                muta_piesa(x, y);
            }
        }

        public void selecteaza_piesa(int x, int y)
        {
            foreach (Piesa piesa in piese)
            {
                if (piesa.este_deasupra(x, y))
                {
                    piesaSelectata = piesa;
                    break;
                }
            }

            deseneaza();
        }

        public void muta_piesa(int x, int y)
        {
            int hexagonDestinatieX = (int)(x / Hexagon.HorizontalOffset);
            int hexagonDestinatieY = (int)(y / Hexagon.VerticalOffset);
            cStart = hexagonDestinatieY;
            lStart = hexagonDestinatieX;
            // Verificați dacă mutarea este validă (implementați logica corespunzătoare)
            if (piesaSelectata.valideaza_mutare(lStart, cStart, hexagonDestinatieY, hexagonDestinatieX))
            {
                int destinatieX = (int)(Hexagon.HorizontalOffset + Hexagon.HexSize + 1.75 * (Hexagon.HexSize / 2) * hexagonDestinatieX);
                int destinatieY = (int)(Hexagon.VerticalOffset + Hexagon.HexSize * hexagonDestinatieY);

                piesaSelectata.X = destinatieX;
                piesaSelectata.Y = destinatieY;



                deseneaza();
            }
        }


        public void elibereaza_piesa(int x, int y)
        {
            hexagonCurentX = piesaSelectata.X / (int)Hexagon.HorizontalOffset;
            hexagonCurentY = piesaSelectata.Y / (int)Hexagon.VerticalOffset;

            x = (int)(Hexagon.HorizontalOffset + Hexagon.HexSize + 1.75 * (Hexagon.HexSize / 2 * 1));
            y = (int)(Hexagon.VerticalOffset + Hexagon.HexSize);
            if (piesaSelectata is Pion)
            {
                int tempL = hexagonCurentY;
                int tempC = hexagonCurentX;

                if (piesaSelectata.valideaza_mutare(lStart, cStart, tempL, tempC))
                {
                    aseaza_piesa(piesaSelectata, tempC, tempL);
                }
                else
                {
                    aseaza_piesa(piesaSelectata, cStart, lStart);
                }
            }
            //piesaSelectata = null;
            deseneaza();
        }
        void deseneaza()
        {
            g.Clear(Color.White);
            T.DrawHexagonalChessBoard(g,matricehex);
            deseneaza_piese();
        }
        //===============================
        /* public void deseneaza_tabla_sah()
         {
             Scor_de_adunat a = new Scor_de_adunat();
             Brush brush = Brushes.White;
             Pen pen = Pens.Black;

             for (int row = 0; row < 7; row++)
             {
                 for (int col = 0; col < 7; col++)
                 {
                     if (row + col > 2 && row + col < 10)
                     {
                         double x = 1.75 * Hexagon.HorizontalOffset + 1.75 * Hexagon.HexSize * col + 1.75 * (Hexagon.HexSize / 2 * row);
                         double y = 1.50 * Hexagon.VerticalOffset + 1.50 * Hexagon.HexSize * row;
                         a.DrawHexagon1(g, pen, brush, x, y, Hexagon.HexSize);

                     }

                 }
             }
         }*/
        void deseneaza_piese()
        {
            foreach (Piesa piesa in piese)
            {
                piesa.deseneaza(g);
            }
        }
    }

    public abstract class Piesa
    {
        protected int x, y, w, h;
        public abstract void deseneaza(Graphics g);
        public abstract bool este_deasupra(int x, int y);
        public abstract bool valideaza_mutare(int lStart, int cStart, int lEnd, int cEnd);
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
    public class Pion : Piesa
    {
        Image imgP;
        public Pion(int x, int y, int w, int h)
        {
            this.w = w;
            this.h = h;
            this.x = x - w / 2;  // Setează x la valoarea centrului pe axa orizontală
            this.y = y - h / 2;  // Setează y la valoarea centrului pe axa verticală
            imgP = Image.FromFile("C:\\Users\\ASUS\\Desktop\\Linux-cursuri\\pion.gif");
        }

        public override bool este_deasupra(int x, int y)
        {
            if (x < this.x) return false;
            if (y < this.y) return false;
            if (x > this.x + this.w) return false;
            if (y > this.y + this.h) return false;
            return true;
        }
        public override bool valideaza_mutare(int lStart, int cStart, int lEnd, int cEnd)
        {
            // Calculăm distanța Euclidiană între hexagonul curent și hexagonul destinație
            double distanta = Math.Sqrt(Math.Pow(cEnd - cStart, 2) + Math.Pow(lEnd - lStart, 2));

            // Specificăm valoarea considerată "aproape" (poate fi ajustată în funcție de preferințele tale)
            double distantaAproape = 15;

            // Verificăm dacă distanța este mai mică sau egală cu valoarea "aproape"
            if (distanta <= distantaAproape)
            {
                // Validează aici orice alte reguli specifice pentru mutarea pionului
                // return true sau false în funcție de rezultatul validării
                // ...
                // Exemplu simplu:
                return true; // Mutarea este validă
            }

            return false; // Mutarea nu este aproape de un hexagon vecin
        }
        public override void deseneaza(Graphics g)
        {
            g.DrawImage(imgP, x, y, w, h);
        }

    }
}
