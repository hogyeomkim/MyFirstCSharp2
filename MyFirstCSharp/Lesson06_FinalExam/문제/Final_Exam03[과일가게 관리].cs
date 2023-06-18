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
    public partial class Final_Exam03 : Form
    {
        private int iTotalPrice = 0; // 총 결제 금액  
        public Final_Exam03()
        {
            InitializeComponent();
        }


        private void btnFruit_Click(object sender, EventArgs e)
        {

            Button btnTemp = (Button)sender;
            string sFruitName = btnTemp.Tag.ToString();
            switch (sFruitName)
            {
                // 결제 시 주문 수량 별 처리를 위하여 주문 버튼 클릭 후 
                case "사과":
                    // 사과의 주문 처리
                    FruitInventoryAdj(lblAppCount, sFruitName, 2000);
                    break;
                case "참외":
                    // 참외의 주문 처리 
                    FruitInventoryAdj(lblMelonCount, sFruitName, 2500);
                    break;
                case "수박":
                    // 수박의 주문 처리
                    FruitInventoryAdj(lblW_MCount, sFruitName, 18000);
                    break;
            }
        }


        void FruitInventoryAdj(Label lblFruitCnt, string sFruitName, int iSalePrice)
        {
            int iFruitCount = 0;
            // 과일의 현재 재고 수량이 0 일 경우 리턴. 
            iFruitCount = int.Parse(lblFruitCnt.Text);
            if (iFruitCount == 0)
            {
                MessageBox.Show($"{sFruitName}의 재고 수량이 0 입니다. 주문을 할 수 없습니다.");
                return;
            }

            // 던져주는 과일의 재고 개수 1 차감. 
            --iFruitCount;

            lblFruitCnt.Text = Convert.ToString(iFruitCount);

            // 총 누적 구매 금액
            iTotalPrice += iSalePrice;
        }

        private void btnTotalPrice_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"총 결재 금액은 {iTotalPrice} 입니다.");
        }



        private int custCash = 100000; // 고객 잔액 초기 금액
        private int manCash = 100000; // 관리자 초기 가게 잔액

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (iTotalPrice > custCash)
            {
                MessageBox.Show("결제를 할 수 없습니다. 고객 잔액이 부족합니다.");
                return;
            }

            custCash -= iTotalPrice;
            lblCustCash.Text = custCash.ToString();

            manCash += iTotalPrice;
            lblManCash.Text = manCash.ToString();

            MessageBox.Show("결제가 완료되었습니다.");

            UpdateOrderList();
            ResetOrder();
        }
        private void ResetOrder()
        {
            iTotalPrice = 0;
            orderCount = 0;
            totalOrderPrice = 0;
        }


        private int orderCount = 0; // 주문 수량을 저장할 변수
        private int totalOrderPrice = 0; // 누적된 주문 금액을 저장할 변수
        private void UpdateOrderList()
        {
            int appleCount = 10 - int.Parse(lblAppCount.Text);
            int melonCount = 10 - int.Parse(lblMelonCount.Text);
            int watermelonCount = 10 - int.Parse(lblW_MCount.Text);

            int applePrice = appleCount * 2000;
            int melonPrice = melonCount * 2500;
            int watermelonPrice = watermelonCount * 18000;

            totalOrderPrice += applePrice + melonPrice + watermelonPrice;
            orderCount++;

            string orderDetails = $"누적 주문 금액: {totalOrderPrice}원\r\n";
            orderDetails += $"주문 수량: {orderCount}회\r\n";
            orderDetails += $"사과: {appleCount}개, 금액: {applePrice}원\r\n";
            orderDetails += $"참외: {melonCount}개, 금액: {melonPrice}원\r\n";
            orderDetails += $"수박: {watermelonCount}개, 금액: {watermelonPrice}원\r\n";
            orderDetails += "--------------------\r\n"; // 구분선

            txtOrderList.Text = orderDetails; // 거래 내역을 텍스트 박스에 설정

            txtOrderList.ScrollToCaret(); // 스크롤을 아래로 이동시켜 가장 최근 내용을 볼 수 있도록 합니다.
        }







    }
}