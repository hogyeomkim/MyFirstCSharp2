using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstCSharp
{
    public partial class Final_Exam01 : Form
    {
        public Final_Exam01()
        {
            InitializeComponent();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            int n = 15; // 출력할 개미수열의 번째

            string antSequence = GetAntSequence(n);
            MessageBox.Show($"개미수열 {n}번째: {antSequence}");
        }

        private string GetAntSequence(int n)
        {
            if (n == 1)
            {
                return "1";
            }

            string previousSequence = GetAntSequence(n - 1);
            string currentSequence = "";
            int count = 1;

            for (int i = 1; i < previousSequence.Length; i++)
            {
                if (previousSequence[i] == previousSequence[i - 1])
                {
                    count++;
                }
                else
                {
                    currentSequence += count.ToString() + previousSequence[i - 1];
                    count = 1;
                }
            }

            currentSequence += count.ToString() + previousSequence[previousSequence.Length - 1];

            return currentSequence;
        }
    }





}
