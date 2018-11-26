using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Number_Generator
{
    public partial class Form1 : Form
    {
        static LCG lcg = new LCG(22695477, 1, 4294967296);
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add("Numerical Recipes", "2^32", 1664525, 1013904223);
            dataGridView1.Rows.Add("Borland C/C++", "2^32", 22695477, 1);
            dataGridView1.Rows.Add("GNU Compiler Collection", "2^32", 69069, 5);
            dataGridView1.Rows.Add("ANSI C", "2^32", 1103515245, 12345);
            dataGridView1.Rows.Add("Borland Delphi, Virtual Pascal", "2^32", 134775813, 1);
            dataGridView1.Rows.Add("Microsoft Visual/Quick C/C++", "2^32", 214013, 2531011);
            dataGridView1.Rows.Add("ANSIC", "2^31", 1103515245, 12345);
            dataGridView1.Rows.Add("MINSTD", "2^31-1", 16807, 0);
            dataGridView1.Rows.Add("RANDU", "2^31", 65539, 0);
            dataGridView1.Rows.Add("SIMSCRIPT", "2^31-1", 630360016, 0);
            dataGridView1.Rows.Add("BCSLIB", "2^35", 30517578125, 7261067085);
            dataGridView1.Rows.Add("BCPL", "2^32", 2147001325, 715136305);
            dataGridView1.Rows.Add("URN12", "2^31", 452807053, 0);
            dataGridView1.Rows.Add("APPLE", "2^35", 1220703125, 0);
            dataGridView1.Rows.Add("Super-Duper", "2^32", 69069, 0);
            dataGridView1.Rows.Add("FISH", "2^31-1", 950706376, 0);
            dataGridView1.Rows.Add("SIMULA", "2^35", 30517578125, 0);
            dataGridView1.Rows.Add("DRAND 48", "2^48", 25214903917, 11);
            textBox1.Text = "2^32";
            textBox2.Text = "1664525";
            textBox3.Text = "1013904223";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            long A = Convert.ToInt64( textBox2.Text);
            long C = Convert.ToInt64( textBox3.Text);
            long M = 0;
            if (textBox1.Text.Contains('^'))
            {
                M = LiczWspolczynnikM(textBox1.Text);
            }
            else
            {
                M = Convert.ToInt64( textBox1.Text);
            }

            lcg.A = A;
            lcg.C = C;
            lcg.M = M;
            for (int i = 0; i < Convert.ToInt32(numericUpDown1.Value); i++)
            {
                long X = Math.Abs( lcg.Next() % 700);
                long Y = Math.Abs( lcg.Next() % 700);
                bitmap.SetPixel(Convert.ToInt32( X), Convert.ToInt32(Y), Color.Yellow);
            }
            pictureBox1.Image = bitmap;
        }

        private long LiczWspolczynnikM(string text)
        {
            long M = 0;
            string[] modulo = text.Split('^');
            if (modulo[1].Contains("-"))
            {
                string[] mod2 = modulo[1].Split('-');
                M = Convert.ToInt64((Math.Pow(Convert.ToInt64(modulo[0]), Convert.ToInt64(mod2[0]))) - Convert.ToInt64(mod2[1]));
            }
            else
            {
                M = Convert.ToInt64(Math.Pow(Convert.ToInt64(modulo[0]), Convert.ToInt64(modulo[1])));
            }
            return M;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            Bitmap bitmap2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < Convert.ToInt32(numericUpDown1.Value); i++)
            {
                bitmap2.SetPixel(random.Next(0, 700), random.Next(0, 700), Color.Yellow);
            }
            pictureBox1.Image = bitmap2;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetDataFromDataGrid();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetDataFromDataGrid();
        }
        public void SetDataFromDataGrid()
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
