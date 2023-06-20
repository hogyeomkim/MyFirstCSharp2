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
    public partial class Final_Exam02_2_Login : Form
    {
        // 사용자 정보 리스트 생성
        private List<User> userList;

        public Final_Exam02_2_Login()
        {
            InitializeComponent();

            // 사용자 리스트를 새롭게 정의
            userList = new List<User>();
        }

        // 로그인 버튼을 클릭했을 때
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 입력 ID와 비밀번호 텍스트를 들고와서 변수에 담기
            string userID = txtUserId.Text;
            string password = txtPassWord.Text;

            // 사용자 ID가 등록되어 있는지 확인하기.
            User matchingUser = userList.FirstOrDefault(user => user.UserID == userID);
            if (matchingUser == null)
            {
                MessageBox.Show("존재하지 않는 ID입니다.");
                return;
            }

            // 비밀번호는 일치하는가? 일치하면 반갑고 아니면 비밀번호 오류 횟수 나타내기
            if (matchingUser.Password == password)
            {
                MessageBox.Show($"{matchingUser.UserName}님 반갑습니다.");

                // 비밀번호 실패 횟수 0으로 리셋
                matchingUser.PasswordFailCount = 0;
            }
            else
            {
                // 비밀번호 실패 횟수 1씩 증가
                matchingUser.PasswordFailCount++;

                if (matchingUser.PasswordFailCount >= 5)
                {
                    MessageBox.Show("비밀번호가 5회 이상 틀려 프로그램을 종료합니다.");
                    Application.Exit();
                }
                else
                {
                    int remainingAttempts = 5 - matchingUser.PasswordFailCount;
                    MessageBox.Show($"비밀번호를 잘못 입력하였습니다. 남은 횟수: {remainingAttempts}회");
                }
            }
        }

        // 사용자 등록 버튼 눌렀을 때
        private void btnUserReg11_Click(object sender, EventArgs e)
        {
            Final_Exam02_3_UserReg userregister = new Final_Exam02_3_UserReg(userList);
            userregister.ShowDialog();
        }
    }
    
}


// 변수 개념 정리하기


/*Final_Exam02_2_Login 클래스:

private List<User> userList;: 사용자 정보를 관리하기 위한 List<User> 변수

private int passwordFailCount;: 비밀번호 틀린횟수 저장하는 변수

public Final_Exam02_2_Login(): 클래스의 생성자입니다. 폼, userList, passwordFailCount를 초기화 시킨다.


사용자 ID가 리스트에 존재하는지 확인합니다.
비밀번호를 확인하여 일치하는 경우 사용자를 환영하는 메시지를 표시하고 passwordFailCount를 초기화합니다.
비밀번호가 일치하지 않는 경우, passwordFailCount를 증가시키고, 5회 이상 실패한 경우 프로그램을 종료합니다.
btnUserReg11_Click: 사용자 등록 버튼 클릭 이벤트 핸들러입니다. 사용자 등록 폼(Final_Exam02_3_UserReg)의 인스턴스를 생성하고, 현재의 userList를 전달하여 폼을 표시합니다.




Final_Exam02_3_UserReg 클래스:

private List<User> userList;: 사용자 정보를 관리하기 위한 List<User> 타입의 변수입니다.

public User UserInfo { get; private set; }: 등록된 사용자 정보를 외부로 전달하기 위한 속성입니다.

public Final_Exam02_3_UserReg(): 클래스의 생성자입니다. 폼을 초기화하고, userList를 초기화합니다.

btnUserReg_Click: 사용자 등록 버튼 클릭 이벤트 핸들러입니다. 입력한 사용자 정보를 가져와서 다음을 수행합니다:

중복 ID인지 확인합니다.
새로운 사용자 객체를 생성하고 userList에 추가합니다.
등록 완료 메시지를 표시하고, 입력 필드를 초기화합니다.
btnClose_Click: 폼을 닫는 코드

 */