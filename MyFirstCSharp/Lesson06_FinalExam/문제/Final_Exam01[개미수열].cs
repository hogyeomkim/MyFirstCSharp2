using System;
using System.Text;
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
            int n = 15;                                                 // 출력할 15 번째 개미수열

            string antSequence = GenerateAntSequence(n);                // 개미수열을 생성하는 메서드를 호출하여
                                                                        // n번째 개미수열을 생성하고 결과를 antSequence 변수에 저장

            MessageBox.Show($"개미수열 {n}번째: {antSequence}");        // 메시지 박스로 개미수열을 출력
        }

        /// <summary>
        /// 주어진 번째의 개미수열을 생성하는 메서드입니다.
        /// </summary>
        /// <param name="n">개미수열의 번째</param>
        /// <returns>개미수열 문자열</returns>
        /// 

        private string GenerateAntSequence(int n)
        {
            StringBuilder sequence = new StringBuilder("1");                    // 초기 개미수열을 "1"로 설정

            // n번째 개미수열을 생성하기 위한 반복문
            for (int i = 1; i < n; i++)
            {
                StringBuilder nextSequence = new StringBuilder();
                int count = 1;
                char currentChar = sequence[0];                                 // 현재 숫자기록하는 변수 추가

                // 현재 개미수열을 순회하며 다음 개미수열을 생성
                for (int j = 1; j < sequence.Length; j++)
                {
                    if (sequence[j] == currentChar)                             // 현재 숫자와 이전 숫자가 동일하다면
                    {
                        count++;                                                // 연속된 숫자의 개수(count)를 증가
                    }
                    else
                    {
                        nextSequence.Append(currentChar).Append(count);         // 현재 숫자와 연속된 숫자의 개수를 StringBuilder에 추가
                        count = 1;                                              // 새로운 연속된 숫자의 개수를 1로 초기화
                        currentChar = sequence[j];                              // 현재 숫자를 갱신
                    }
                }

                nextSequence.Append(currentChar).Append(count);                 // 마지막 숫자와 연속된 숫자의 개수를 StringBuilder에 추가
                sequence = nextSequence;                                        // 다음 번째 개미수열을 현재 개미수열로 설정
            }

            return sequence.ToString();                                         // 최종적으로 생성된 개미수열을 문자열 형태로 반환
        }
    }
}
