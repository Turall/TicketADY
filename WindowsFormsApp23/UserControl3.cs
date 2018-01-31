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
        Person person;
        public static List<Person> PersonList;
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
            comboBox3.Items.Add("Azerbaycan");
            comboBox3.Items.Add("Russiya");
            comboBox3.Items.Add("Turkiye");
            comboBox4.Items.Add("Azerbaycan");
            comboBox4.Items.Add("Russiya");
            comboBox4.Items.Add("Turkiye");
            foreach (var item in UserControl1.TicketsList)
            {
                label1.Text = "BÖYÜK (SƏRNİŞİN 1 )";
                label1.ForeColor = SystemColors.HotTrack;
                if(Convert.ToInt32(item.Boyukler) > 1 )
                {
                    panel2.Visible = true;
                    label2.Text = "BÖYÜK(SƏRNİŞİN 2)";
                    label2.ForeColor = SystemColors.HotTrack;
                } 
                if(Convert.ToInt32(item.Balacalar) > 0)
                {
                    panel6.Visible = true;
                    panel4.Visible = true;
                    label9.Text = "Balaca (SƏRNİŞİN 3 )";
                    label9.ForeColor = SystemColors.HotTrack;
                }
                if (Convert.ToInt32(item.Balacalar) == 2)
                {
                    panel5.Visible = true;
                    label12.Text = "Balaca (SƏRNİŞİN 4 )";
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

        private void button1_Click(object sender, EventArgs e)
        {
            person = new Person();
            PersonList = new List<Person>();
            person.Name = textBox1.Text;
            person.Surname = textBox2.Text;
            PersonList.Add(person);
            if(panel2.Visible)
            {
                person.Name = textBox5.Text;
                person.Surname = textBox6.Text;
                PersonList.Add(person);
            }
            if (panel4.Visible)
            {
                person.Name = textBox12.Text;
                person.Surname = textBox10.Text;
                PersonList.Add(person);
            }
            if (panel5.Visible)
            {
                person.Name = textBox16.Text;
                person.Surname = textBox14.Text;
                PersonList.Add(person);
            }
            Controls.Add(UserControl4.Instance);
            UserControl4.Instance.Dock = DockStyle.Fill;
            UserControl4.Instance.BringToFront();
            instance = null;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox3.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                checkBox5.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox6.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox8.Checked)
            {
                checkBox7.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                checkBox8.Checked = false;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    
}
