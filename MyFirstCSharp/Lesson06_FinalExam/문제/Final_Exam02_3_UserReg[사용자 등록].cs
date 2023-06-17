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

        // 생성자에 userList 매개변수 추가
        public Final_Exam02_3_UserReg(List<User> userList)
        {
            InitializeComponent();

            // 사용자 리스트 초기화
            this.userList = userList;
        }

        /// <summary>
        /// 사용자 등록 버튼 누르면 어떤 기능이 동작하는가??
        /// </summary>
        private void btnUserReg_Click(object sender, EventArgs e)
        {
            // 입력한 사용자 정보 가져오기 비밀번호, 아이디, 이름, 이메일
            string userID = txtUserId.Text;
            string password = txtPassWord.Text;
            string userName = txtUserName.Text;
            string mailAddress = txtMailAddress.Text;

            // 중복 ID 체크(중복발생시 등록 x)
            bool isDuplicateID = userList.Any(user => user.UserID == userID);
            if (isDuplicateID)
            {
                MessageBox.Show("이미 존재하는 ID입니다. 다른 ID를 입력해주세요.");
                return;
            }

            // 사용자 객체 생성한 후
            User newUser = new User(userID, password, userName, mailAddress);

            // 사용자 등록하기
            userList.Add(newUser);

            // 등록 완료 메시지 출력
            MessageBox.Show("사용자 등록이 완료되었습니다.");

            // 등록 후 입력 필드 초기화(무조건 해야함)
            txtUserId.Text = "";
            txtPassWord.Text = "";
            txtUserName.Text = "";
            txtMailAddress.Text = "";
        }

        /// <summary>
        /// 닫기 버튼 클릭 했을때 모든 콘솔말고 한개만 닫히게하기.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 현재 폼만을 닫기
            this.Close();
        }
    }
}
