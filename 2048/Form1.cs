using System;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        private Button[,] cells;
        private int[,] numbers = new int[4, 4];
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            cells = new Button[,]
            {
                {button1, button2, button3, button4},
                {button5, button6, button7, button8},
                {button9, button10, button11, button12},
                {button13, button14, button15, button16},
            };
            Gay2048();
        }

        private void Gay2048()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    numbers[i, j] = 0;

            RandomNum();
            RandomNum();
            Obnova();
        }

        private void RandomNum()
        {
            int x, y;
            do
            {
                x = rand.Next(0, 4);
                y = rand.Next(0, 4);
            } while (numbers[x, y] != 0);
            numbers[x, y] = rand.Next(1, 3) * 2;
        }

        private void Obnova()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    cells[i, j].Text = numbers[i, j] != 0 ? numbers[i, j].ToString() : "";
                }
        }

        private void MoveLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (numbers[i, j] != 0)
                    {
                        int target = j;
                        while (target > 0 && numbers[i, target - 1] == 0)
                        {
                            numbers[i, target - 1] = numbers[i, target];
                            numbers[i, target] = 0;
                            target--;
                        }
                        if (target > 0 && numbers[i, target - 1] == numbers[i, target])
                        {
                            numbers[i, target - 1] *= 2;
                            numbers[i, target] = 0;
                        }
                    }
                }
            }
            RandomNum();
            Obnova();
        }

        private void MoveRight()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j >= 0; j--)
                {
                    if (numbers[i, j] != 0)
                    {
                        int target = j;
                        while (target < 3 && numbers[i, target + 1] == 0)
                        {
                            numbers[i, target + 1] = numbers[i, target];
                            numbers[i, target] = 0;
                            target++;
                        }
                        if (target < 3 && numbers[i, target + 1] == numbers[i, target])
                        {
                            numbers[i, target + 1] *= 2;
                            numbers[i, target] = 0;
                        }
                    }
                }
            }
            RandomNum();
            Obnova();
        }

        private void MoveUp()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 1; i < 4; i++)
                {
                    if (numbers[i, j] != 0)
                    {
                        int target = i;
                        while (target > 0 && numbers[target - 1, j] == 0)
                        {
                            numbers[target - 1, j] = numbers[target, j];
                            numbers[target, j] = 0;
                            target--;
                        }
                        if (target > 0 && numbers[target - 1, j] == numbers[target, j])
                        {
                            numbers[target - 1, j] *= 2;
                            numbers[target, j] = 0;
                        }
                    }
                }
            }
            RandomNum();
            Obnova();
        }

        private void MoveDown()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 2; i >= 0; i--)
                {
                    if (numbers[i, j] != 0)
                    {
                        int target = i;
                        while (target < 3 && numbers[target + 1, j] == 0)
                        {
                            numbers[target + 1, j] = numbers[target, j];
                            numbers[target, j] = 0;
                            target++;
                        }
                        if (target < 3 && numbers[target + 1, j] == numbers[target, j])
                        {
                            numbers[target + 1, j] *= 2;
                            numbers[target, j] = 0;
                        }
                    }
                }
            }
            RandomNum();
            Obnova();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MoveLeft();
        }
        private void button19_Click(object sender, EventArgs e)
        {
            MoveRight();
        }
        private void button17_Click(object sender, EventArgs e) 
        { 
            MoveUp(); 
        }
        private void button20_Click(object sender, EventArgs e) 
        { 
            MoveDown(); 
        }
    }
}
