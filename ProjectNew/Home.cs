using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
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
    public partial class Home : Form
    {
        public static SoundPlayer backround_music = new SoundPlayer(Properties.Resources.BPC102___12_Dream);
        public static House _newHouse;
        private string houseName = "None"; //שם בעל הבית המשתמש יכניס ערכים אלו ביצירת משחק חדש
        public Home()
        {
            InitializeComponent();
            NewButton.Hide();
            LoadButton.Hide();
            WelcomeTEXT.Hide();
            EnterNameTEXT.Hide();
            GetIntoHouseButton.Hide();
        }
        public static House GetHouse()
        {
            return _newHouse;
        }
        public void setHouseName(string _houseName) //עדכון שם משתמש
        {
            this.houseName = _houseName;
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            string LoadData = "C:\\Users\\Tal\\Desktop\\לימודים\\Csharp פרוייקטים\\פרוייקט סוף תכנות מונחה עצמים\\project end\\ProjectNew\\bin\\Debug\\savedGame.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(UNITS));

            FileStream stream = new FileStream(LoadData, FileMode.Open);
            if (stream.Length == 0)
            {
                _newHouse = new House();
                NewButton.Hide();
                LoadButton.Hide();
                EnterNameTEXT.Show();
            }
            else
            {
                UNITS L = (UNITS)serializer.Deserialize(stream);
                _newHouse = new House(L);
                NewButton.Hide();
                LoadButton.Hide();
                GetIntoHouseButton.Show();
            }
        }
        private void PlayButton_Click(object sender, EventArgs e)
        {
            backround_music.PlayLooping();
            NewButton.Show();
            LoadButton.Show();
            PlayButton.Hide();
        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            _newHouse = new House();
            NewButton.Hide();
            LoadButton.Hide();
            EnterNameTEXT.Show();
        }
        private void EnterNameTEXT_TextChanged(object sender, KeyPressEventArgs e)
        {
            string name = EnterNameTEXT.Text;
            if (e.KeyChar == (char)Keys.Enter)
            {
                setHouseName(name);
                EnterNameTEXT.Hide();
                WelcomeTEXT.Show();
                GetIntoHouseButton.Show();
            }
            WelcomeTEXT.Text = "Welcome, " + houseName + "\n\n" + " Let's start design your new home";
        }
        private void EnterNameTEXT_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void GetIntoHouseButton_Click(object sender, EventArgs e)
        {
            WelcomeTEXT.Hide();
            _newHouse.Show();  
        }
    }
}
