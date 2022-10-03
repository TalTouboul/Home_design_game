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
    public partial class multipePannelsUnit : ExpendUnit
    {
        private void multipePannelsUnit_Load(object sender, EventArgs e)
        {
           
        }
        private Button[] new_Buttons;
        private Button change_pannel;
        private int index = 1;
        //constructor:
        public multipePannelsUnit():base(3)
        {
            InitializeComponent();
            new_Buttons = new Button[Animals.Images.Count];
            change_pannel = new Button();
            Add_Buttons(ref new_Buttons, Animals);
            switch_Button(change_pannel, Menu);
            foreach (Button x in new_Buttons) { x.Hide(); }
        }
        public void switch_Button(Button b, ImageList IL)
        {
            b.Size = new Size(50, 50);
            b.Location = new Point(this.Width-130, 0);
            b.UseVisualStyleBackColor = true;
            b.Visible = true;
            b.Cursor = Cursors.Hand;
            b.Image = IL.Images[5];
            b.BackColor = Color.White;
            b.AutoSizeMode = AutoSizeMode.GrowOnly;
            b.BackgroundImageLayout = ImageLayout.Stretch;
            b.Click += (sender1, args) => Switch(ref this.index);
            this.Controls.Add(b);
        }
        public override void Switch(ref int index)
        {
            switch (index)
            {
                case 0:
                    {
                        foreach (Button x in this.new_Buttons) { x.Hide(); }
                        foreach (Button y in this.Buttons_arr) { y.Show(); }
                        index = 1;
                        break;
                    }
                case 1:
                    {
                        foreach (Button x in this.new_Buttons) { x.Show(); }
                        foreach (Button y in this.Buttons_arr) { y.Hide(); }
                        index = 0;
                        break;
                    }
                default:
                    index = 0;
                    break;
            }
        }
    }
}
