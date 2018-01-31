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

            foreach (var item in UserControl1.TicketsList)
            {
                boyuk = Convert.ToUInt32(item.Boyukler);
                balaca = Convert.ToUInt32(item.Balacalar);
            }
        }

       static uint boyuk = 0;
       static uint balaca = 0;
        private void btn_click(object sender ,EventArgs e)
        {
           
            Button btn = (Button)sender;
            if(btn.BackColor == Color.ForestGreen)
            {
                if (boyuk <= 0 && balaca <= 0)
                    return;
                else
                {
                    
                    if(boyuk != 0)
                    {
                        boyuk--;
                        btn.BackColor = Color.Red;
                    }
                    else if(balaca != 0)
                    {
                        balaca--;
                        btn.BackColor = Color.Red;
                    }
                       
                   
                }
            }
            else if(btn.BackColor == Color.Red )
            {
                if(boyuk >= 0)
                {
                    boyuk++;
                    btn.BackColor = Color.ForestGreen;
                    return;
                }
                else if(balaca >= 0)
                {
                    balaca++;
                    btn.BackColor = Color.ForestGreen;
                }
            }
            
        }

        private void button37_Click(object sender, EventArgs e)
        {
            
            var selected =panel1.Controls.OfType<Button>().Where(x => x.BackColor == Color.Red);
            foreach (var item in selected)
            {
                item.BackColor = Color.Gray;
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            var selected = panel1.Controls.OfType<Button>().Where(x => x.BackColor == Color.Gray);
            foreach (var item in selected)
            {
                item.BackColor = Color.ForestGreen;

            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Controls.Add(UserControl3.Instance);
            UserControl3.Instance.Dock = DockStyle.Fill;
            UserControl3.Instance.BringToFront();
            instance = null;
        }
    }
}
