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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private static UserControl1 instance;
        public static UserControl1 Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new UserControl1();
                    return instance;
                }
                else
                {
                    return instance;
                }
            }
        }
        

        private void UserControl1_Load(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Silver;
            panel2.Visible = false;
            monthCalendar1.Visible = false;
            radioButton1.Checked = true;
            ComBoxAdd();
            monthCalendar1.MinDate = DateTime.Now;
            monthCalendar2.MinDate = DateTime.Now;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            monthCalendar1.Visible = true;

        }
        private void ComBoxAdd()
        {
            string[] bolgeler = { "Agstafa", "Astara", "Baki", "Balaken", "Berde", "Celilabad",
                "Goran", "Gence","Lenkeran","Semkir","Kurdemir", "Masalli", "Qax", "Qazax","Yalama", "Yevlax" };
            for (int i = 0; i < bolgeler.Length; i++)
            {
                comboBox1.Items.Add(bolgeler[i]);
                comboBox2.Items.Add(bolgeler[i]);
            }
            for (int i = 1; i < 5; i++)
            {
                comboBox3.Items.Add(i.ToString());
                comboBox4.Items.Add(i.ToString());
                comboBox5.Items.Add(i.ToString());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Add(UserControl2.Instance);
            UserControl2.Instance.BringToFront();
            UserControl2.Instance.Dock = DockStyle.Fill;
        }
    }
    class TicketInfo
    {
        public string Hardan { get; set; }
        public string Haraya { get; set; }
        public string BirIstiqamet { get; set; }
        public string IkiIstiqamet { get; set; }
        public string GedisTarixi { get; set; }
        public string GelisTarixi { get; set; }
        public string Boyukler { get; set; }
        public string Balacalar { get; set; }
        public string Korpeler { get; set; } 
    }
}
