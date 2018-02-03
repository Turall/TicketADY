using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp23
{
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }
        public static Dictionary<Button, OrderInfo> ordermap = new Dictionary<Button, OrderInfo>();
        OrderInfo orderInfo = new OrderInfo();
        private static UserControl4 instance;
        public static UserControl4 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserControl4();
                    return instance;
                }
                return instance;
            }
        }



        private void UserControl4_Load(object sender, EventArgs e)
        {
            if (ordermap.Count != 0)
            {
                var btns = panel1.Controls.OfType<Button>().Where(x => x.BackColor == Color.ForestGreen);
                foreach (var panelbtn in btns)
                {
                    foreach (var btn in ordermap)
                    {
                        foreach (var way in UserControl1.MainmenuInfo)
                        {
                            if (way.Key.Haradan == btn.Value.Haradan && way.Key.Haraya == btn.Value.Haraya &&
                                panelbtn.Text == btn.Key.Text && way.Key.GedisTarixi == btn.Value.Time)
                            {
                                panelbtn.BackColor = Color.Gray;
                            }
                        }
                    }
                }
            }
           
            foreach (var item in UserControl1.MainmenuInfo)
            {
                boyuk = Convert.ToUInt32(item.Key.Boyukler);
                balaca = Convert.ToUInt32(item.Key.Balacalar);
            }
        }

        static uint boyuk = 0;
        static uint balaca = 0;
        private void btn_click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (btn.BackColor == Color.ForestGreen)
            {
                if (boyuk <= 0 && balaca <= 0)
                    return;
                else
                {

                    if (boyuk != 0)
                    {
                        boyuk--;
                        btn.BackColor = Color.Red;
                    }
                    else if (balaca != 0)
                    {
                        balaca--;
                        btn.BackColor = Color.Red;
                    }


                }
            }
            else if (btn.BackColor == Color.Red)
            {
                if (boyuk >= 0)
                {
                    boyuk++;
                    btn.BackColor = Color.ForestGreen;
                    return;
                }
                else if (balaca >= 0)
                {
                    balaca++;
                    btn.BackColor = Color.ForestGreen;
                }
            }

        }

        private void button37_Click(object sender, EventArgs e)
        {

            var selected = panel1.Controls.OfType<Button>().Where(x => x.BackColor == Color.Red);
            foreach (var item in selected)
            {
                foreach (var way in UserControl1.MainmenuInfo)
                {
                    orderInfo.Haradan = way.Key.Haradan;
                    orderInfo.Haraya = way.Key.Haraya;
                    orderInfo.Time = way.Key.GedisTarixi;
                    item.BackColor = Color.Gray;
                    ordermap.Add(item, orderInfo);
                    UserControl1.yer--;
                }
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            var selected = panel1.Controls.OfType<Button>().Where(x => x.BackColor == Color.Gray);
            foreach (var item in selected)
            {
                item.BackColor = Color.ForestGreen;

            }
            foreach (var item in UserControl1.MainmenuInfo)
            {
                boyuk = Convert.ToUInt32(item.Key.Boyukler);
                balaca = Convert.ToUInt32(item.Key.Balacalar);

            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Controls.Add(UserControl3.Instance);
            UserControl3.Instance.Dock = DockStyle.Fill;
            UserControl3.Instance.BringToFront();
            instance = null;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Controls.Add(UserControl1.Instance);
            UserControl1.Instance.Dock = DockStyle.Fill;
            UserControl1.Instance.BringToFront();
            instance = null;
        }
    }
    public class OrderInfo
    {
        public string Haradan { get; set; }
        public string Haraya { get; set; }
        public string Time { get; set; }
    }

}
