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
    public partial class Final_Exam02_3_UserReg : Form
    {
        // 사용자 정보를 관리할 리스트 생성
        private List<User> userList;

        public Final_Exam02_3_UserReg()
        {
            InitializeComponent();

            // 사용자 리스트 초기화
            userList = new List<User>();
        }

        private void btnUserReg_Click(object sender, EventArgs e)
        {
            // 입력한 사용자 정보 가져오기
            string userID = txtUserId.Text;
            string password = txtPassWord.Text;
            string userName = txtUserName.Text;
            string mailAddress = txtMailAddress.Text;

            // 중복 ID 체크
            bool isDuplicateID = userList.Any(user => user.UserID == userID);
            if (isDuplicateID)
            {
                MessageBox.Show("이미 존재하는 ID입니다. 다른 ID를 입력해주세요.");
                return;
            }

            // 사용자 객체 생성
            User newUser = new User(userID, password, userName, mailAddress);

            // 사용자 등록
            userList.Add(newUser);

            // 등록 완료 메시지 출력
            MessageBox.Show("사용자 등록이 완료되었습니다.");

            // 등록 후 입력 필드 초기화
            txtUserId.Text = "";
            txtPassWord.Text = "";
            txtUserName.Text = "";
            txtMailAddress.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

    }
}
