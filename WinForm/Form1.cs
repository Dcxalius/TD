using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        float inputtedMoney;
        int rocketsToAdd;
        int multsToAdd;
        int snipToAdd;
        int freezeToAdd;

        public int[] Adder
        {
            get
            {
                return new int[4] {rocketsToAdd, freezeToAdd, snipToAdd, multsToAdd };
            }
        }

        public float InputtedMoney
        {
            get
            {
                if (inputtedMoney is 0)
                {
                    return 0;
                }
                float money = inputtedMoney;
                InputtedMoney = 0;
                return money;

            }
            private set
            {
                inputtedMoney = value;
            }
        }


        public Form1()
        {
            InitializeComponent();
            InputtedMoney = 0;
            rocketsToAdd = 0;
            multsToAdd = 0;
            snipToAdd = 0;
            freezeToAdd = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputtedMoney = (float) input.Value;
        }

        private void AddRocketsToWishList(object sender, EventArgs e)
        {
            rocketsToAdd += 1;
            RocketAdder.Text = rocketsToAdd.ToString();
        }

        private void AddFreezeToWishList(object sender, EventArgs e)
        {
            freezeToAdd += 1;
            FreezeAdder.Text = freezeToAdd.ToString();
        }

        private void AddMultiToWishList(object sender, EventArgs e)
        {
            multsToAdd += 1;
            MultiAdder.Text = multsToAdd.ToString();
        }

        private void AddSnipeToWishList(object sender, EventArgs e)
        {
            snipToAdd += 1;
            SnipeAdder.Text = snipToAdd.ToString();
        }
    }
}
