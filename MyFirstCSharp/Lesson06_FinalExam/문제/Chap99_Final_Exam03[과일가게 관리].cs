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
    public partial class Chap99_Final_Exam03 : Form
    {
        private int iTotalPrice = 0; // 총 결제 금액  
        private int iCustomerBalance = 100000; // 고객 잔액 초기값
        private int iStoreBalance = 100000; // 관리자 가게 잔액 초기값
        private int iApplePrice = 2000; // 사과 가격
        private int iMelonPrice = 2500; // 참외 가격
        private int iWatermelonPrice = 18000; // 수박 가격
        private Dictionary<string, int> fruitOrder = new Dictionary<string, int>(); // 주문 내역

        public Chap99_Final_Exam03()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 고객주문현황에서 작동하는 버튼들
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnFruit_Click(object sender, EventArgs e)         //각 과일 주문 버튼
        {

            Button btnTemp = (Button)sender;
            string sFruitName = btnTemp.Tag.ToString();
            switch (sFruitName)
            {
                // 결제 시 주문 수량 별 처리를 위하여 주문 버튼 클릭 후 
                case "사과":
                    // 사과의 주문 처리
                    FruitInventoryAdj(lblAppCount, sFruitName, iApplePrice);
                    break;
                case "참외":
                    // 참외의 주문 처리 
                    FruitInventoryAdj(lblMelonCount, sFruitName, iMelonPrice);
                    break;
                case "수박":
                    // 수박의 주문 처리
                    FruitInventoryAdj(lblW_MCount, sFruitName, iWatermelonPrice);
                    break;
            }
        }


        //과일 재고를 조정하고 구매 가격을 누적하는 함수를 사용한 코드...
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

            if (fruitOrder.ContainsKey(sFruitName))
                fruitOrder[sFruitName]++;
            else
                fruitOrder[sFruitName] = 1;
        }



        private void btnTotalPrice_Click(object sender, EventArgs e)         //총결제금액 버튼
        {
            if (iTotalPrice > 0)
                MessageBox.Show($"총 결재 금액은 {iTotalPrice}원입니다.");
            else
                MessageBox.Show("주문 내역이 없습니다. 0원입니다.");
        }



        private void btnOrderCancle_Click(object sender, EventArgs e)        //주문취소 버튼
        {
            if (fruitOrder.Count == 0)
            {
                MessageBox.Show("취소할 내역이 없습니다.");
                return;
            }

            foreach (var order in fruitOrder)
            {
                if (order.Key == "사과")
                    lblAppCount.Text = (int.Parse(lblAppCount.Text) + order.Value).ToString();
                else if (order.Key == "참외")
                    lblMelonCount.Text = (int.Parse(lblMelonCount.Text) + order.Value).ToString();
                else if (order.Key == "수박")
                    lblW_MCount.Text = (int.Parse(lblW_MCount.Text) + order.Value).ToString();
            }

            fruitOrder.Clear();
            iTotalPrice = 0;
        }



        private void btnBuy_Click(object sender, EventArgs e)                //결제버튼
        {
            if (iTotalPrice > iCustomerBalance)
            {
                MessageBox.Show("주문 금액이 고객 잔액보다 많아 결제를 할 수 없습니다.");
                return;
            }

            iStoreBalance += iTotalPrice;
            StringBuilder orderList = new StringBuilder();

            foreach (var order in fruitOrder)
            {
                int orderPrice = GetMarginPrice(order.Key, order.Value);
                iStoreBalance -= orderPrice;
                orderList.AppendLine($"{order.Key} 주문 수량: {order.Value}개, 주문 금액: {orderPrice}원");
            }

            txtOrderList.Text = orderList.ToString();
            fruitOrder.Clear();
            iTotalPrice = 0;

            MessageBox.Show("결제가 완료되었습니다.");

            lblAppCount.Text = "10";
            lblMelonCount.Text = "10";
            lblW_MCount.Text = "10";
        }

        private int GetMarginPrice(string fruitName, int orderCount)
        {
            int fruitPrice = 0;

            switch (fruitName)
            {
                case "사과":
                    fruitPrice = iApplePrice;
                    break;
                case "참외":
                    fruitPrice = iMelonPrice;
                    break;
                case "수박":
                    fruitPrice = iWatermelonPrice;
                    break;
            }

            double marginRate = 0.6; // 마진 금액을 판매 금액의 60%로 설정
            int invoicePrice = (int)(fruitPrice * marginRate * orderCount);

            return invoicePrice;
        }


        //////////////////////////////////////////////////////////////

        /* 관리자 구역에서 작동하는 버튼들 */

        private void btnFruitInvoice_Click(object sender, EventArgs e)      //발주 버튼
        {
            int appleCount, melonCount, watermelonCount;

            if (!int.TryParse(txtAppleInvoieCount.Text, out appleCount) || !int.TryParse(txtMelonInvoieCount.Text, out melonCount) || !int.TryParse(txtW_MInvoieCount.Text, out watermelonCount))
            {
                MessageBox.Show("발주 내역이 없습니다.");
                return;
            }

            int appleInvoice = GetInvoiceAmount(iApplePrice, appleCount);
            int melonInvoice = GetInvoiceAmount(iMelonPrice, melonCount);
            int watermelonInvoice = GetInvoiceAmount(iWatermelonPrice, watermelonCount);
            int totalInvoice = appleInvoice + melonInvoice + watermelonInvoice;

            if (totalInvoice > iStoreBalance)
            {
                MessageBox.Show("총 발주 금액이 관리자 가게 잔액보다 많아 발주를 할 수 없습니다.");
                return;
            }

            iStoreBalance -= totalInvoice;
            txtOrderList.Text += $"사과 발주 수량: {appleCount}개, 발주 금액: {appleInvoice}원\n";
            txtOrderList.Text += $"참외 발주 수량: {melonCount}개, 발주 금액: {melonInvoice}원\n";
            txtOrderList.Text += $"수박 발주 수량: {watermelonCount}개, 발주 금액: {watermelonInvoice}원\n";
            txtAppleInvoieCount.Text = "";
            txtMelonInvoieCount.Text = "";
            txtW_MInvoieCount.Text = "";

            MessageBox.Show("발주가 정상적으로 완료되었습니다.");
        }

        private void btnClearInvoice_Click(object sender, EventArgs e)     //발주전체삭제 버튼
        {
            txtAppleInvoieCount.Text = "";
            txtMelonInvoieCount.Text = "";
            txtW_MInvoieCount.Text = "";
        }

        private void btnShowUnitMargin_Click(object sender, EventArgs e)    //개별마진보기 버튼
        {
            string selectedFruit = "";
            if (rdoApple.Checked)
                selectedFruit = "사과";
            else if (rdoMelon.Checked)
                selectedFruit = "참외";
            else if (rdoW_M.Checked)
                selectedFruit = "수박";

            if (!string.IsNullOrEmpty(selectedFruit))
            {
                int orderCount = 0;
                if (fruitOrder.ContainsKey(selectedFruit))
                    orderCount = fruitOrder[selectedFruit];

                int invoicePrice = GetMarginPrice(selectedFruit, orderCount);
                MessageBox.Show($"{selectedFruit}의 마진 금액: {invoicePrice}원");
            }
        }

        private void btnShowTotalMargin_Click(object sender, EventArgs e)   //총마진보기 버튼
        {
            int totalMargin = GetMarginPrice("사과", fruitOrder.ContainsKey("사과") ? fruitOrder["사과"] : 0);
            totalMargin += GetMarginPrice("참외", fruitOrder.ContainsKey("참외") ? fruitOrder["참외"] : 0);
            totalMargin += GetMarginPrice("수박", fruitOrder.ContainsKey("수박") ? fruitOrder["수박"] : 0);

            MessageBox.Show($"총 마진 금액: {totalMargin}원");
        }

        private int GetInvoiceAmount(int fruitPrice, int fruitCount)
        {
            double marginRate = 0.4; // 발주 금액을 과일 가격의 40%로 설정 (소수점 이하 제외)
            int invoiceAmount = (int)(fruitPrice * marginRate * fruitCount);
            return invoiceAmount;
        }

        private void txtOrderList_TextChanged(object sender, EventArgs e)     //내역이 담길 텍스트 박스
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
    }
}
