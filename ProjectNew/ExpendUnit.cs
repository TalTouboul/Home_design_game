using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
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
    public struct PB
    {
        public int counter;
        public int tag;
        public int x;
        public int y;
    }
    [Serializable]
    public partial class ExpendUnit : Unit
    {
        private void ExpendUnit_Load(object sender, EventArgs e)
        {

        }
        //parameters for Unit:
        private int Item_counter;
        private int Items_size_limit;
        private PictureBox[] total_pb;
        //parameters for panel saved items:
        protected FlowLayoutPanel pannel;
        protected Button[] Buttons_arr;
        //params for mouse movment:
        private bool IsMouseDown;
        private int m_StartX;
        private int m_StartY;
        private Point old_location;
        Point Point1 = new Point();
        Point StartDownLocation;
        //params for borders:
        private int angle = 45;
        private Graphics g;
        public Rectangle rect_border;
        private PictureBox border_pb;
        private int x_rect;
        private int y_rect;
        private int width_rect;
        private int height_rect;
        //menu items:
        public FlowLayoutPanel _menu;
        public Button[] MenuButton;
        public int ButtonMenu_size;
        public int Iswitch;
        // save parameters:
        public PB[] S;
        public PB[] L;
        public int SaveFile;
        //rect_border_parameters sets/gets:
        protected int Height_rect { get => height_rect; set => height_rect = value; }
        protected int Width_rect { get => width_rect; set => width_rect = value; }
        protected int Y_rect { get => y_rect; set => y_rect = value; }
        protected int X_rect { get => x_rect; set => x_rect = value; }
        protected int Angle { get => angle; set => angle = value; }
        //params for mouse movment sets/gets:
        protected Point Old_location { get => old_location; set => old_location = value; }
        protected int StartY { get => m_StartY; set => m_StartY = value; }
        protected int StartX { get => m_StartX; set => m_StartX = value; }
        //parameters for pictureBox array sets/gets:
        protected int SetItem_counter { get => Item_counter; set => Item_counter = value; }
        protected int SetItems_size_limit { get => Items_size_limit; set => Items_size_limit = value; }
        protected object Border_pb { get; private set; }
        //constructor:
        public ExpendUnit(int type_index)
        {
            InitializeComponent();
            Item_counter = 0;
            Items_size_limit = 100;
            ButtonMenu_size = 4;
            saveFile = 0;
            Iswitch = 0;
            total_pb = new PictureBox[Items_size_limit* Bedroom.Images.Count];
            MenuButton = new Button[ButtonMenu_size];
            pannel = new FlowLayoutPanel();
            _menu = new FlowLayoutPanel();
            border_pb = new PictureBox();
            StartDownLocation = new Point();
            rect_border = new Rectangle();
            IsMouseDown = false;
            setPannel(pannel);
            switch (type_index)
            {
                case 0://room:
                    Buttons_arr = new Button[Bedroom.Images.Count];
                    Add_Buttons(ref Buttons_arr, Bedroom);
                    create_border_image(this.Width / 4 - 60, this.Height / 12, this.Width / 2 + 100, this.Height - 50);
                    this.BackgroundImage = Properties.Resources.room1;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    break;
                case 1://kitchen
                    Buttons_arr = new Button[Kitchen.Images.Count];
                    Add_Buttons(ref Buttons_arr, Kitchen);
                    create_border_image(this.Width / 4 - 60, this.Height / 12, this.Width / 2 + 50, this.Height - 150);
                    this.BackgroundImage = Properties.Resources.kitchen;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    break;
                case 2://toilet:
                    Buttons_arr = new Button[bathroom.Images.Count];
                    Add_Buttons(ref Buttons_arr, bathroom);
                    create_border_image(this.Width / 4 - 60, this.Height / 12, this.Width / 2 + 100, this.Height - 50);
                    this.BackgroundImage = Properties.Resources.toilet;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    break;
                case 3://garden:
                    Buttons_arr = new Button[Garden.Images.Count];
                    Add_Buttons(ref Buttons_arr, Garden);
                    create_border_image(this.Width / 4 - 60, this.Height / 12, this.Width / 2+100, this.Height);
                    this.BackgroundImage = Properties.Resources.garden;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    break;
                default:
                    MessageBox.Show("no type of room was find");
                    break;    
            };
        }
        //copi-constructor:
        protected ExpendUnit(ref ExpendUnit other, int type_index)
        {
            this.Items_size_limit = other.Items_size_limit;
            this.Item_counter = other.Item_counter;
            this.pannel = other.pannel;


            switch (type_index)
            {
                case 0://room:
                    for (int i = 0; i < Bedroom.Images.Count; i++) { this.Buttons_arr[i] = other.Buttons_arr[i]; }
                    for (int i = 0; i < Item_counter; i++) { this.total_pb[i] = other.total_pb[i]; }
                    break;
                case 1://kitchen
                    for (int i = 0; i < Kitchen.Images.Count; i++) { this.Buttons_arr[i] = other.Buttons_arr[i]; }
                    for (int i = 0; i < Item_counter; i++) { this.total_pb[i] = other.total_pb[i]; }
                    break;
                case 2://toilet:
                    for (int i = 0; i < bathroom.Images.Count; i++) { this.Buttons_arr[i] = other.Buttons_arr[i]; }
                    for (int i = 0; i < Item_counter; i++) { this.total_pb[i] = other.total_pb[i]; }
                    break;
                case 3://garden:
                    for (int i = 0; i < Garden.Images.Count; i++) { this.Buttons_arr[i] = other.Buttons_arr[i]; }
                    for (int i = 0; i < Item_counter; i++) { this.total_pb[i] = other.total_pb[i]; }
                    break;
                default:
                    MessageBox.Show("no type of room was find");
                    break;
            };
            
        }
        //adding and bulding pannel that used for menu to create new items:
        protected void setPannel(FlowLayoutPanel Pannel)
        {
            Pannel.Show();
            Pannel.AutoScroll = true;
            Pannel.Enabled = true;
            Pannel.AllowDrop = true;
            Pannel.Dock = DockStyle.Bottom;
            Pannel.Size = new Size(800, 88);
            Pannel.BorderStyle = BorderStyle.Fixed3D;
            Pannel.BackColor = Color.DarkKhaki;
            Pannel.AutoSizeMode = AutoSizeMode.GrowOnly;
            Pannel.Name = "AddPanel";
            this.Controls.Add(pannel);
        }
        protected FlowLayoutPanel getPanel() { return pannel; }
        //adding and building array of buttons in the pannel to create new items
        public override void Add_Buttons(ref Button[] b, ImageList IL)
        {
            for (int i = 0; i < IL.Images.Count; i++)
            {
                int index = i;
                b[i] = new Button();
                b[i].Location = new System.Drawing.Point(((i + 1) * 50), 300);
                b[i].Name = "Image" + (index + 1);
                b[i].Size = new System.Drawing.Size(100, 65);
                b[i].TabIndex = i;
                b[i].UseVisualStyleBackColor = true;
                b[i].Visible = true;
                b[i].Cursor = Cursors.Hand;
                b[i].Image = IL.Images[i];
                b[i].BackColor = Color.White;
                b[i].AutoSizeMode = AutoSizeMode.GrowOnly;
                b[i].BackgroundImageLayout = ImageLayout.Stretch;
                b[i].Tag = i;
                Button t = b[i];
                b[i].Click += (sender1, args) => Create_item(ref t, 0);
                this.Controls.Add(b[i]);
                this.pannel.Controls.Add(b[i]);
            }
        }
        //creating new item in the game
        public override void Create_item(ref Button b, int menu_exist)
        {
            if (Item_counter < Items_size_limit)
            {
                total_pb[Item_counter] = new PictureBox();
                //pb_definitions:
                total_pb[Item_counter].Location = new Point(200, 300);
                total_pb[Item_counter].BackgroundImage = b.Image;
                total_pb[Item_counter].BackColor = Color.Transparent;
                total_pb[Item_counter].SizeMode = PictureBoxSizeMode.AutoSize;
                total_pb[Item_counter].SizeMode = PictureBoxSizeMode.CenterImage;
                total_pb[Item_counter].SizeMode = PictureBoxSizeMode.StretchImage;
                total_pb[Item_counter].BackgroundImageLayout = ImageLayout.Stretch;
                total_pb[Item_counter].BringToFront();
                total_pb[Item_counter].Cursor = Cursors.Hand;
                total_pb[Item_counter].Tag = b.Tag;
                total_pb[Item_counter].Visible = true;
                total_pb[Item_counter].Show();
                Controls.Add(total_pb[Item_counter]);
                //pb_events:
                total_pb[Item_counter].DoubleClick += (sender1, args) => add_Menu(sender1, args);
                total_pb[Item_counter].MouseDown += (sender1, ex) => Location_Item(sender1, ex);
                total_pb[Item_counter].MouseMove += (sender1, ex) => Move_Item(sender1, ex);
                total_pb[Item_counter].MouseUp += (sender1, ex) => EndMove_Item(sender1, ex);
                Item_counter++;
            }
            else { MessageBox.Show("You have reached the maximum number of items in the room,\n\nto add another item delete an old one."); }
            if (menu_exist == 2)
            {
                for (int i = 0; i < Item_counter; i++) { total_pb[i].Show(); }
                foreach(Button x in MenuButton) 
                { 
                    this.Controls.Remove(x);
                    x.Hide();
                }
                _menu.Hide();
            } 
        }

        //adding and building menu for each item in the game
        //menu iuncludes: create,change and delete an item
        public void add_Menu(object sender, EventArgs e)
        {
            PictureBox temp1 = (PictureBox)sender;
            //panel//
            _menu.Show();
            _menu.Enabled = true;
            _menu.AllowDrop = true;
            _menu.AutoScroll = true;
            _menu.Location = new Point(this.Width, 0);
            _menu.Height = 3 * 50 + 20;
            _menu.Width = 60;
            _menu.Dock = DockStyle.Right;
            _menu.AutoSizeMode = AutoSizeMode.GrowOnly;
            _menu.BackColor = System.Drawing.Color.DarkKhaki;
            _menu.Name = "MENU";
            _menu.Text = _menu.Name;
            this.Controls.Add(_menu);
            //Button//
            int x = this.Width - 150, y = 200;
            for (int i = 0; i < ButtonMenu_size; i++)
            {
                MenuButton[i] = new Button();
                MenuButton[i].BringToFront();
                MenuButton[i].Show();
                MenuButton[i].Visible = true;
                MenuButton[i].Cursor = Cursors.Hand;
                MenuButton[i].Height = 50;
                MenuButton[i].Width = 50;
                MenuButton[i].Location = new System.Drawing.Point(x, y - 50 * i);
                MenuButton[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.Controls.Add(MenuButton[i]);
                this._menu.Controls.Add(MenuButton[i]);
            }
            for(int i = 0; i < Item_counter; i++) { if(total_pb[i] != temp1) { total_pb[i].Hide(); } }
            this.Click += (sender1, args) => exitMenu(sender1, args);
            MenuButton[0].Click += (sender1, args) => deleteItem(temp1); //deleteItem
            MenuButton[0].Image = Menu.Images[0];
            MenuButton[0].Name = "DeleteButton";
            MenuButton[1].Click += (sender1, args) => Create_item(ref Buttons_arr[(int)temp1.Tag], 2);//copyItem
            MenuButton[1].Image = Menu.Images[1];
            MenuButton[1].Name = "CopyItemButton";
            MenuButton[2].Click += (sender1, args) => switch_item(ref temp1); //switchItem
            MenuButton[2].Image = Menu.Images[3];
            MenuButton[2].Name = "SwitchButton";
            MenuButton[3].Click += (sender1, args) => exitMenu(sender1, args);//ExitItemMenu
            MenuButton[3].Image = Menu.Images[2];
            MenuButton[3].Name = "ExitItemMenu";
        }
        //the next functions are defining the momvmet of the item in the game:
        protected void Location_Item(object sender, MouseEventArgs e)
        {
            PictureBox temp_pb = (PictureBox)sender;
            IsMouseDown = true;
            m_StartX = e.X;
            m_StartY = e.Y;
            Old_location = temp_pb.Location;
            StartDownLocation = e.Location;
        }
        protected void Move_Item(object sender, MouseEventArgs e)
        {
            PictureBox temp_pb = (PictureBox)sender;
            if (IsMouseDown == false) { return; }
            if (IsMouseDown == true)
            {
                Point1.X = e.X + temp_pb.Location.X - StartDownLocation.X;
                Point1.Y = e.Y + temp_pb.Location.Y - StartDownLocation.Y;
                temp_pb.Location = Point1;
                this.Update();
            }

            if (this.rect_border.IntersectsWith(temp_pb.Bounds) == false)
            {
                temp_pb.Location = Old_location;
                temp_pb.Cursor = Cursors.No;
                IsMouseDown = false;
            }
        }
        protected void EndMove_Item(object sender1, MouseEventArgs ex)
        {
            PictureBox temp_pb = (PictureBox)sender1;
            temp_pb.Cursor = Cursors.Hand;
            IsMouseDown = false;
            temp_pb.Invalidate();
        }
        protected void create_border_image(int x, int y, int w, int h)
        {
            border_pb.Size = new Size(this.Width, this.Height);
            border_pb.Location = new Point(0, 0);
            border_pb.BringToFront();
             this.Controls.Add(this.border_pb);
            border_pb.Paint += (sender1, ex) => rectangle_boundes_paint(sender1, ex, x, y, w, h);
        }
        protected void rectangle_boundes_paint(object sender, PaintEventArgs e, int x, int y, int w, int h)
        {
            g = e.Graphics;
            this.rect_border = new Rectangle(x, y, w, h);
            border_pb.Visible = false;
            g.TranslateTransform(rect_border.X, rect_border.Y);
            g.RotateTransform(Angle);
            g.TranslateTransform(-rect_border.X, -rect_border.Y);
            g.DrawRectangle(Pens.Black, rect_border);
            g.FillRectangle(Brushes.Black, rect_border); 
        }
        //functions for edit items:
        public void deleteItem(PictureBox temp1)
        {
            for (int i = 0; i < ButtonMenu_size; i++)
            {
                this.Controls.Remove(MenuButton[i]);
                MenuButton[i].Hide();
            }
            _menu.Hide();
            for (int i = 0; i < Item_counter; i++) { total_pb[i].Show(); }
            this.Controls.Remove(temp1);
            temp1.Hide();
        }
        public void switch_item(ref PictureBox temp1)
        {
            if (Iswitch < Buttons_arr.Length) 
            { 
                temp1.Image = Buttons_arr[Iswitch].Image;
                temp1.Tag = Buttons_arr[Iswitch++].Tag;
            }
            else { Iswitch = 0; }
        }
        public void exitMenu(object sender, EventArgs e) 
        {
            for (int i = 0; i < ButtonMenu_size; i++)
            {
                this.Controls.Remove(MenuButton[i]);
                MenuButton[i].Hide();
            }
            for (int i = 0; i < Item_counter; i++) { total_pb[i].Show(); }
            _menu.Hide(); 
        }
        //this functions are used for save and load data:
        public override void save_Click(object sender, EventArgs e)
        {
            save_function(saveFile);
            MessageBox.Show("saved successfully");
            saveFile++;
        }
        public override void save_function(int index)
        {
            saveFile = index;
            if (saveFile >= 19) { saveFile = 0; }
            S = new PB[Item_counter];
            for (int i = 0; i < Item_counter; i++)
            {
                S[i] = new PB();
                S[i].tag = (int)total_pb[i].Tag;
                S[i].x = total_pb[i].Location.X;
                S[i].y = total_pb[i].Location.Y;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(PB[]));
            using (TextWriter stream = new StreamWriter("savedUnit" + saveFile + ".xml"))
            {
                serializer.Serialize(stream, S);
            }
           
        }
        public override void LoadUnit(int index)
        {
            string LoadData;
            //if (index == 0) { LoadData = "C:\\Users\\Tal\\Desktop\\לימודים\\Csharp פרוייקטים\\פרוייקט סוף תכנות מונחה עצמים\\project end\\ProjectNew\\bin\\Debug\\savedUnit.xml"; }
             LoadData = "C:\\Users\\Tal\\Desktop\\לימודים\\Csharp פרוייקטים\\פרוייקט סוף תכנות מונחה עצמים\\project end\\ProjectNew\\bin\\Debug\\savedUnit" + index + ".xml"; 
            XmlSerializer serializer = new XmlSerializer(typeof(PB[]));
            FileStream stream = new FileStream(LoadData, FileMode.Open);
            L = (PB[])serializer.Deserialize(stream);
            for (int i = 0; i < L.Length; i++)
            {
                Create_item(ref Buttons_arr[L[i].tag], 0);
                total_pb[i].Location = new Point(L[i].x, L[i].y);
            }
        }
    }
}
   