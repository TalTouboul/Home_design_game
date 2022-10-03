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
    public partial class BasicUnit :Unit 
    {
        private void BasicUnit_Load(object sender, EventArgs e)
        {

        }
        private int index = 1;
        public Button[] Change_image;
        public PictureBox Car;
        public  BasicUnit()
        {
            InitializeComponent();
            Change_image = new Button[1];
            Car = new PictureBox();
            this.BackgroundImage = Properties.Resources.parking;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //setBackRoundImage();
            Create_item(ref Change_image[0], 0);
            Add_Buttons(ref Change_image, Menu);
        }
        public BasicUnit(ref BasicUnit other)
        {
            this.Change_image = other.Change_image;
            this.Car = other.Car;
        }
        public override void Create_item(ref Button b, int index)
        {
            Car.Image = parcking.Images[index];
            this.Car.Location = new Point(370, 300);
            this.Car.BackColor = Color.Transparent;
            this.Car.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Car.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Car.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Car.BackgroundImageLayout = ImageLayout.Stretch;
            this.Car.Cursor = Cursors.Hand;
            this.Car.Visible = true;
            this.Car.Show();
            this.Controls.Add(this.Car);

        }
        public override void Add_Buttons(ref Button[] b, ImageList _menu)
        {
          
            b[0] = new Button();
            b[0].Size = new Size(50, 50);
            b[0].Location = new Point(200, 200);
            b[0].UseVisualStyleBackColor = true;
            b[0].Visible = true;
            b[0].Cursor = Cursors.Hand;
            b[0].Image = _menu.Images[5];
            b[0].BackColor = Color.White;
            b[0].AutoSizeMode = AutoSizeMode.GrowOnly;
            b[0].BackgroundImageLayout = ImageLayout.Stretch;

            b[0].Click += (sender1, args) => Switch(ref index);
            this.Controls.Add(b[0]);
        }
        public override void Switch(ref int index)
        {
            if (index < parcking.Images.Count)
            {
                this.Car.Image = parcking.Images[index++]; 
            }
            else 
            { 
                index = 0;
            }
        }
    }
}
