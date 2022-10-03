using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace ProjectNew
{
    
    [Serializable]
    public struct UNITS
    {
        public int[] UnitsNum;
    };
    
    public partial class House : Form
    {
        public int count;
        private int limitCount;
        private UnitDesing[] UD;
        private Button[] UnitButtons;
        private int Bcounter;
        private UNITS S;
        public House()
        {
            InitializeComponent();
            count = 0;
            limitCount = 20;
            UD = new UnitDesing[20];
            UnitButtons = new Button[20];
            Bcounter = 0;
            S = new UNITS();
            S.UnitsNum = new int[20];
            instructions.Hide();
        }
        //load-constractor:
        public House(UNITS L)
        {
            InitializeComponent();
            count = 0;
            limitCount = 20;
            UD = new UnitDesing[20];
            UnitButtons = new Button[20];
            Bcounter = 0;
            S = new UNITS();
            S.UnitsNum = new int[20];
            instructions.Hide();
            foreach (int x in L.UnitsNum)
            {
                switch(x)
                {
                    case 1:
                        {
                            UD[count] = new multipeImagesUnit();
                            UD[count].LoadUnit(count);
                            S.UnitsNum[count++] = 1;
                            setButton(0);
                            break;
                        }
                    case 2:
                        {
                            UD[count] = new ExpendUnit(2);
                            UD[count].LoadUnit(count);
                            S.UnitsNum[count++] = 2;
                            setButton(3);

                            break;
                        }
                    case 3:
                        {
                            UD[count] = new ExpendUnit(1);
                            UD[count].LoadUnit(count);
                            S.UnitsNum[count++] = 3;
                            setButton(4);
                            break;
                        }
                    case 4:
                        {
                            UD[count] = new multipePannelsUnit();
                            UD[count].LoadUnit(count);
                            S.UnitsNum[count++] = 4;
                            setButton(2);
                            break;
                        }
                    case 5:
                        {
                            UD[count] = new BasicUnit();
                            UD[count].LoadUnit(count);
                            S.UnitsNum[count++] = 5;
                            setButton(5);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
        private void GetIntoRoomButton_Click(object sender, EventArgs e)
        {
            if (count < limitCount)
            {
                UD[count] = new multipeImagesUnit();
                S.UnitsNum[count] = 1;
                UD[count++].Show();
                this.Hide();
                setButton(0);
                
            }
            else { MessageBox.Show("you reach'd the max limit"); }

        }
        private void GetIntoBathButton_Click(object sender, EventArgs e)
        {
            if (count < limitCount)
            {
                UD[count] = new ExpendUnit(2);
                S.UnitsNum[count] = 2;
                UD[count++].Show();
                this.Hide();
                setButton(3);
                
            }
            else { MessageBox.Show("you reach'd the max limit"); }

        }
        private void SalonButton_Click(object sender, EventArgs e)
        {
            if (count < limitCount)
            {
                UD[count] = new multipeImagesUnit();
                S.UnitsNum[count] = 1;
                UD[count++].Show();
                this.Hide();
                setButton(0);
            }
            else { MessageBox.Show("you reach'd the max limit"); }
        }
        private void GetIntoKitButton_Click(object sender, EventArgs e)
        {
            if (count < limitCount)
            {
                UD[count] = new ExpendUnit(1);
                S.UnitsNum[count] = 3;
                UD[count++].Show();
                this.Hide();
                setButton(4);
            }
            else { MessageBox.Show("you reach'd the max limit"); }
        }
        private void pictureBox2_Click(object sender, EventArgs e)//garden
        {
            if (count < limitCount)
            {
                UD[count] = new multipePannelsUnit();
                S.UnitsNum[count] = 4;
                UD[count++].Show();
                this.Hide();
                setButton(2);
            }
            else { MessageBox.Show("you reach'd the max limit"); }
        }
        private void pictureBox1_Click(object sender, EventArgs e)//parking
        {
            if (count < limitCount)
            {
                UD[count] = new BasicUnit();
                S.UnitsNum[count] = 5;
                UD[count].Show();
                count++;
                this.Hide();
                setButton(5);
            }
            else { MessageBox.Show("you reach'd the max limit"); }

        }
        private void House_Load(object sender, EventArgs e)
        {

        }
        public void setButton(int index)
        {
            UnitButtons[Bcounter] = new Button();
            UnitButtons[Bcounter].Location = new System.Drawing.Point(((Bcounter + 1) * 50), 300);
            UnitButtons[Bcounter].Name = "Image" + (Bcounter + 1);
            UnitButtons[Bcounter].Size = new System.Drawing.Size(70, 50);
            UnitButtons[Bcounter].TabIndex = Bcounter;
            UnitButtons[Bcounter].UseVisualStyleBackColor = true;
            UnitButtons[Bcounter].Visible = true;
            UnitButtons[Bcounter].Cursor = Cursors.Hand;
            UnitButtons[Bcounter].Image = UnitBackround.Images[index];
            UnitButtons[Bcounter].BackColor = Color.White;
            UnitButtons[Bcounter].AutoSizeMode = AutoSizeMode.GrowOnly;
            UnitButtons[Bcounter].BackgroundImageLayout = ImageLayout.Stretch;
            UnitButtons[Bcounter].Tag = Bcounter;
            Button t = UnitButtons[Bcounter];
            UnitButtons[Bcounter].MouseClick += (sender1, args) => open_unit(sender1, args);
            UnitButtons[Bcounter].MouseWheel += (sender1, args) => remove_unit(sender1, args);
            this.Controls.Add(UnitButtons[Bcounter]);
            this.UnitsPannel.Controls.Add(UnitButtons[Bcounter]);
            Bcounter++;
        }
        public void open_unit(object sender1, MouseEventArgs args)
        {
            Button b = (Button)sender1;
            UD[(int)b.Tag].Show();
            this.Hide();
        }
        public void remove_unit(object sender1, MouseEventArgs args)
        {
            Button b = (Button)sender1;
            b.Hide();
            this.Controls.Remove(b);
            UnitsPannel.Controls.Remove(b);
        }
        private void helpButton_Click(object sender, EventArgs e)
        {

        }
        private void save_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UNITS));
            using (TextWriter stream = new StreamWriter("savedGame.xml"))
            {
                serializer.Serialize(stream, S);
            }
            MessageBox.Show("saved successfully");
            for (int i = 0; i < count; i++) { UD[i].save_function(i); }
        }
        private void ReturnButton_Click(object sender, EventArgs e)//instructions button
        {
            instructions.Show();
        }
        private void instructions_TextChanged_1(object sender, EventArgs e)
        {
            instructions.Hide();
        }
        private void instructions_Click(object sender, EventArgs e)
        {
            instructions.Hide();
        }

    }
}
