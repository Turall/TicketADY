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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }
        int bqiymet = 7;
        int blcqiymet = 5;
        int sum = 0;

        private static UserControl2 instance;
        public static UserControl2 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserControl2();
                    return instance;
                }
                return instance;
            }
        }
        private void UserControl2_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            
            QatarN.Text = rand.Next(100, 600).ToString();
            foreach (var item in UserControl1.TicketsList)
            {
                boyuk.Text = item.Boyukler + " Boyuk";
                usaqlar.Text = item.Balacalar + " Usaqlar";
                Korpe.Text = item.Korpeler + " Korpeler";
                Gedis.Text = item.Haradan;
                Teyinat.Text = item.Haraya;
                qatar.Text = QatarN.Text;
                vaqontipi.Text = "KP";
                marsrut.Text = item.Haradan + "-" + item.Haraya;
                label6.Text = "Gedis: " + marsrut.Text;
                minikVaxti.Text = item.GedisTarixi;
                    bqiymet *= Convert.ToInt32(item.Boyukler);
                    blcqiymet *= Convert.ToInt32(item.Balacalar);
                sum = bqiymet + blcqiymet;
                    ListViewItem listitem = new ListViewItem(new string[] { rand.Next(1,15).ToString(),sum.ToString(),item.Vaqonlar.ToString() });
                listView1.Items.Add(listitem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Controls.Add(UserControl1.Instance);
            UserControl1.TicketsList.Clear();
            instance = null;
            UserControl1.Instance.BringToFront();
            UserControl1.Instance.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Add(UserControl3.Instance);
            UserControl3.Instance.Dock = DockStyle.Fill;
            UserControl3.Instance.BringToFront();
            instance = null;
        }
    }
}
