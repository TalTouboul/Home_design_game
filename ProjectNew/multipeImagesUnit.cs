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
    public partial class multipeImagesUnit : ExpendUnit
    {
        private int BackgroundType = 1;
        private Button[] Change_backRound;
        private void multipeImagesUnit_Load(object sender, EventArgs e)
        {

        }
        
        //constructor:
        public multipeImagesUnit():base(0)
        {
            InitializeComponent();
            Change_backRound = new Button[1];
            Add_Button(Change_backRound,Menu);
        }
        //copy-constructor:
        public multipeImagesUnit(ref multipeImagesUnit other):base(0)
        {
            this.Change_backRound = other.Change_backRound;
            Switch (ref this.BackgroundType);
        }
        public void Add_Button(Button[] b, ImageList IL)
        {
            b[0]=new Button();
           // b[0].Dock = DockStyle.Top;
            b[0].Location = new Point(this.Width-120, 0);
            b[0].Size = new Size(40, 40);
            b[0].UseVisualStyleBackColor = true;
            b[0].Visible = true;
            b[0].Cursor = Cursors.Hand;
            b[0].Image = IL.Images[5];
            b[0].BackColor = Color.White;
            b[0].AutoSizeMode = AutoSizeMode.GrowOnly;
            b[0].BackgroundImageLayout = ImageLayout.Stretch;

            b[0].Click += (sender1, args) => Switch(ref BackgroundType);
            this.Controls.Add(b[0]);
        }
        public override void Switch(ref int index)
        {
            if(index==1 )
            {
                this.BackgroundImage = Properties.Resources.room2; 
                index=0;
               this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.room1;
                index = 1;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
    }
}
