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
    public partial class Chap25_RecursiveFunction_T : Form
    {
        public Chap25_RecursiveFunction_T()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            // 리스트의 초기 값 0 과 1 등록.
            List<int> iList = new List<int>()
            { 
                0 ,1
            };

        }
    }
}
