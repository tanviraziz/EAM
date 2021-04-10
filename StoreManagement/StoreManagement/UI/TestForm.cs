using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreManagement.BLL;
using StoreManagement.UTILITY;

namespace StoreManagement.UI
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            listView1.ItemDrag += new ItemDragEventHandler(listView1_ItemDrag);
            listView1.GiveFeedback += new GiveFeedbackEventHandler(listView1_GiveFeedback);
            treeView1.DragEnter += new DragEventHandler(treeView1_DragEnter);
            treeView1.DragDrop += new DragEventHandler(treeView1_DragDrop);
            PopulateListViewTreeView();
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
            new DynamicControlFill().fillListView(listView1, new MasterSetupManager().GetCompanyUnitList("2", null), "Unit Code,Unit", "150,250,");
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
                    treeView1.Nodes.Add(node);
                else
                    treeView1.Nodes[0].Nodes.Add(node);
                node.EnsureVisible();
            }
            treeView1.ExpandAll();
            treeView1.AllowDrop = true;
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(listView1.SelectedItems, DragDropEffects.Move);
        }

        private void listView1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
                Cursor.Current = Cursors.Cross;
            else
                Cursor.Current = Cursors.Default;
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                e.Effect = DragDropEffects.Move;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
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

                    destNode.Nodes.Insert(destNode.Index + 1, tnNew);
                    destNode.Expand();
                    // Remove this line if you want to only copy items
                    // from ListView and not move them
                    lvItem.Remove();
                }
            }
        }
        
    }
}
