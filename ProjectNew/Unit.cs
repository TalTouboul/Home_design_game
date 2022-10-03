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
    public partial class Unit : UnitDesing// UnitDesing//Form
    {

        public int saveFile = 1;
        public Unit()
        {
            InitializeComponent();  
        }
        //adding buttons to the panel items:
        public override void Add_Buttons(ref Button[] b, ImageList IL) { }
        //creating new item in the game
        public override void Create_item(ref Button b, int index) { }
         //swiching between same objects:
        public override void Switch( ref int index) { }
        private void Unit_Load(object sender, EventArgs e)
        {
            

        }
        private void ReturnButton_Click(object sender, EventArgs e)
        {
           this.Hide();
           Home.GetHouse().Show();  
        }
        public virtual void save_Click(object sender, EventArgs e) { }
    }
}
