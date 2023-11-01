using POO_proiect_cu_clase;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Threading;
using System.Windows.Forms;
namespace Proiect_poo_sesiune
{
    public partial class Form1 : Form
    {
        int nrmutari = 20;
        Random scorad=new Random();
        int scor_curent = 0;
        int k = 0;
        Image img;
        Graphics g;
        //=================
        JocSah joc;
        //=================
        bool apasat = false;
        System.Windows.Forms.Timer timer;
        int countdownSeconds = 300;

        public Form1()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Intervalul de 1 secundă
            timer.Tick += timer1_Tick;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countdownSeconds--;

            if (countdownSeconds == 0)
            {
                timer.Stop();
                timp.Text = "Countdown a expirat!";
            }
            else
            {
                timp.Text = "Timp rămas: " + countdownSeconds + " secunde";
                label1.Text = "Timp scurs: " + (300 - countdownSeconds) + " secunde";
            }
        }

        public void StartCountdown()
        {
            timer.Start();
        }
        public void Countdown(int durationInSeconds)
        {
            for (int i = durationInSeconds; i > 0; i--)
            {
                // Actualizați eticheta cu timpul rămas
                timp.Text = "Timp rămas: " + i + " secunde";

                // Pauză de 1 secundă
                Thread.Sleep(1000);
            }

            // Countdown-ul a expirat
            timp.Text = "Countdown a expirat!";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel3.Refresh();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ExportPanel(panel3, "C:\\Users\\ASUS\\Desktop\\Linux-cursuri\\testexport.png", ImageFormat.Png);
        }
        public void ExportPanel(Panel panel, string filePath, ImageFormat format)
        {
            // Creați un obiect Bitmap pentru a reprezenta conținutul panoului
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);

            // Desenați conținutul panoului pe bitmap
            panel.DrawToBitmap(bitmap, new Rectangle(0, 0, panel.Width, panel.Height));

            // Salvați bitmap-ul în fișierul specificat cu formatul specificat
            bitmap.Save(filePath, format);

            // Eliberați resursele
            bitmap.Dispose();

            Console.WriteLine("Exportul panoului a fost finalizat.");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel4.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //joc.deseneaza();
            Tabla_de_joc.dim = 5;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel1.Visible = false;
            joc.JocNou();
            StartCountdown(); // Începe countdown-ul
            panel3.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tabla_de_joc.dim = 7;
            panel2.Visible = false;
            panel1.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = true;
            joc.JocNou();
            StartCountdown();
            panel3.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            scor();
            Tabla_de_joc.dim = 9;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            joc.JocNou();
            StartCountdown();
            panel3.Refresh();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel5.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = true;
            if (scor_curent > 0)
                panel6.Visible = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(img, 0, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Parent=this;
            panel2.Parent = this;
            panel3.Parent = this;
            panel4.Parent = this;
            panel5.Parent = this;
            panel6.Parent = this;
            img = new Bitmap(panel3.Width, panel3.Height);
            g = Graphics.FromImage(img);
            joc = new JocSah(img.Width, img.Height, g);
            List<LeaderboardEntry> leaderboard = Leaderboard.GetLeaderboard();

            // Crează un control DataGridView
            DataGridView dataGridViewLeaderboard = new DataGridView();
            dataGridViewLeaderboard.DataSource = leaderboard;
            dataGridViewLeaderboard.Dock = DockStyle.Fill; // Ajustează la umplerea completă a panelului

            // Adaugă DataGridView la panel4
            panel4.Controls.Add(dataGridViewLeaderboard);

            LoadLeaderboard();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            apasat = true;
            joc.selecteaza_piesa(e.X, e.Y);
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (apasat)
            {
                joc.muta_piesa(e.X, e.Y);
                panel3.Refresh();
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            //int k = 0;
            if (jocruleaza())
            {
                scor_curent += scorad.Next(0, 20);
                apasat = false;
                //joc.elibereaza_piesa(e.X, e.Y);
                panel3.Refresh();
                panel6.Visible = true;
                scor();
                Nr_click.Text = "Numarul de mutari disponibil: " + nrmutari;
                nrmutari--;
            }
            else
            {
                if (nrmutari < 1)
                {
                    //panel3.Visible = false;
                    panel6.Visible = true;
                }
                panel3.Refresh();
                if (k<1)
                {
                    scor_curent += countdownSeconds + nrmutari;
                    k++;
                    label10.Text += scor_curent;
                }
                //k++;
                    //scor();
                    panel6.BringToFront();
                    panel6.Visible = true;
                    panel3.Refresh();
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            PrintPanel(panel3);

        }
        public void PrintPanel(Panel panel)
        {
            // Creați o instanță a clasei PrintDocument
            PrintDocument printDoc = new PrintDocument();

            // Atașați evenimentul PrintPage
            printDoc.PrintPage += (sender, e) =>
            {
                // Obțineți grafica pentru imprimare
                Graphics graphics = e.Graphics;

                // Creați un obiect Bitmap pentru a reprezenta conținutul panoului
                Bitmap bitmap = new Bitmap(panel.Width, panel.Height);

                // Desenați conținutul panoului pe bitmap
                panel.DrawToBitmap(bitmap, new Rectangle(0, 0, panel.Width, panel.Height));

                // Desenați bitmap-ul pe grafica de imprimare
                graphics.DrawImage(bitmap, new Point(0, 0));

                // Specificați că mai există pagini de imprimat
                e.HasMorePages = false;
            };

            // Deschideți dialogul de imprimare
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Începeți procesul de imprimare
                printDoc.Print();
            }
        }
        public void scor()
        {
            Scor.Text = "Scorul tau este: " + scor_curent;
        }
        private void LoadLeaderboard()
        {
            List<LeaderboardEntry> leaderboard = Leaderboard.GetLeaderboard();

            // Crează un control DataGridView
            DataGridView dataGridViewLeaderboard = new DataGridView();
            dataGridViewLeaderboard.DataSource = leaderboard;
            dataGridViewLeaderboard.Dock = DockStyle.Fill; // Ajustează la umplerea completă a panelului

            // Adaugă DataGridView la panel4
            panel4.Controls.Add(dataGridViewLeaderboard);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel5.Visible= false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel3.Visible= true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Scor_Click(object sender, EventArgs e)
        {

        }
        bool jocruleaza()
        { while (scor_curent >= 0 && countdownSeconds > 0 && nrmutari >0)
            {
                //nrmutari--;
                return true;
            }
            apasat = false;
            return false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string textToAppend = "\n"+nume.Text+":"+scor_curent+":"+data.Text;
            string filePath = "C:\\Users\\ASUS\\source\\repos\\Proiect_poo_sesiune\\Proiect_poo_sesiune\\TextFile1.txt";

            File.AppendAllText(filePath, textToAppend);
            panel1.Visible = true;
            panel6.Visible = false;
            panel3.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("C:\\Users\\ASUS\\source\\repos\\Proiect_poo_sesiune\\Proiect_poo_sesiune\\TextFile1.txt", false);
            writer.Write(string.Empty);
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string textToAppend = "\n" +numericUpDown1.Value+":" +comboBox1.Text + ":" + numericUpDown2.Value+":"+numericUpDown3.Value;
            string filePath = "C:\\Users\\ASUS\\source\\repos\\Proiect_poo_sesiune\\Proiect_poo_sesiune\\Configurare.txt";

            File.AppendAllText(filePath, textToAppend);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}