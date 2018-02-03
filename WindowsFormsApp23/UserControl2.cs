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
            
            
            foreach (var item in UserControl1.MainmenuInfo)
            {
                QatarN.Text = item.Value.TrainNumber;
                boyuk.Text = item.Key.Boyukler + " Boyuk";
                usaqlar.Text = item.Key.Balacalar + " Usaqlar";
                Korpe.Text = item.Key.Korpeler + " Korpeler";
                Gedis.Text = item.Key.Haradan;
                Teyinat.Text = item.Key.Haraya;
                qatar.Text = QatarN.Text;
                vaqontipi.Text = "KP";
                marsrut.Text = item.Key.Haradan + "-" + item.Key.Haraya;
                label6.Text = "Gedis: " + marsrut.Text;
                minikVaxti.Text = item.Key.GedisTarixi;
                    bqiymet *= Convert.ToInt32(item.Key.Boyukler);
                    blcqiymet *= Convert.ToInt32(item.Key.Balacalar);
                sum = bqiymet + blcqiymet;
                    ListViewItem listitem = new ListViewItem(new string[] { item.Value.BowYerler.ToString(),sum.ToString(),item.Value.TrainNumber });
                listView1.Items.Add(listitem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Controls.Add(UserControl1.Instance);
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
