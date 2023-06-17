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
        // 사용자 정보를 관리할 리스트 생성
        private List<User> userList;
        // 비밀번호 실패 횟수
        private int passwordFailCount;

        public Final_Exam02_2_Login()
        {
            InitializeComponent();

            // 사용자 리스트 초기화
            userList = new List<User>();
            // 비밀번호 실패 횟수 초기화
            passwordFailCount = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 입력한 사용자 ID와 비밀번호 가져오기
            string userID = txtUserId.Text;
            string password = txtPassWord.Text;

            // 사용자 ID 존재 여부 확인
            bool userExists = userList.Any(user => user.UserID == userID);
            if (!userExists)
            {
                MessageBox.Show("존재하지 않는 ID입니다.");
                return;
            }

            // 비밀번호 일치 여부 확인
            User matchingUser = userList.First(user => user.UserID == userID);

            if (matchingUser.Password == password)
            {
                MessageBox.Show($"{matchingUser.UserName}님 반갑습니다.");

                // 비밀번호 실패 횟수 초기화
                passwordFailCount = 0;
            }
            else
            {
                // 비밀번호 실패 횟수 증가
                passwordFailCount++;

                if (passwordFailCount >= 5)
                {
                    MessageBox.Show("비밀번호가 5회 이상 틀려 프로그램을 종료합니다.");
                    Application.Exit();
                }
                else
                {
                    int remainingAttempts = 5 - passwordFailCount;
                    MessageBox.Show($"비밀번호를 잘못 입력하였습니다. 남은 횟수: {remainingAttempts}회");
                }
            }
        }

        private void btnUserReg11_Click(object sender, EventArgs e)
        {
            // Pass the userList to the Final_Exam02_3_UserReg form
            Final_Exam02_3_UserReg userRegForm = new Final_Exam02_3_UserReg(userList);
            userRegForm.ShowDialog();

            // Update the userList if necessary
            userList = userRegForm.GetRegisteredUsers();
        }




    }
}
