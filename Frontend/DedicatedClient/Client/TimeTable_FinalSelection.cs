using Client.TotorWorldService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class TimeTable_FinalSelection : Form
    {
        private UserServiceClient client;
        Dictionary<Button, TimeSlot> Dics = new Dictionary<Button, TimeSlot>();
        Dictionary<Button, TimeSlot> TrashDics = new Dictionary<Button, TimeSlot>();
        protected List<WorkDay> WorkDays;
  
        public TimeTable_FinalSelection(List<WorkDay> workDays)
        {
            client = new UserServiceClient();
            client.ClientCredentials.UserName.UserName = UserCredentialStore.Instance.Email;
            client.ClientCredentials.UserName.Password = UserCredentialStore.Instance.Password;
            WorkDays = workDays;


            InitializeComponent();

            var buttons = new Button[][] {
                new Button[] {button1, button2, button3, button4, button5, button6, button7 },
                new Button[] {button8, button9, button10, button11, button12, button13, button14},
                new Button[] {button15, button16, button17, button18, button19, button20, button21 },
                new Button[] {button22, button23, button24, button25, button26, button27, button28 },
                new Button[] {button29, button30, button31, button32, button33, button34, button35 },
                new Button[] {button36, button37, button38, button39, button40, button41, button42 },
                new Button[] {button43, button44, button45, button46, button47, button48, button49 },
            };

            for (int i = 0; i < WorkDays.Count; i++)
            {
                for (int j = 0; j < WorkDays[i].TimeSlots.Count; j++)
                {
                    Dics[buttons[i][j]] = WorkDays[i].TimeSlots[j];
                }
            }
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            if (WorkDays.Count >= 1)
            {
                label1.Text = WorkDays.ElementAt(0).Day.ToString();
            }
            if (WorkDays.Count >= 2)
            {
                label2.Text = WorkDays.ElementAt(1).Day.ToString(); ;
            }
            if (WorkDays.Count >= 3)
            {
                label3.Text = WorkDays.ElementAt(2).Day.ToString(); ;
            }
            if (WorkDays.Count >= 4)
            {
                label4.Text = WorkDays.ElementAt(3).Day.ToString(); ;
            }
            if (WorkDays.Count >= 5)
            {
                label5.Text = WorkDays.ElementAt(4).Day.ToString(); ;
            }
            if (WorkDays.Count >= 6)
            {
                label6.Text = WorkDays.ElementAt(5).Day.ToString(); ;
            }
            if (WorkDays.Count >= 7)
            {
                label7.Text = WorkDays.ElementAt(6).Day.ToString(); ;
            }

            if (WorkDays[0].TimeSlots.Count >= 1)
            {
                label8.Text = WorkDays.ElementAt(0).TimeSlots[0].StartTime.ToString("HH:mm");
            }
            if (WorkDays[0].TimeSlots.Count >= 2)
            {
                label9.Text = WorkDays.ElementAt(0).TimeSlots[1].StartTime.ToString("HH:mm");
            }
            if (WorkDays[0].TimeSlots.Count >= 3)
            {
                label10.Text = WorkDays.ElementAt(0).TimeSlots[2].StartTime.ToString("HH:mm");
            }
            if (WorkDays[0].TimeSlots.Count >= 4)
            {
                label11.Text = WorkDays.ElementAt(0).TimeSlots[3].StartTime.ToString("HH:mm");
            }
            if (WorkDays[0].TimeSlots.Count >= 5)
            {
                label12.Text = WorkDays.ElementAt(0).TimeSlots[4].StartTime.ToString("HH:mm");
            }
            if (WorkDays[0].TimeSlots.Count >= 6)
            {
                label13.Text = WorkDays.ElementAt(0).TimeSlots[5].StartTime.ToString("HH:mm");
            }
            if (WorkDays[0].TimeSlots.Count >= 7)
            {
                label14.Text = WorkDays.ElementAt(0).TimeSlots[6].StartTime.ToString("HH:mm");
            }

            if (WorkDays.Count == 1)
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button15.Visible = false;
                button16.Visible = false;
                button17.Visible = false;
                button18.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button22.Visible = false;
                button23.Visible = false;
                button24.Visible = false;
                button25.Visible = false;
                button26.Visible = false;
                button27.Visible = false;
                button28.Visible = false;
                button29.Visible = false;
                button30.Visible = false;
                button31.Visible = false;
                button32.Visible = false;
                button33.Visible = false;
                button34.Visible = false;
                button35.Visible = false;
                button36.Visible = false;
                button37.Visible = false;
                button38.Visible = false;
                button39.Visible = false;
                button40.Visible = false;
                button41.Visible = false;
                button42.Visible = false;
                button43.Visible = false;
                button44.Visible = false;
                button45.Visible = false;
                button46.Visible = false;
                button47.Visible = false;
                button48.Visible = false;
                button49.Visible = false;
            }
            if (WorkDays.Count == 2)
            {
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                button15.Visible = false;
                button16.Visible = false;
                button17.Visible = false;
                button18.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button22.Visible = false;
                button23.Visible = false;
                button24.Visible = false;
                button25.Visible = false;
                button26.Visible = false;
                button27.Visible = false;
                button28.Visible = false;
                button29.Visible = false;
                button30.Visible = false;
                button31.Visible = false;
                button32.Visible = false;
                button33.Visible = false;
                button34.Visible = false;
                button35.Visible = false;
                button36.Visible = false;
                button37.Visible = false;
                button38.Visible = false;
                button39.Visible = false;
                button40.Visible = false;
                button41.Visible = false;
                button42.Visible = false;
                button43.Visible = false;
                button44.Visible = false;
                button45.Visible = false;
                button46.Visible = false;
                button47.Visible = false;
                button48.Visible = false;
                button49.Visible = false;
            }
            if (WorkDays.Count == 3)
            {
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                button22.Visible = false;
                button23.Visible = false;
                button24.Visible = false;
                button25.Visible = false;
                button26.Visible = false;
                button27.Visible = false;
                button28.Visible = false;
                button29.Visible = false;
                button30.Visible = false;
                button31.Visible = false;
                button32.Visible = false;
                button33.Visible = false;
                button34.Visible = false;
                button35.Visible = false;
                button36.Visible = false;
                button37.Visible = false;
                button38.Visible = false;
                button39.Visible = false;
                button40.Visible = false;
                button41.Visible = false;
                button42.Visible = false;
                button43.Visible = false;
                button44.Visible = false;
                button45.Visible = false;
                button46.Visible = false;
                button47.Visible = false;
                button48.Visible = false;
                button49.Visible = false;
            }
            if (WorkDays.Count == 4)
            {
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                button29.Visible = false;
                button30.Visible = false;
                button31.Visible = false;
                button32.Visible = false;
                button33.Visible = false;
                button34.Visible = false;
                button35.Visible = false;
                button36.Visible = false;
                button37.Visible = false;
                button38.Visible = false;
                button39.Visible = false;
                button40.Visible = false;
                button41.Visible = false;
                button42.Visible = false;
                button43.Visible = false;
                button44.Visible = false;
                button45.Visible = false;
                button46.Visible = false;
                button47.Visible = false;
                button48.Visible = false;
                button49.Visible = false;
            }
            if (WorkDays.Count == 5)
            {
                label6.Visible = false;
                label7.Visible = false;
                button35.Visible = false;
                button36.Visible = false;
                button37.Visible = false;
                button38.Visible = false;
                button39.Visible = false;
                button40.Visible = false;
                button41.Visible = false;
                button42.Visible = false;
                button43.Visible = false;
                button44.Visible = false;
                button45.Visible = false;
                button46.Visible = false;
                button47.Visible = false;
                button48.Visible = false;
                button49.Visible = false;
            }
            if (WorkDays.Count == 6)
            {
                label7.Visible = false;
                button42.Visible = false;
                button43.Visible = false;
                button44.Visible = false;
                button45.Visible = false;
                button46.Visible = false;
                button47.Visible = false;
                button48.Visible = false;
                button49.Visible = false;
            }

            if (WorkDays[0].TimeSlots.Count == 1)
            {
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;

                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button16.Visible = false;
                button17.Visible = false;
                button18.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button23.Visible = false;
                button24.Visible = false;
                button25.Visible = false;
                button26.Visible = false;
                button27.Visible = false;
                button28.Visible = false;
                button30.Visible = false;
                button31.Visible = false;
                button32.Visible = false;
                button33.Visible = false;
                button34.Visible = false;
                button35.Visible = false;
                button37.Visible = false;
                button38.Visible = false;
                button39.Visible = false;
                button40.Visible = false;
                button41.Visible = false;
                button42.Visible = false;
                button44.Visible = false;
                button45.Visible = false;
                button46.Visible = false;
                button47.Visible = false;
                button48.Visible = false;
                button49.Visible = false;
            }
            if (WorkDays[0].TimeSlots.Count == 2)
            {
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;

                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;

                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;

                button17.Visible = false;
                button18.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;

                button24.Visible = false;
                button25.Visible = false;
                button26.Visible = false;
                button27.Visible = false;
                button28.Visible = false;

                button31.Visible = false;
                button32.Visible = false;
                button33.Visible = false;
                button34.Visible = false;
                button35.Visible = false;

                button38.Visible = false;
                button39.Visible = false;
                button40.Visible = false;
                button41.Visible = false;
                button42.Visible = false;

                button45.Visible = false;
                button46.Visible = false;
                button47.Visible = false;
                button48.Visible = false;
                button49.Visible = false;

            }
            if (WorkDays[0].TimeSlots.Count == 3)
            {
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button18.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button25.Visible = false;
                button26.Visible = false;
                button27.Visible = false;
                button28.Visible = false;
                button32.Visible = false;
                button33.Visible = false;
                button34.Visible = false;
                button35.Visible = false;
                button39.Visible = false;
                button40.Visible = false;
                button41.Visible = false;
                button42.Visible = false;
                button46.Visible = false;
                button47.Visible = false;
                button48.Visible = false;
                button49.Visible = false;
            }
            if (WorkDays[0].TimeSlots.Count == 4)
            {
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button26.Visible = false;
                button27.Visible = false;
                button28.Visible = false;
                button33.Visible = false;
                button34.Visible = false;
                button35.Visible = false;
                button40.Visible = false;
                button41.Visible = false;
                button42.Visible = false;
                button47.Visible = false;
                button48.Visible = false;
                button49.Visible = false;
            }
            if (WorkDays[0].TimeSlots.Count == 5)
            {
                label13.Visible = false;
                label14.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button27.Visible = false;
                button28.Visible = false;
                button34.Visible = false;
                button35.Visible = false;
                button41.Visible = false;
                button42.Visible = false;
                button48.Visible = false;
                button49.Visible = false;
            }
            if (WorkDays[0].TimeSlots.Count == 6)
            {
                label14.Visible = false;
                button7.Visible = false;
                button14.Visible = false;
                button21.Visible = false;
                button28.Visible = false;
                button35.Visible = false;
                button42.Visible = false;
                button49.Visible = false;
            }
            

        }
        
       
       
        private void buttonClick(object sender, EventArgs e)
        {
            
            var Btn = (Button)sender;
            if (Dics.ContainsKey(Btn))
            {
                TrashDics[Btn] = Dics[Btn];
                Dics[Btn].WorkDay.TimeSlots.Remove(Dics[Btn]);
                Dics.Remove(Btn);
                Btn.BackColor = Color.Red;
            } else
            {
                Dics[Btn] = TrashDics[Btn];
                Dics[Btn].WorkDay.TimeSlots.Add(TrashDics[Btn]);
                TrashDics.Remove(Btn);
                Btn.BackColor = DefaultBackColor;
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            try    
            {
                foreach (var day in WorkDays)
                {
                    client.CreateWorkDay(day);
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error persisting workdays", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }
            //var form4 = new TimetableOfProfile(WorkDays);
            // TODO
            MessageBox.Show("Timetable was saved successfully!");

            //form4.Closed += (s, args) => this.Close();
            //form4.Show();
           
        }
    }
}
