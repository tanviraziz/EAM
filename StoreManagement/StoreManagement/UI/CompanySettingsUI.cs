using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreManagement.BLL;
using StoreManagement.DAL.DAO;
using StoreManagement.UTILITY;
using System.IO;

namespace StoreManagement.UI
{
    public partial class CompanySettingsUI : Form
    {
        #region Veriables
            private MasterSetupManager settingsManager = null;
            private DynamicControlFill fillControl = null;
            private Company company = null;
            private bool IsEdit = false;
            private string imageFilePath;
            private DataTable dataTable = null;
        #endregion

        public CompanySettingsUI()
        {
            InitializeComponent();
            SetObjects();
        }

        private void SetObjects()
        {
            settingsManager = new MasterSetupManager();
            fillControl = new DynamicControlFill();
        }

        #region Management

        private DataTable GetRecordSet(byte choice)
        {
            DataTable dt = null;
            try
            {                
                switch (choice)
                {
                    case 0:
                        dt = settingsManager.GetCompanyInfo("1", null);
                        break;
                    case 1:
                        dt = settingsManager.GetCompanyInfo("1", null);
                        break;
                    case 2:
                        dt = settingsManager.GetCompanyInfo("1", null);
                        break;
                }                
            }
            catch
            {
                return null;
            }
            return dt;
        }

        private void companySettingsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();  
        }

        private void ShowData()
        {
            switch (companySettingsTabControl.SelectedIndex)
            {
                //case 0:
                //    fillControl.fillListView(itemListView, masterManager.GetItemList("1", null), "Sl No.,Item,Category,SubCategory,Stationary,", "50,250,150,200,200,");
                //    break;
                case 1:
                    fillControl.fillListView(unitListView, settingsManager.GetCompanyUnitList("2", null), "Unit Code,Unit", "150,250,");
                    //unitListView.View = View.List;
                    fillControl.fillListView(departmentListView, settingsManager.GetDepartmentList("2", null), "Department Code, Department", "150,250,");
                    break;

            }
        }
        #endregion


        #region Company Settings

        private void FillValues(DataTable companyDT)
        {
            try
            {
                if (companyDT.Rows.Count > 0)
                {
                    nameTextBox.Text = companyDT.Rows[0]["Name"].ToString();
                    addressTextBox.Text = companyDT.Rows[0]["Address"].ToString();
                    phoneNoTextBox.Text = companyDT.Rows[0]["PhoneNO"].ToString();
                    emailTextBox.Text = companyDT.Rows[0]["Email"].ToString();
                    faxTextBox.Text = companyDT.Rows[0]["Fax"].ToString();
                    if ((companyDT.Rows[0]["Logo"]) != DBNull.Value)
                    {
                        loadPicture(companyDT.Rows[0]["Logo"]);
                    }
                    else
                    {
                        logoPictureBox.Image = null;
                    }

                    IsEdit = true;
                }                
            }
            catch { }
        }

        //browse the logo
        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string folder = Properties.Settings.Default.LastFolder;
            if (Directory.Exists(folder))
                openFileDialog.InitialDirectory = folder;
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Image Files (*.jpg;*jpeg)|*.jpg;*jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                folder = Path.GetDirectoryName(openFileDialog.FileName);
                Properties.Settings.Default.LastFolder = folder;
                Properties.Settings.Default.Save();
                imageFilePath = openFileDialog.FileName;
                logoPictureBox.Image = Image.FromFile(imageFilePath);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                if(settingsManager.CompanyManagement(company))
                {
                    MessageBox.Show("Saved successfully.");
                }
            }
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Enter company name.");
                nameTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Enter company name.");
                nameTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(phoneNoTextBox.Text))
            {
                MessageBox.Show("Enter company name.");
                nameTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Enter company name.");
                nameTextBox.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(faxTextBox.Text))
            {
                MessageBox.Show("Enter company name.");
                nameTextBox.Focus();
                return false;
            }
            else
            {
                SetValues();
            }
            return true;
        }

        private void SetValues()
        {
            if (company == null)
            {
                company = new Company();
            }
            company.Name = nameTextBox.Text.Trim();
            company.Address = addressTextBox.Text.Trim();
            company.PhoneNo = phoneNoTextBox.Text.Trim();
            company.Email = emailTextBox.Text.Trim();
            company.Fax = faxTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(imageFilePath))
            {
                company.Logo = picture();
            }

            if (IsEdit)
            {
                company.Condtion = "2";
            }
            
        }

        private Byte[] picture()
        {
            //Read jpg into file stream, and from there into Byte array.
            System.IO.FileStream fsBLOBFile = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            Byte[] bytBLOBData = new Byte[fsBLOBFile.Length];
            fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length);
            fsBLOBFile.Close();
            return bytBLOBData;
        }

        private void loadPicture(object imageObj)
        {
            Byte[] byteData = new Byte[0];
            byteData = (Byte[])(imageObj);
            MemoryStream strimeData = new MemoryStream(byteData);
            logoPictureBox.Image = Image.FromStream(strimeData);

        }

        #endregion

        #region Unit Management
        // Help LInk[http://stackoverflow.com/questions/5045427/is-it-possible-to-have-drag-and-drop-from-a-listview-to-a-treeview-in-winforms]
        //http://www.dotnetcurry.com/ShowArticle.aspx?ID=209        ++
        private void unitListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            unitListView.DoDragDrop(unitListView.SelectedItems, DragDropEffects.Move);            
        }

        private void departmentListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            departmentListView.DoDragDrop(departmentListView.SelectedItems, DragDropEffects.Move);
        }

        private void unitTreeView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                e.Effect = DragDropEffects.Move;
        }

        private void departmentTreeView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                e.Effect = DragDropEffects.Move;
        }

        private void unitListView_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
                Cursor.Current = Cursors.Cross;
            else
                Cursor.Current = Cursors.Default;
        }

        private void departmentListView_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
                Cursor.Current = Cursors.Cross;
            else
                Cursor.Current = Cursors.Default;
        }

        private void unitTreeView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection).ToString(), false))
            {
                Point loc = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode destNode = ((TreeView)sender).GetNodeAt(loc);
                TreeNode tnNew;

                ListView.SelectedListViewItemCollection lstViewColl =
                    (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
                foreach (ListViewItem lvItem in lstViewColl)
                {
                    tnNew = new TreeNode(lvItem.Text);
                    tnNew.Tag = lvItem;
                    if (destNode == null)
                    {
                        unitTreeView.Nodes[0].Nodes.Add(tnNew);
                        //break;

                        departmentTreeView.Nodes[0].Nodes.Add(tnNew);
                    }
                    else
                    {
                        //destNode.Nodes.Insert(destNode.Index + 1, tnNew);
                        //destNode.Expand();
                        unitTreeView.Nodes.Insert(destNode.Index + 1, tnNew);
                        unitTreeView.ExpandAll();

                        departmentTreeView.Nodes.Insert(destNode.Index + 1, tnNew);
                        departmentTreeView.ExpandAll();
                    }
                    
                    // Remove this line if you want to only copy items
                    // from ListView and not move them
                    lvItem.Remove();
                }
            }
        }

        private void departmentTreeView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection).ToString(), false))
            {
                Point loc = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode destNode = ((TreeView)sender).GetNodeAt(loc);
                
                TreeNode tnNew;

                ListView.SelectedListViewItemCollection lstViewColl =
                    (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
                foreach (ListViewItem lvItem in lstViewColl)
                {
                    tnNew = new TreeNode(lvItem.Text);
                    tnNew.Tag = lvItem;
                    if (destNode == null)
                    {
                        departmentTreeView.Nodes[0].Nodes.Add(tnNew);
                        //break;
                    }
                    else
                    {
                        destNode.Nodes.Insert(destNode.Index + 1, tnNew);
                        destNode.Expand();
                    }
                    
                    // Remove this line if you want to only copy items
                    // from ListView and not move them
                    lvItem.Remove();
                }
            }
        }



        #endregion

        private void CompanySettingsUI_Load(object sender, EventArgs e)
        {
            taskPane1.UseCustomTheme(fillControl.GetAppPath() + @"\CustomeStyle\shellstyle.dll");
            unitListView.ItemDrag += new ItemDragEventHandler(unitListView_ItemDrag);
            unitListView.GiveFeedback += new GiveFeedbackEventHandler(unitListView_GiveFeedback);
            unitTreeView.DragEnter += new DragEventHandler(unitTreeView_DragEnter);
            unitTreeView.DragDrop += new DragEventHandler(unitTreeView_DragDrop);

            departmentListView.ItemDrag += new ItemDragEventHandler(departmentListView_ItemDrag);
            departmentListView.GiveFeedback += new GiveFeedbackEventHandler(departmentListView_GiveFeedback);
            departmentTreeView.DragEnter += new DragEventHandler(departmentTreeView_DragEnter);
            departmentTreeView.DragDrop += new DragEventHandler(departmentTreeView_DragDrop);
            //PopulateListViewTreeView();
        }

        private void PopulateListViewTreeView()
        {
            List<string> lst = new List<string>();
            lst.Add("Item1");
            lst.Add("Item2");
            lst.Add("Item3");
            lst.Add("Item4");
            lst.Add("Item5");
            lst.Add("Item6");

            // Populate ListView
            //new DynamicControlFill().fillListView(listView1, new MasterSetupManager().GetCompanyUnitList("2", null), "Unit Code,Unit", "150,250,");
            //for (int i = 0; i < lst.Count; i++)
            //{
            //    ListViewItem lvItem = new ListViewItem(lst[i].ToString());
            //    listView1.Items.Add(lvItem);
            //    //lvItem.EnsureVisible();
            //}

            // Populate TreeView
            for (int i = 0; i < lst.Count; i++)
            {
                TreeNode node = new TreeNode(lst[i].ToString());
                if (i % 2 == 0)
                    unitTreeView.Nodes.Add(node);
                else
                    unitTreeView.Nodes[0].Nodes.Add(node);
                node.EnsureVisible();
            }
            unitTreeView.ExpandAll();
            unitTreeView.AllowDrop = true;
        }

        

    }
}
