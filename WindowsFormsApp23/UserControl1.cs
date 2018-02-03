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
    public enum Bolgeler { Baki = 1,Kurdemir,Gence,Agstafa };
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }


        public static Dictionary<TicketInfo, Train> MainmenuInfo = null;
       // public static List<Dictionary> TicketsList = null;
        //TicketInfo ticketInfo = null;
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


            comboBox1.Items.Add(Bolgeler.Agstafa);
            comboBox1.Items.Add(Bolgeler.Baki);
            comboBox1.Items.Add(Bolgeler.Gence);
            comboBox1.Items.Add(Bolgeler.Kurdemir);

            comboBox2.Items.Add(Bolgeler.Agstafa);
            comboBox2.Items.Add(Bolgeler.Baki);
            comboBox2.Items.Add(Bolgeler.Gence);
            comboBox2.Items.Add(Bolgeler.Kurdemir);

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
        public static int yer = 26;
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
                if (panel2.Visible)
                {
                    MainmenuInfo = new Dictionary<TicketInfo, Train>
                {
                    {new TicketInfo(comboBox1.Text,comboBox2.Text,textBox1.Text,textBox2.Text,comboBox3.Text,comboBox4.Text,comboBox5.Text),
                    new Train ("666",yer)}
                };
                }
                else
                {
                    MainmenuInfo = new Dictionary<TicketInfo, Train>
                {
                    {new TicketInfo(comboBox1.Text,comboBox2.Text,textBox1.Text,comboBox3.Text,comboBox4.Text,comboBox5.Text),
                    new Train ("666",yer)}
                };
                }
               
               //TicketsList = new List<Dictionary> ();
               
               // TicketsList.Add(ticketInfo);
                Controls.Add(UserControl2.Instance);
                UserControl2.Instance.BringToFront();
                UserControl2.Instance.Dock = DockStyle.Fill;
                instance = null;
            }
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

        public TicketInfo (string haradan,string haraya,string gedistarixi,string boyukler,string balacalar,string korpeler)
        {
            Haradan = haraya;
            Haraya = haraya;
            GedisTarixi = gedistarixi;
            Boyukler = boyukler;
            Balacalar = balacalar;
            Korpeler = korpeler;
        }
        public TicketInfo(string haradan, string haraya, string gedistarixi,string gelistarixi, string boyukler, string balacalar, string korpeler)
        {
            Haradan = haraya;
            Haraya = haraya;
            GedisTarixi = gedistarixi;
            GelisTarixi = gelistarixi;
            Boyukler = boyukler;
            Balacalar = balacalar;
            Korpeler = korpeler;
        }
    }

    public class Train
    {
        public string TrainNumber { get; set; }
        public int BowYerler { get; set; }
        public Train(string trainnumber,int bowyerler)
        {
            TrainNumber = trainnumber;
            BowYerler = bowyerler;
        }

    }

}
