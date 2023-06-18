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


        private int appleCountPrev = 10; // 이전 사과 주문 수량
        private int melonCountPrev = 10; // 이전 참외 주문 수량
        private int watermelonCountPrev = 10; // 이전 수박 주문 수량

        private void btnFruit_Click(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            string sFruitName = btnTemp.Tag.ToString();
            switch (sFruitName)
            {
                case "사과":
                    FruitInventoryAdj(lblAppCount, sFruitName, 2000);
                    break;
                case "참외":
                    FruitInventoryAdj(lblMelonCount, sFruitName, 2500);
                    break;
                case "수박":
                    FruitInventoryAdj(lblW_MCount, sFruitName, 18000);
                    break;
            }
        }

        void FruitInventoryAdj(Label lblFruitCnt, string sFruitName, int iSalePrice)
        {
            int iFruitCount = 0;
            iFruitCount = int.Parse(lblFruitCnt.Text);
            if (iFruitCount == 0)
            {
                MessageBox.Show($"{sFruitName}의 재고 수량이 0 입니다. 주문을 할 수 없습니다.");
                return;
            }

            // 과일의 재고 수량을 1 차감
            --iFruitCount;
            lblFruitCnt.Text = Convert.ToString(iFruitCount);

            // 주문 금액을 총 결제 금액에 추가
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
                // 이전에 누른 과일 주문으로 과일 재고 복원
                lblAppCount.Text = Convert.ToString(appleCountPrev);
                lblMelonCount.Text = Convert.ToString(melonCountPrev);
                lblW_MCount.Text = Convert.ToString(watermelonCountPrev);
                return;
            }

            custCash -= iTotalPrice;
            lblCustCash.Text = custCash.ToString();

            manCash += iTotalPrice;
            lblManCash.Text = manCash.ToString();

            MessageBox.Show("결제가 완료되었습니다.");

            // 결제 완료 후 현재 주문 값을 이전 주문 값으로 저장
            appleCountPrev = int.Parse(lblAppCount.Text);
            melonCountPrev = int.Parse(lblMelonCount.Text);
            watermelonCountPrev = int.Parse(lblW_MCount.Text);

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

            string orderDetails = $"누적 주문 금액: {totalOrderPrice}원\r\n";         
            orderDetails += $"사과: {appleCount}개, 금액: {applePrice}원\r\n";
            orderDetails += $"참외: {melonCount}개, 금액: {melonPrice}원\r\n";
            orderDetails += $"수박: {watermelonCount}개, 금액: {watermelonPrice}원\r\n";
            orderDetails += "--------------------\r\n"; // 구분선

            txtOrderList.Text = orderDetails; // 거래 내역을 텍스트 박스에 설정

            txtOrderList.ScrollToCaret(); // 스크롤을 아래로 이동시켜 가장 최근 내용을 볼 수 있도록 합니다.
        }


        private string canceledInvoiceText = ""; // 취소된 발주 내역을 저장할 변수

        private void btnOrderCancle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderList.Text))
            {
                MessageBox.Show("상품이 없어서 취소할 내역이 없습니다.");
                return;
            }

            // 발주 내역 초기화
            canceledInvoiceText = txtOrderList.Text; // 취소된 발주 내역을 저장

            txtOrderList.Clear();

            // 주문 내역 초기화
            ResetOrder();

            // 재고 수량 복원
            lblAppCount.Text = "10";
            lblMelonCount.Text = "10";
            lblW_MCount.Text = "10";

            // 고객 잔액 초기화
            custCash = 100000;
            lblCustCash.Text = custCash.ToString();

            // 관리자 잔액 초기화
            manCash = 100000;
            lblManCash.Text = manCash.ToString();

            MessageBox.Show("주문이 취소되었습니다. 잔액이 초기화되었습니다.");
        }

        

        private void btnFruitInvoice_Click(object sender, EventArgs e)
        {
            int appleCount = 0;
            int melonCount = 0;
            int watermelonCount = 0;

            // 발주 수량을 입력받아 변수에 저장
            int.TryParse(txtAppleInvoieCount.Text, out appleCount);
            int.TryParse(txtMelonInvoieCount.Text, out melonCount);
            int.TryParse(txtW_MInvoieCount.Text, out watermelonCount);

            if (!string.IsNullOrEmpty(canceledInvoiceText))
            {
                txtOrderList.Text = canceledInvoiceText;
                canceledInvoiceText = ""; // 초기화된 발주 내역을 비움
            }

            // 발주 내역이 없을 경우 메시지 표시
            if (appleCount == 0 && melonCount == 0 && watermelonCount == 0)
            {
                MessageBox.Show("발주 내역이 없습니다.");
                return;
            }

            // 발주 수량이 입력되지 않은 경우 0으로 처리
            if (string.IsNullOrWhiteSpace(txtAppleInvoieCount.Text))
                appleCount = 0;
            if (string.IsNullOrWhiteSpace(txtMelonInvoieCount.Text))
                melonCount = 0;
            if (string.IsNullOrWhiteSpace(txtW_MInvoieCount.Text))
                watermelonCount = 0;

            // 발주 금액 계산
            int applePrice = 2000;
            int melonPrice = 2500;
            int watermelonPrice = 18000;

            int totalPrice = appleCount * applePrice + melonCount * melonPrice + watermelonCount * watermelonPrice;

            // 총 발주 금액이 가게 잔액보다 클 경우 메시지 표시
            int storeBalance = int.Parse(lblManCash.Text);

            if (totalPrice > storeBalance)
            {
                MessageBox.Show("발주 할 수 없습니다.");
                return;
            }

            // 발주가 정상적으로 이루어진 경우 가게 잔액 차감 및 발주 내역 표시
            storeBalance -= totalPrice;

            lblManCash.Text = storeBalance.ToString();

            string invoiceText = "";

            if (appleCount > 0)
            {
                int appleInvoicePrice = (int)(appleCount * applePrice * 0.6);
                invoiceText += $"사과: {appleCount}개, 발주비용 {appleInvoicePrice}원\r\n";
            }

            if (melonCount > 0)
            {
                int melonInvoicePrice = (int)(melonCount * melonPrice * 0.6);
                invoiceText += $"참외: {melonCount}개, 발주비용 {melonInvoicePrice}원\r\n";
            }

            if (watermelonCount > 0)
            {
                int watermelonInvoicePrice = (int)(watermelonCount * watermelonPrice * 0.6);
                invoiceText += $"수박: {watermelonCount}개, 발주비용 {watermelonInvoicePrice}원\r\n";
            }

            txtOrderList.Text += invoiceText;

            MessageBox.Show("발주가 완료되었습니다.");
        }

    }
}

/*
        * 발생한문제
        * 1. 주문버튼을 누를때 결제버튼과 상관없이 10만원에서 자동차감된다.
        * 2. 결제완료가되면 차감된 값이 변경되어 적용되나 결제가 되지않더라도 이미 값이 변경되어있다...
        * 3. 그래서 5천원이 남아있다면, 수박은 잔액부족으로 결제실패가 된다. 근데 2500원인 참외도 사지지않는다.
        * 4. 결제할 수 없을때 이미 누른 과일주문으로 과일 재고가 이전으로 되돌아가지않는다.
        * 5. 취소버튼을 눌럿을때 초기화는 쉬운데 직전단계로 돌리는걸 못하겠다.
        * 
        * 해결한 문제
        * 4번만 해결..
        *
        *주문버튼을 누를때 잔고에서 금액이 자동차감되는걸 어떻게해야 막을 수 있을까?
        *
        */
