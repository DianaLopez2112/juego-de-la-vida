using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EjemploGraphics
{
    public partial class Form1 : Form
    {
        Graphics g;
        bool[,] mapa;
        bool ban = false;
        public Form1()
        {
            mapa = new bool[12, 12];
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void poneValoresAleatorios(){
            Random x = new Random();

            mapa = new bool[12,12];
            for(int i=0;i<12;i++)
              for(int j=0;j<12;j++){
                    if (x.Next(2) == 1)
                        mapa[i, j] = true;
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // configuracion aleatoria del mapa
            poneValoresAleatorios();
            button2.Enabled = true;

            ban = true;
            dibujaRejilla();
            dibujaMapa();
        }

        private void dibujaRejilla()
        {
            for (int i = 0; i < 250; i += 20)
            {
                g.DrawLine(new Pen(new SolidBrush(Color.White)), 0, i, 250, i);
                g.DrawLine(new Pen(new SolidBrush(Color.White)), i, 0, i, 250);
            }
        }

        private void dibujaMapa()
        {
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, 250, 250);
            for (int i = 0; i < 12; i++)
                for(int j=0;j<12;j++)
                    if(mapa[i,j])
                        g.FillEllipse(new SolidBrush(Color.LightBlue), (i*20)-20, (j*20)-20, 20, 20);    
        }

        private int cuentaVecinos(int i, int j)
        {
            int xInferior, xSuperior;
            int yInferior, ySuperior;

            if (i == 0)
                xInferior = 0;
            else
                xInferior = i - 1;

            if (i == 11)
                xSuperior = i;
            else
                xSuperior = i + 1;

            if (j == 0)
                yInferior = 0;
            else
                yInferior = j - 1;

            if (j == 11)
                ySuperior = j;
            else
                ySuperior = j + 1;

            int conteo = 0;
            for (int x = xInferior; x <= xSuperior; x++)
                for (int y = yInferior; y <= ySuperior; y++)
                    if (mapa[x, y])
                        conteo++;
            if (mapa[i, j])
                conteo--;
            return conteo;
                
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(ban)
            {
                dibujaMapa();
                dibujaRejilla();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ban = false;            
            button2.Enabled = false;
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, 250, 250);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            bool[,] proximaGente = new bool[12, 12];
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    proximaGente[i, j] = mapa[i, j];

            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    switch (cuentaVecinos(i, j))
                    {
                        case 0:
                        case 1: proximaGente[i, j] = false;
                            break;
                        case 2: proximaGente[i, j] = mapa[i, j];
                            break;
                        case 3: proximaGente[i, j] = true;
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8: proximaGente[i, j] = false;
                            break;
                    }
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    mapa[i, j] = proximaGente[i, j];
            dibujaMapa();
            dibujaRejilla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("¿Deseas Salir?", "Precaución", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (a == DialogResult.Yes)
                Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            mapa = new bool[12,12];
            mapa[4,4] = true;
            mapa[5,4] = true;
            mapa[6,4] = true;
            mapa[7,4] = true;
            mapa[8,4] = true;
            mapa[4,6] = true;
            mapa[8,6] = true;
            mapa[4,8] = true;
            mapa[5,8] = true;
            mapa[6,8] = true;
            mapa[7,8] = true;
            mapa[8,8] = true;
            button2.Enabled = true;

            ban = true;
            dibujaRejilla();
            dibujaMapa();
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mapa = new bool[12, 12];
            mapa[6, 6] = true;
            mapa[6, 7] = true;
            mapa[6, 5] = true;
            mapa[5, 6] = true;
            mapa[7, 7] = true;
            button2.Enabled = true;
            ban = true;
            dibujaRejilla();
            dibujaMapa();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mapa = new bool[12, 12];
            mapa[4, 7] = true;
            mapa[4, 8] = true;
            mapa[5, 7] = true;
            mapa[5, 8] = true;
            mapa[6, 7] = true;
            mapa[7, 7] = true;
            mapa[8, 7] = true;
            mapa[8, 8] = true;
            mapa[8, 9] = true;
            mapa[7, 9] = true;
            mapa[6, 9] = true;
            mapa[4, 6] = true;
            mapa[4, 7] = true;
            mapa[4, 8] = true;
            mapa[4, 9] = true;
            mapa[4,10] = true;
            mapa[3, 6] = true;
            mapa[3, 7] = true;
            mapa[3, 9] = true;
            mapa[2, 9] = true;
            mapa[2, 8] = true;
            mapa[2, 7] = true;
            button2.Enabled = true;
            ban = true;
            dibujaRejilla();
            dibujaMapa();
          
        }
    }
}