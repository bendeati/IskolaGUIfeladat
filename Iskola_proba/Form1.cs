﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iskola_proba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("nevekGUI.txt", Encoding.UTF8);
            string sor = ""; //nincs fejléc adatsor
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                listBox1.Items.Add(sor);
            }
            sr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("nincs kiválasztva semmi!");
            }
            else
            {
                int hanyadik = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(hanyadik);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("nevekNEW.txt");
                foreach (var elem in listBox1.Items)
                {
                    sw.WriteLine(elem);
                }
                sw.Close();
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }
        }
    }
}
