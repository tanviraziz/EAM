using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using StoreManagement.Properties;

namespace StoreManagement.UTILITY.CustomeControl
{
    public partial class SlidingMenu : UserControl
    {
        #region Veriables
            public event EventHandler OnMenuSelection;
            private static ArrayList NavItems = new ArrayList();
            private static string selecteditem = string.Empty;
            private System.Resources.ResourceManager rm = new System.Resources.ResourceManager("Resources", System.Reflection.Assembly.GetExecutingAssembly());
            int btnHeight = 32;
        #endregion

        public SlidingMenu()
        {
            InitializeComponent();
        }

        public ArrayList MenuItems
        {
            set
            {
                NavItems = value;
            }
            get
            {
                return (NavItems);
            }
        }

        private void OutLookMenu_Load(object sender, EventArgs e)
        {

        }

        public void RenderMenu()
        {
            try
            {
                if (NavItems.Count == 0) return;
                LoadMenuItems(NavItems);
            }
            catch
            {
            }
        }

        private void LoadMenuItems(ArrayList NavItems)
        {
            try
            {
                //int btnHeight = Properties.Resources.Button24.Height;
                Panel mainpanel = new Panel();
                mainpanel.Dock = DockStyle.Top;
                mainpanel.AutoSize = true;
                mainpanel.Name = "mainpanel";

                Panel pnl = new Panel();
                pnl.Height = 20;
                pnl.Dock = DockStyle.Top;
                mainpanel.Controls.Add(pnl);
                string selectedbutton = string.Empty;
                foreach (NavItem navitems in NavItems)
                {
                    Button btn = new Button();
                    btn.Height = btnHeight;
                    btn.BackColor = Color.FromArgb(43, 79, 139);
                    //btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(9, 94, 153);
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn.Dock = DockStyle.Bottom;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Name = navitems.eventCode;
                    btn.Tag = "M_" + navitems.eventCode;
                    btn.Click += new EventHandler(btn_Click);
                    btn.Text = navitems.MnuItem;
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                    btn.Image = global::StoreManagement.Properties.Resources.Arrow_right_24;
                    if (navitems.Selected == true) selectedbutton = btn.Name;

                    mainpanel.Controls.Add(btn);


                    pnl = new Panel();
                    pnl.Dock = DockStyle.Bottom;
                    pnl.Name = "panel_" + navitems.eventCode;
                    pnl.Visible = false;
                    //start:New adition
                    pnl.Padding = new Padding(2, 1, 0, 1);
                    pnl.BackColor = Color.FromArgb(255, 255, 255);
                    //End:New adition

                    foreach (childNavItems childnavitems in navitems.childNavItems)
                    {
                        pnl.Height = (navitems.childNavItems.Count * (btnHeight - 3));
                        Button childbtn = new Button();

                        childbtn.FlatStyle = FlatStyle.Flat;
                        childbtn.FlatAppearance.BorderSize = 0;
                        //btn.FlatAppearance.BorderColor = Color.FromArgb(120, 118, 123);
                        childbtn.Font = new Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        childbtn.BackColor = Color.FromArgb(120, 118, 123);
                        childbtn.ForeColor = Color.White;
                        //childbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(214, 223, 247);                    
                        childbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                        childbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                        //childbtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(4, 109, 181);

                        childbtn.Height = btnHeight - 3;
                        childbtn.Dock = DockStyle.Bottom;
                        childbtn.Text = " " + childnavitems.MnuItem;
                        childbtn.TextAlign = ContentAlignment.MiddleLeft;
                        childbtn.Click += new EventHandler(childbtnbtn_Click);
                        childbtn.Name = childnavitems.eventCode;
                        childbtn.Tag = "C_" + childnavitems.eventCode;
                        pnl.Controls.Add(childbtn);
                    }

                    mainpanel.Controls.Add(pnl);


                }
                panel1.Controls.Add(mainpanel);


                if (selectedbutton != string.Empty)
                {
                    Button btn = (Button)panel1.Controls["mainpanel"].Controls[selectedbutton];
                    selecteditem = btn.Name;
                    ShowChilds(btn);
                    btn.Image = global::StoreManagement.Properties.Resources.Arrow_down_24;
                    btn.ForeColor = Color.FromArgb(255, 184, 77);
                }
            }
            catch
            {

            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (selecteditem != ((Button)sender).Name)
            {
                ShowChilds((Button)sender);
            }

            selecteditem = ((Button)sender).Name;
            ResetALLMainButtons();
            Button btn = (Button)sender;
            btn.Image = global::StoreManagement.Properties.Resources.Arrow_down_24;
            btn.ForeColor = Color.FromArgb(255, 184, 77);

            OnMenuSelection(sender, e);
            

        }
        private void ShowChilds(Button btn)
        {
            ResetAllPanels();
            ResetAllButtons();

            Panel pnl = (Panel)panel1.Controls["mainpanel"].Controls["panel_" + btn.Name];
            pnl.Visible = true;
        }

        private void childbtnbtn_Click(object sender, EventArgs e)
        {
            ResetAllButtons();
            Button btn = (Button)sender;
            btn.Image = global::StoreManagement.Properties.Resources.Right_28;
            btn.ForeColor = Color.FromArgb(255, 184, 77);
            btn.BackColor = Color.FromArgb(96, 84, 112);
            //btn.Height = btnHeight - 7;          
            btn.Font = new Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            OnMenuSelection(sender, e);
        }

        private void ResetALLMainButtons()
        {
            foreach (Control ctrl in panel1.Controls["mainpanel"].Controls)
            {
                if (ctrl is Button)
                {
                    if (ctrl.Name.ToString().Trim() != selecteditem)
                    {
                        Button btn = (Button)ctrl;
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        //btn.BackColor = Color.FromArgb(43, 79, 139);                        
                    }
                }
            }
        }

        private void ResetAllButtons()
        {
            foreach (Control ctrl in panel1.Controls["mainpanel"].Controls["panel_" + selecteditem].Controls)
            {
                if (ctrl is Button)
                {
                    if (ctrl.Name.ToString().Trim() != selecteditem)
                    {
                        Button btn = (Button)ctrl;
                        btn.Image = null;
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btn.BackColor = Color.FromArgb(120, 118, 123);
                        //btn.Height = btnHeight - 3; 
                    }
                }
            }
        }        

        private void ResetAllPanels()
        {
            foreach (Control ctrl in panel1.Controls["mainpanel"].Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;
                    btn.Image = global::StoreManagement.Properties.Resources.Arrow_right_24;
                    //btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
                }
                else if (ctrl is Panel)
                {
                    if (ctrl.Name.Length >= 6)
                    {
                        if (ctrl.Name.Substring(0, 6) == "panel_")
                        {
                            if (ctrl.Visible == true) ctrl.Visible = false;
                        }
                    }
                }
            }
        }

        public class NavItem
        {
            public string MnuItem;
            public string eventCode;
            public ArrayList childNavItems;
            public bool Selected = false;

            public NavItem(string _MnuItem, string _eventCode, ArrayList _childNavItems, bool _selected)
            {
                MnuItem = _MnuItem;
                eventCode = _eventCode;
                childNavItems = _childNavItems;
                Selected = _selected;
            }
            public NavItem(string _MnuItem, string _eventCode, ArrayList _childNavItems)
            {
                MnuItem = _MnuItem;
                eventCode = _eventCode;
                childNavItems = _childNavItems;
            }

        }

        public class childNavItems
        {
            public string MnuItem;
            public string eventCode;
            public childNavItems(string _MnuItem, string _eventCode)
            {
                MnuItem = _MnuItem;
                eventCode = _eventCode;
            }
        }
    }
}
