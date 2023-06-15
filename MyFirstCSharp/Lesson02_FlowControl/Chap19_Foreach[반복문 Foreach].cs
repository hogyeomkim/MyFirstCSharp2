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
    public partial class Chap19_Foreach : Form
    {
        // Foreach 
        // - 열거형 데이터 자료구조 에서 데이터를 추출할때 사용.
        //  . 열거형 자료구조 :  데이터 자료가 동일한경우 하나의 열거형 데이터로 집합 할수 있는 자료구조
        //                      배열, 문자열, 리스트... 
        // - 조건의 끝을 지정해 주는 반복문 (for, while) 과는 달리 
        //   자료형 구조가 포함하고 있는 데이터의 수에 따라 반복하므로 
        //   반드시 종료가 되는 반복문.

        public Chap19_Foreach()
        {
            InitializeComponent();
        }

        private void btnStringForeach_Click(object sender, EventArgs e)
        {
            // TItle 라벨에 등록되어있는 문자열 의 문자를 하나씩 추출한다. 

            // 1. 입력한 문자 정보 받아오기.
            // Length : 배열에 있는 데이터의 개수.
            // txtInputWord.Text 가 문자 열 (문자의 배열) length 를 사용할 수 있다. 
            if (txtInputWord.Text.Length > 1)
            {
                MessageBox.Show("한글자 이상은 처리할 수 없습니다.");
                return;
            }

            // 글자 하나 , 문자 를 변수.
            char cValue = Convert.ToChar(txtInputWord.Text);

            // 라벨의 Title 글귀를 담을 변수.
            string sTitle = lblTitle.Text;
            
            //     (단위 데이터 자료 구조  in  집합 자료 구조)
            bool bFindFlag = false;// 같은 값을 찾았을때 True 
            foreach(char c in sTitle)
            {
                if (cValue == c)
                {
                    bFindFlag = true;
                }
            }
            /*주어진 코드에서는 foreach 반복문을 사용하여 sTitle 문자열의 각 문자 c를 순차적으로 반복합니다. 
             * 각 반복에서 코드는 cValue (입력한 문자)가 현재 문자 c와 동일한지 확인합니다. 일치하는 경우, 
             * bFindFlag를 true로 설정하여 입력한 문자가 문자열에 포함되어 있는지를 나타냅니다.*/

            string sMessage = string.Empty;
            if (bFindFlag) 
            {
                sMessage = $"{cValue} 문자는 포함되어있습니다.";
            }
            else
            {
                sMessage = $"{cValue}문자가 포함되어있지 않습니다.";
            }
            MessageBox.Show(sMessage);
        }

        private void btnArrayForeach_Click(object sender, EventArgs e)
        {
            // 숫자형 배열에서 추출.
            int[] iValues = { 1, 2, 3, 4, 5, 6 };

            // ForEach 가 반복하는 횟수.
            int iCount = 0;

            foreach(int iValue in iValues)
            {
                MessageBox.Show($"배열 의 {iCount} 번째 주소에 있는 값 은 {iValue} 입니다.");
                iCount++;
            }

            MessageBox.Show($"배열의 모든 데이터 수는 {iCount} 개 입니다."); // 배열의 총 개수
            MessageBox.Show($"배열의 마지막 index 정보는 {iCount - 1} 입니다."); // 배열의 index
        }

        private void btnAllClear_Click(object sender, EventArgs e)
        {
            // 컨테이터 안에 있는 텍스트 박스 일괄 초기화 하기.

            // 아래의 로직은 확장성과 유지보수성이 떨어지며 
            // 반복적으로 표현하는 구문이 존재하므로 비 효율적인 코딩이 될 수 있다.
            //textBox1.Text = "";
            //textBox2.Text = "";
            //textBox3.Text = "";
            //textBox4.Text = "";
            ////  .........
            //textBox17.Text = "";
            //textBox17.Text = "";
            textBox1.Clear();
            // 그룹박스에 포함되어있는 컨트롤 (도구) 를 하나씩 추출하여 
            // 텍스트 박스 일 경우 텍스트 속성의 내용을 지우는 로직 을 구현.
            // Winform 에서는 도구 의 클래스 를 (Control, Component) 라고 부른다. 

            // 그룹 박스의 컨트롤 들을 하나씩 추출 하여 컨트롤 클래스 MyControl로 받아낸다. 
            foreach (Control MyControl    in grpControls.Controls)
            { 
                // is : 해당 클래스 인지, 해당 클랫를 상속 받았는지 에 대한 여부 판단후 결과를 반환.
                // 만약에 MyControl 이 TextBox 유형이면.
                if (MyControl is TextBox)
                {
                    MyControl.Text = "";
                    //TextBox text0001 = (TextBox)MyControl;
                    //text0001.Clear();
                }
            }
        }
    }/*btnAllClear_Click 메소드는 클릭 이벤트 핸들러로, 텍스트 박스를 일괄적으로 초기화하는 기능을 제공합니다.

주석으로 처리된 코드들은 각각의 텍스트 박스를 직접 지우는 방식이지만, 확장성과 유지보수성이 낮으며 반복적인 코드로 인해 비효율적입니다.

textBox1.Clear();를 사용하여 textBox1의 텍스트를 초기화합니다.

foreach 반복문을 사용하여 grpControls 그룹 박스에 포함된 컨트롤(도구)을 하나씩 추출합니다. WinForm에서 컨트롤은 Control 또는 Component 클래스로 표현됩니다.

추출한 컨트롤을 MyControl 변수에 담습니다.

is 연산자를 사용하여 MyControl이 TextBox 형식인지 확인합니다.

MyControl이 TextBox 형식인 경우, 텍스트 속성(Text)의 내용을 지웁니다.

선택적으로, MyControl을 TextBox 형식으로 명시적으로 캐스팅한 후 `Clear*/
} 