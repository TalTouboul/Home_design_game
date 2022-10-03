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
    public abstract partial class UnitDesing : Form
    {
        public virtual void Add_Buttons(ref Button[] b, ImageList IL) { }
        //creating new item in the game
        public virtual void Create_item(ref Button b, int index) { }
        //swiching between same objects:
        public virtual void Switch(ref int index) { }
        
        public virtual void LoadUnit(int index) { }
        
        private void UnitDesing_Load(object sender, EventArgs e)
        {

        }
      
        public virtual void save_function(int index) { } 
    }
}
