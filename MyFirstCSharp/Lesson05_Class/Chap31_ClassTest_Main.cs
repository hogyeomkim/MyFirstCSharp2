﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstCSharp.Lesson05_Class
{
    public partial class Chap31_ClassTest_Main : Form
    {
        public Chap31_ClassTest_Main()
        {
            InitializeComponent();
        }

        private void btnMonitering_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"현재 설비의 상태는 ?? 입니다.");
        }

        private void btnRunCall_Click(object sender, EventArgs e)
        {
            // 가동 등록 화면 호출.
            Chap31_ClassTest_Run Cahp31 = new Chap31_ClassTest_Run();

            this.Visible = false; // 현재 화면을 숨김처리. 
            // Show : 비동기. 
            // ShowDialog : 동기.
            Cahp31.ShowDialog();

            this.Visible = true;

        }

        private void btnStopCall_Click(object sender, EventArgs e)
        {
            Chap31_ClassTest_Stop Chap31 =  new Chap31_ClassTest_Stop();
            this.Visible=false; // 숨김
            Chap31.ShowDialog(); // 모달창 ( 동기식으로 호출) 
            this.Visible = true; 
        }
    }
}