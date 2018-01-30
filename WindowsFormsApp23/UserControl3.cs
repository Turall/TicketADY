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
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            dateTimePicker1.Visible = true;
           
            
        }
        private static UserControl3 instance;
        public static UserControl3 Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new UserControl3();
                    return instance;
                }
                return instance;
            }
        }
        private void texbox_click(object sender,EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Clear();
            txt.ForeColor = Color.Black;
        }
        private void  combox_click(object sender,EventArgs e)
        {
            ComboBox cmbx = (ComboBox)sender;
            cmbx.ForeColor = Color.Black;
        }
        private void UserControl3_Load(object sender, EventArgs e)
        {
           
            comboBox1.Items.Add("Azerbaycan");
            comboBox1.Items.Add("Russiya");
            comboBox1.Items.Add("Turkiye");
            comboBox2.Items.Add("Azerbaycan");
            comboBox2.Items.Add("Russiya");
            comboBox2.Items.Add("Turkiye");
            foreach (var item in UserControl1.TicketsList)
            {
                label1.Text = "BÖYÜK (SƏRNİŞİN 1 )";
                label1.ForeColor = SystemColors.HotTrack;
                if(Convert.ToInt32(item.Boyukler) > 1 )
                {
                    panel2.Visible = true;
                    label2.Text = "BÖYÜK(SƏRNİŞİN 1)";
                    label2.ForeColor = SystemColors.HotTrack;
                } 
                if(Convert.ToInt32(item.Balacalar) > 0)
                {
                    panel6.Visible = true;
                    panel4.Visible = true;
                    label9.Text = "Balaca (SƏRNİŞİN 1 )";
                    label9.ForeColor = SystemColors.HotTrack;
                }
                if (Convert.ToInt32(item.Balacalar) == 2)
                {
                    panel5.Visible = true;
                    label12.Text = "Balaca (SƏRNİŞİN 1 )";
                    label12.ForeColor = SystemColors.HotTrack;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Add(UserControl2.Instance);
            UserControl2.Instance.Dock = DockStyle.Fill;
            UserControl2.Instance.BringToFront();
            instance = null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
            }
        }
    }
}
