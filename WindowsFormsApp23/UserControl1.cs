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
        string[] bolgeler = { "Astara", "Baki", "Balaken", "Berde", "Celilabad", "Goran", "Agstafa" };
        public static List<TicketInfo> TicketsList;
        TicketInfo ticketInfo;
        private static UserControl1 instance;
        public static UserControl1 Instance
        {
            get
            {
                if (instance == null)
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

            for (int i = 0; i < bolgeler.Length; i++)
            {
                comboBox1.Items.Add(bolgeler[i]);
                comboBox2.Items.Add(bolgeler[i]);
            }
            for (int i = 0; i < 5; i++)
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
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(comboBox2.Text)
                || !checkBox1.Checked || comboBox3.Text == "0" || textBox1.Text != monthCalendar1.SelectionStart.ToShortDateString() &&
                textBox2.Text != monthCalendar2.SelectionStart.ToShortDateString())
            {
                if (string.IsNullOrWhiteSpace(comboBox1.Text))
                    comboBox1.BackColor = Color.Red;
                else comboBox1.BackColor = Color.White;
                if (string.IsNullOrWhiteSpace(comboBox2.Text))
                    comboBox2.BackColor = Color.Red;
                if (comboBox3.Text == "0")
                    comboBox3.BackColor = Color.Red;
                else comboBox3.BackColor = Color.White;
                if (textBox1.Text != monthCalendar1.SelectionStart.ToShortDateString())
                    textBox1.BackColor = Color.Red;
                else textBox1.BackColor = Color.Silver;
                if (textBox2.Text != monthCalendar1.SelectionStart.ToShortDateString())
                    textBox2.BackColor = Color.Red;
                else textBox2.BackColor = Color.White;
                if (!checkBox1.Checked)
                    checkBox1.ForeColor = Color.Red;
                else checkBox1.ForeColor = SystemColors.HotTrack;
                return;
            }
            else if (Convert.ToInt32(comboBox5.Text) > Convert.ToInt32(comboBox3.Text))
            {
                MessageBox.Show("Korpelerin sayi Boyuklerin sayindan cox ola bilmez!! ");
                return;
            }
            else
            {

                TicketsList = new List<TicketInfo>();
                ticketInfo = new TicketInfo();
                BosVaqonlar();
                ticketInfo.Haradan = comboBox1.Text;
                ticketInfo.Haraya = comboBox2.Text;
                ticketInfo.GedisTarixi = textBox1.Text;
                if (panel2.Visible)
                { ticketInfo.GelisTarixi = textBox2.Text; }
                ticketInfo.Boyukler = comboBox3.Text;
                ticketInfo.Balacalar = comboBox4.Text;
                ticketInfo.Korpeler = comboBox5.Text;
                TicketsList.Add(ticketInfo);
                Controls.Add(UserControl2.Instance);
                UserControl2.Instance.BringToFront();
                UserControl2.Instance.Dock = DockStyle.Fill;
                instance = null;
            }
        }
        public int BosVaqonlar()
        {

            for (int i = 0; i < bolgeler.Length; i++)
            {
                if (comboBox1.Text == bolgeler[i])
                {
                    if (i == 0) { ticketInfo.Vaqonlar = i + 1; }
                    ticketInfo.Vaqonlar = i;
                    return ticketInfo.Vaqonlar;
                }
            }
            return -1;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.Date.ToShortDateString();
            monthCalendar1.Visible = false;
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox2.Text = monthCalendar2.SelectionStart.Date.ToShortDateString();
            monthCalendar2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmbx1 = comboBox1.Text;
            string cmbx2 = comboBox2.Text;
            comboBox1.Text = cmbx2;
            comboBox2.Text = cmbx1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }


    }
    public class TicketInfo
    {
        public string Haradan { get; set; }
        public string Haraya { get; set; }
        public string GedisTarixi { get; set; }
        public string GelisTarixi { get; set; }
        public string Boyukler { get; set; }
        public string Balacalar { get; set; }
        public string Korpeler { get; set; }
        public int Vaqonlar { get; set; }

    }
    class Train
    {
        public string TrainNumber { get; set; }
        public string CixmaVaxti { get; set; }
        public string CatmaVaxti { get; set; }

        public static void AddtrainNumber()
        {

        }

    }

}
