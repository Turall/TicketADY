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
            monthCalendar1.Visible = false;
            ComBoxAdd();
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
        }

    }
}
