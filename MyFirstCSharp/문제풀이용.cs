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
    public partial class 문제풀이용 : Form
    {
        public 문제풀이용()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 2개의 데이터 추출 해서
            //합한 값이 16이 되는 모든 쌍 구하기
            // 중복 되는 데이터 쌍 도 허용

            //배열 만들기

            int[] ivalues = { 1, 4, 6, 9, 10, 12, 16 };

            string 찾은값 = string.Empty;
                    
            for ( int i = 0; i < ivalues.Length; i++ )
            {
                int iResult = -1;
                int iFindValue = 16 - ivalues[i];

                iResult = Array.IndexOf(ivalues, iFindValue);
                sFindValues +=${ { { ivalues[i] } } }
            }
        }
    }
}
