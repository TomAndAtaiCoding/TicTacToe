using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool XTurn;
        int turnCnt = 1;
        IList<card> cards = new List<card>();
        int x;
        int y;
        string symbol;
        string CurSymbol;
        string P1Score = "0";
        string P2Score = "0";
        string PNum;
        bool RoWin;
        bool ColumnWin;
        bool RightDiagonalWin;
        bool LeftDiagonalWin;
        card card1;
        card card2;
        card card3;
        card card4;
        card card5;
        card card6;
        card card7;
        card card8;
        card card9;
        card card10;
        card card11;
        card card12;
        card card13;
        card card14;
        card card15;
        card card16;
        public string XTurnStr()
        {
            return string.Format("Current Turn: Player {0} ({1})", PNum, symbol);
        }
        public string CheckByKey(int x, int y)
        {
            if (x < 5 & y < 5)
            {
                return Globals.cards[string.Format("({0},{1})", x, y)].content;
            }
            else
                return "";
        }

        public string score()
        {
            return string.Format("Player 1: {0} | Player 2: {1}", P1Score, P2Score);
        }

        public bool Win(card card)
        {
            x = card.x;
            y = card.y;
            string con = card.content;
            RoWin = con == CheckByKey(1, y) && con == CheckByKey(2, y) && con == CheckByKey(3, x) && con == CheckByKey(4, y);
            ColumnWin = con == CheckByKey(x, 1) && con == CheckByKey(x, 2) && con == CheckByKey(x, 3) && con == CheckByKey(x, 4);
            LeftDiagonalWin = con == CheckByKey(1, 1) && con == CheckByKey(2, 2) && con == CheckByKey(3, 3) && con == CheckByKey(4, 4);
            RightDiagonalWin = con == CheckByKey(4, 1) && con == CheckByKey(3, 2) && con == CheckByKey(2, 3) && con == CheckByKey(1, 4);
            return RoWin || ColumnWin || LeftDiagonalWin || RightDiagonalWin;
        }

        public void buttSlct(card card1)
        {
            XTurn = !(XTurn);
            if(XTurn)
            {
                CurSymbol = "O";
                symbol = "X";
                PNum = "1";
            }
            else
            {
                CurSymbol = "X";
                symbol = "O";
                PNum = "2";
            }
            card1.CardButton.Text = CurSymbol;
            card1.content = CurSymbol;
            if (Win(card1))
            {
                DialogResult NextRound = MessageBox.Show("Congratulations! You, (Player " + PNum + "), Won! You also got a point. Do yo Wish to continue for another round?", "You Won!", MessageBoxButtons.YesNo);
                if (NextRound == DialogResult.Yes)
                {
                    if (XTurn)
                        P1Score = Convert.ToString(int.Parse(P1Score) + 1);
                    else
                        P2Score = Convert.ToString(int.Parse(P2Score) + 1);
                    SetBoard();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                textBox1.Text = XTurnStr();
                textBox2.Text = "Turn Count: " + Convert.ToString(++turnCnt);
                card1.CardButton.Enabled = false;
            }
        }

        public void SetBoard()
        {
            XTurn = true;
            turnCnt = 1;
            PNum = "1";
            symbol = "X";
            textBox1.Text = XTurnStr();
            textBox3.Text = score();
            textBox2.Text = "Turn Count: 0";
            foreach(card card in Globals.cards.Values)
            {
                card.CardButton.Text = "";
                card.content = "";
                card.CardButton.Enabled = true;
            }

        }

        public void  checkDraw()
        {
            if (turnCnt==17)
            {
                MessageBox.Show("The game resulted in a draw! /nYou must both be good players! /nDo you wish to continue?", "Draw!", MessageBoxButtons.YesNo);
                if (DialogResult==DialogResult.Yes)
                {
                    SetBoard();
                }
                else
                {
                    this.Close();
                }
            }
        }

        public void checkWin()
        {

        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttSlct(card1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttSlct(card2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttSlct(card3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttSlct(card4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttSlct(card5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buttSlct(card6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            buttSlct(card7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            buttSlct(card8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            buttSlct(card9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            buttSlct(card10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            buttSlct(card11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            buttSlct(card12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            buttSlct(card13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            buttSlct(card14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            buttSlct(card15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            buttSlct(card16);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            card1 = new card(4, 1, button1);
            card2 = new card(4, 2, button2);
            card3 = new card(4, 3, button3);
            card4 = new card(4, 4, button4);
            card5 = new card(3, 1, button5);
            card6 = new card(3, 2, button6);
            card7 = new card(3, 3, button7);
            card8 = new card(3, 4, button8);
            card9 = new card(2, 1, button9);
            card10 = new card(2, 2, button10);
            card11 = new card(2, 3, button11);
            card12 = new card(2, 4, button12);
            card13 = new card(1, 1, button13);
            card14 = new card(1, 2, button14);
            card15 = new card(1, 3, button15);
            card16 = new card(1, 4, button16);
            SetBoard();
        }
    }
}
