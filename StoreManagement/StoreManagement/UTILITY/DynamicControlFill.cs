using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;


namespace StoreManagement.UTILITY
{
        /// <summary>
        /// http://stackoverflow.com/questions/254129/how-to-i-display-a-sort-arrow-in-the-header-of-a-list-view-column-using-c
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static class ListViewExtensions
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct HDITEM
            {
                public Mask mask;
                public int cxy;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string pszText;
                public IntPtr hbm;
                public int cchTextMax;
                public Format fmt;
                public IntPtr lParam;
                // _WIN32_IE >= 0x0300 
                public int iImage;
                public int iOrder;
                // _WIN32_IE >= 0x0500
                public uint type;
                public IntPtr pvFilter;
                // _WIN32_WINNT >= 0x0600
                public uint state;

                [Flags]
                public enum Mask
                {
                    Format = 0x4,       // HDI_FORMAT
                };

                [Flags]
                public enum Format
                {
                    SortDown = 0x200,   // HDF_SORTDOWN
                    SortUp = 0x400,     // HDF_SORTUP
                };
            };

            public const int LVM_FIRST = 0x1000;
            public const int LVM_GETHEADER = LVM_FIRST + 31;

            public const int HDM_FIRST = 0x1200;
            public const int HDM_GETITEM = HDM_FIRST + 11;
            public const int HDM_SETITEM = HDM_FIRST + 12;

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, ref HDITEM lParam);

            public static void SetSortIcon(this ListView listViewControl, int columnIndex, SortOrder order)
            {
                try
                {
                    IntPtr columnHeader = SendMessage(listViewControl.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
                    for (int columnNumber = 0; columnNumber <= listViewControl.Columns.Count - 1; columnNumber++)
                    {
                        var columnPtr = new IntPtr(columnNumber);
                        var item = new HDITEM
                        {
                            mask = HDITEM.Mask.Format
                        };

                        if (SendMessage(columnHeader, HDM_GETITEM, columnPtr, ref item) == IntPtr.Zero)
                        {
                            throw new Win32Exception();
                        }

                        if (order != SortOrder.None && columnNumber == columnIndex)
                        {
                            switch (order)
                            {
                                case SortOrder.Ascending:
                                    item.fmt &= ~HDITEM.Format.SortDown;
                                    item.fmt |= HDITEM.Format.SortUp;
                                    break;
                                case SortOrder.Descending:
                                    item.fmt &= ~HDITEM.Format.SortUp;
                                    item.fmt |= HDITEM.Format.SortDown;
                                    break;
                            }
                        }
                        else
                        {
                            item.fmt &= ~HDITEM.Format.SortDown & ~HDITEM.Format.SortUp;
                        }

                        if (SendMessage(columnHeader, HDM_SETITEM, columnPtr, ref item) == IntPtr.Zero)
                        {
                            throw new Win32Exception();
                        }
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// http://www.c-sharpcorner.com/uploadfile/nipuntomar/sort-a-multicolumn-listview-in-C-Sharp/
        /// </summary>
        public class ItemComparer : IComparer
        {
            //column used for comparison
            public int Column { get; set; }
            //Order of sorting
            public SortOrder Order { get; set; }
            public ItemComparer(int colIndex)
            {
                Column = colIndex;
                Order = SortOrder.None;
            }
            public int Compare(object a, object b)
            {
                int result = 0;
                try
                {
                    //int result;
                    //ListViewItem itemA = a as ListViewItem;
                    //ListViewItem itemB = b as ListViewItem;
                    //if (itemA == null && itemB == null)
                    //    result = 0;
                    //else if (itemA == null)
                    //    result = -1;
                    //else if (itemB == null)
                    //    result = 1;
                    //if (itemA == itemB)
                    //    result = 0;
                    ////alphabetic comparison
                    //result = String.Compare(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);
                    //// if sort order is descending.
                    //if (Order == SortOrder.Descending)
                    //    // Invert the value returned by Compare.
                    //    result *= -1;
                    //return result;


                    ListViewItem itemA = a as ListViewItem;
                    ListViewItem itemB = b as ListViewItem;
                    if (itemA == null && itemB == null)
                        result = 0;
                    else if (itemA == null)
                        result = -1;
                    else if (itemB == null)
                        result = 1;
                    if (itemA == itemB)
                        result = 0;

                    // datetime comparison
                    DateTime x1, y1;
                    // Parse the two objects passed as a parameter as a DateTime.
                    if (!DateTime.TryParse(itemA.SubItems[Column].Text, out x1))
                        x1 = DateTime.MinValue;
                    if (!DateTime.TryParse(itemB.SubItems[Column].Text, out y1))
                        y1 = DateTime.MinValue;
                    result = DateTime.Compare(x1, y1);
                    if (x1 != DateTime.MinValue && y1 != DateTime.MinValue)
                        goto done;

                    //numeric comparison
                    decimal x2, y2;
                    if (!Decimal.TryParse(itemA.SubItems[Column].Text, out x2))
                        x2 = Decimal.MinValue;
                    if (!Decimal.TryParse(itemB.SubItems[Column].Text, out y2))
                        y2 = Decimal.MinValue;
                    result = Decimal.Compare(x2, y2);
                    if (x2 != Decimal.MinValue && y2 != Decimal.MinValue)
                        goto done;
                    //alphabetic comparison
                    result = String.Compare(itemA.SubItems[Column].Text, itemB.SubItems[Column].Text);

                done:
                    // if sort order is descending.
                    if (Order == SortOrder.Descending)
                        // Invert the value returned by Compare.
                        result *= -1;

                }
                catch { }
                return result;
            }
        }

        // Implements the manual sorting of items by column.
        class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                ((ListViewItem)y).SubItems[col].Text);
                return returnVal;
            }
        }
        public class DynamicControlFill
        {
            /// <summary>
            /// Dynamically Fill a ComboBox
            /// </summary>
            /// <param name="processCombo"></param>
            /// <param name="comboFillDT"></param>
            /// <param name="displayMemeber"></param>
            /// <param name="valueMember"></param>
            public void fillCombo(System.Windows.Forms.ComboBox processCombo, DataTable comboFillDT, string displayMember, string valueMember)
            {
                try
                {
                    if (comboFillDT.Rows.Count > 0)
                    {
                        processCombo.DataSource = comboFillDT;
                        processCombo.DisplayMember = displayMember.Trim();
                        processCombo.ValueMember = valueMember.Trim();
                        //processCombo.SelectedIndex = -1;
                    }
                    else
                    {
                        processCombo.DataSource = null;
                        processCombo.Items.Clear();
                    }
                }
                catch { }
                finally
                {
                    comboFillDT = null;
                    //comboFillDT.Dispose();
                }
            }
            // end of combobox fill module
            //--------------------------------------------------------------------------------------------------


            /// <summary>
            /// Dyanamically fill a treeview 
            /// </summary>
            /// <param name="processTree"></param>
            /// <param name="treeFillDT"></param>
            public void fillTreeView(System.Windows.Forms.TreeView processTree, DataTable treeFillDT)
            {
                int count = 0;
                string nodeName = "", nodeTag = "";

                try
                {
                    foreach (DataRow dr in treeFillDT.Rows)
                    {
                        count = 0;
                        TreeNode[] nodeArray = new TreeNode[5];
                        foreach (object cri in dr.ItemArray)
                        {
                            if (count == 0)
                            {
                                nodeName = cri.ToString();
                            }
                            else if (count == 1)
                            {
                                nodeTag = cri.ToString();
                            }
                            else
                            {
                                TreeNode childNode = new TreeNode("(" + (count - 1).ToString() + ") " + cri.ToString());
                                childNode.ForeColor = Color.SlateGray;
                                nodeArray[count - 2] = childNode;
                            }
                            count++;
                        }
                        TreeNode tr = new TreeNode(nodeName, nodeArray);
                        tr.Tag = nodeTag;
                        tr.ForeColor = Color.Black;
                        //tr.NodeFont = new Font("Verdana",8f,FontStyle.Bold);
                        //tr.BackColor = Color.FromArgb(129, 184, 153);
                        processTree.Nodes.Add(tr);
                        //processTree.Parent.Font = f;
                    }
                }
                catch
                {
                    //throw;
                }
                finally
                {
                    treeFillDT.Dispose();
                }
            }
            // end of Treeview fill module

            //--------------------------------------------------------------------------------------------------


            /// <summary>
            /// Dyanamically fill a Listbox
            /// </summary>
            /// <param name="processListBox"></param>
            /// <param name="listBoxFillDT"></param>
            public void fillListbox(System.Windows.Forms.ListBox processListBox, DataTable listBoxFillDT)
            {
                int count;
                try
                {
                    foreach (DataRow dr in listBoxFillDT.Rows)
                    {
                        count = 1;
                        foreach (object listItem in dr.ItemArray)
                        {
                            if (count == 1)
                            {
                                processListBox.Items.Add(listItem.ToString());
                                count++;
                            }
                            else if (count == 2)
                            {
                                processListBox.Tag = listItem.ToString();
                            }
                        }
                    }
                }
                catch
                {
                    //throw;
                }
                finally
                {
                    listBoxFillDT.Dispose();
                }
            }
            // end of Listbox fill module


            //--------------------------------------------------------------------------------------------------


            /// <summary>
            /// Dyanamically fill a ListView, just send the listview name, datatable, header name and column width
            /// </summary>
            /// <param name="processListView"></param>
            /// <param name="listViewFillDT"></param>
            /// <param name="strColHeader"></param>
            /// <param name="strColWidth"></param>
            public void fillListView(System.Windows.Forms.ListView processListView, DataTable listViewFillDT, string strColHeader, string strColWidth)
            {
                string[] colHeader = null;
                string[] colWidth = null;
                int i,j, count;
                ListViewItem itemX = null;
                processListView.Refresh();
                processListView.View = View.Details;
                processListView.BeginUpdate();
                processListView.Items.Clear();
                if (listViewFillDT == null || listViewFillDT.Rows.Count <= 0)
                {
                    processListView.EndUpdate();
                    return;
                }


                if (!string.IsNullOrEmpty(strColHeader))
                {
                    colHeader = strColHeader.Split(new char[] { ',' });
                }
                else
                {
                    colHeader = (from DataColumn x in listViewFillDT.Columns
                                 select x.ColumnName).ToArray();
                }
                var names = (from col in processListView.Columns.Cast<ColumnHeader>()
                             orderby col.DisplayIndex
                             select col.Text).ToList();
                if ((strColWidth == "" ? strColWidth = null : strColWidth) != null)
                {
                    colWidth = strColWidth.Split(new char[] { ',' });
                    if (colWidth.Count() != 0)
                    {
                        if (names.Count == 0)
                        {
                            for (i = 0; i < colHeader.Count(); i++)
                            {
                                processListView.Columns.Add(colHeader[i].ToString().ToString().Trim(),
                                    int.Parse(colWidth[i].ToString().Trim() == "" ? "0" : colWidth[i].ToString()));
                            }
                        }
                    }
                }
                else
                {
                    if (names.Count == 0)
                    {
                        for (i = 0; i < colHeader.Count(); i++)
                        {
                            processListView.Columns.Add(colHeader[i].ToString().ToString().Trim(),
                                                        (int)processListView.Width / colHeader.Count());
                        }
                    }
                }



                try
                {
                    //row counter for alternate row color
                    j = 1;
                    foreach (DataRow dr in listViewFillDT.Rows)
                    {
                        count = 1;
                        foreach (object rowItem in dr.ItemArray)
                        {
                            if (count == 1)
                            {
                                itemX = processListView.Items.Add(rowItem.ToString());
                                count++;
                                
                            }
                            else if (count == 2)
                            {
                                itemX.SubItems.Add(rowItem.ToString());
                            }                            
                        }


                         //start:alternate row color
                        if (j % 2 == 0)
                        {
                            itemX.BackColor = Color.FromArgb(232, 242, 251);
                        }
                        else
                        {
                            itemX.BackColor = Color.FromArgb(255, 255, 255);
                        }

                        j++;
                        
                        //end:alternate row color
                    }
                }
                catch
                {
                    //throw;
                }
                finally
                {
                    listViewFillDT.Dispose();
                }
                processListView.EndUpdate();
            }

            //ListView fill Overload function with row color enable/disable status
            /// <summary>
            /// Fill listview with alternate row color
            /// </summary>
            /// <param name="processListView"></param>
            /// <param name="listViewFillDT"></param>
            /// <param name="strColHeader"></param>
            /// <param name="strColWidth"></param>
            /// <param name="IsColor"></param>
            public void fillListView(System.Windows.Forms.ListView processListView, DataTable listViewFillDT, string strColHeader, string strColWidth, bool IsColor = false)
            {
                string[] colHeader = null;
                string[] colWidth = null;
                int i, j, count;
                ListViewItem itemX = null;
                processListView.Refresh();
                processListView.View = View.Details;
                processListView.BeginUpdate();
                processListView.Items.Clear();
                if (listViewFillDT == null || listViewFillDT.Rows.Count <= 0)
                {
                    processListView.EndUpdate();
                    return;
                }


                if (!string.IsNullOrEmpty(strColHeader))
                {
                    colHeader = strColHeader.Split(new char[] { ',' });
                }
                else
                {
                    colHeader = (from DataColumn x in listViewFillDT.Columns
                                 select x.ColumnName).ToArray();
                }
                var names = (from col in processListView.Columns.Cast<ColumnHeader>()
                             orderby col.DisplayIndex
                             select col.Text).ToList();
                if ((strColWidth == "" ? strColWidth = null : strColWidth) != null)
                {
                    colWidth = strColWidth.Split(new char[] { ',' });
                    if (colWidth.Count() != 0)
                    {
                        if (names.Count == 0)
                        {
                            for (i = 0; i < colHeader.Count(); i++)
                            {
                                processListView.Columns.Add(colHeader[i].ToString().ToString().Trim(),
                                    int.Parse(colWidth[i].ToString().Trim() == "" ? "0" : colWidth[i].ToString()));
                            }
                        }
                    }
                }
                else
                {
                    if (names.Count == 0)
                    {
                        for (i = 0; i < colHeader.Count(); i++)
                        {
                            processListView.Columns.Add(colHeader[i].ToString().ToString().Trim(),
                                                        (int)processListView.Width / colHeader.Count());
                        }
                    }
                }



                try
                {
                    //row counter for alternate row color
                    j = 1;
                    foreach (DataRow dr in listViewFillDT.Rows)
                    {
                        count = 1;
                        foreach (object rowItem in dr.ItemArray)
                        {
                            if (count == 1)
                            {
                                itemX = processListView.Items.Add(rowItem.ToString());
                                count++;

                            }
                            else if (count == 2)
                            {
                                itemX.SubItems.Add(rowItem.ToString());
                            }
                        }

                        //start:alternate row color
                        if (IsColor)
                        {
                            if (j % 2 == 0)
                            {
                                itemX.BackColor = Color.FromArgb(232, 242, 251);
                            }
                            else
                            {
                                itemX.BackColor = Color.FromArgb(255, 255, 255);
                            }

                            j++;
                        }
                        //end:alternate row color
                    }
                }
                catch
                {
                    //throw;
                }
                finally
                {
                    listViewFillDT.Dispose();
                }
                processListView.EndUpdate();
            }

            /// <summary>
            /// ListView fill Overload function with row color of a specific row depends on condition
            /// </summary>
            /// <param name="processListView"></param>
            /// <param name="listViewFillDT"></param>
            /// <param name="strColHeader"></param>
            /// <param name="strColWidth"></param>
            /// <param name="colNum"></param>
            /// <param name="condition"></param>
            public void fillListView(System.Windows.Forms.ListView processListView, DataTable listViewFillDT, string strColHeader, string strColWidth, int colNum,string condition)
            {
                string[] colHeader = null;
                string[] colWidth = null;
                int i, j, count;
                ListViewItem itemX = null;
                processListView.Refresh();
                processListView.View = View.Details;
                processListView.BeginUpdate();
                processListView.Items.Clear();
                if (listViewFillDT == null || listViewFillDT.Rows.Count <= 0)
                {
                    processListView.EndUpdate();
                    return;
                }


                if (!string.IsNullOrEmpty(strColHeader))
                {
                    colHeader = strColHeader.Split(new char[] { ',' });
                }
                else
                {
                    colHeader = (from DataColumn x in listViewFillDT.Columns
                                 select x.ColumnName).ToArray();
                }
                var names = (from col in processListView.Columns.Cast<ColumnHeader>()
                             orderby col.DisplayIndex
                             select col.Text).ToList();
                if ((strColWidth == "" ? strColWidth = null : strColWidth) != null)
                {
                    colWidth = strColWidth.Split(new char[] { ',' });
                    if (colWidth.Count() != 0)
                    {
                        if (names.Count == 0)
                        {
                            for (i = 0; i < colHeader.Count(); i++)
                            {
                                processListView.Columns.Add(colHeader[i].ToString().ToString().Trim(),
                                    int.Parse(colWidth[i].ToString().Trim() == "" ? "0" : colWidth[i].ToString()));
                            }
                        }
                    }
                }
                else
                {
                    if (names.Count == 0)
                    {
                        for (i = 0; i < colHeader.Count(); i++)
                        {
                            processListView.Columns.Add(colHeader[i].ToString().ToString().Trim(),
                                                        (int)processListView.Width / colHeader.Count());
                        }
                    }
                }



                try
                {
                    foreach (DataRow dr in listViewFillDT.Rows)
                    {
                        count = 1;
                        foreach (object rowItem in dr.ItemArray)
                        {
                            if (count == 1)
                            {
                                itemX = processListView.Items.Add(rowItem.ToString());
                                count++;

                            }
                            else if (count == 2)
                            {
                                itemX.SubItems.Add(rowItem.ToString());
                            }
                        }

                        //start:alternate row color
                        if (colNum == 0)
                        {
                            if (itemX.Text.Trim() == condition.Trim())
                            {
                                itemX.BackColor = Color.FromArgb(87, 130, 176);
                                itemX.ForeColor = Color.White;
                                itemX.Font = new Font("Tahoma", 9F, FontStyle.Bold);
                            }
                        }
                        else
                        {
                            if (itemX.SubItems[colNum].Text.Trim() == condition.Trim())
                            {
                                itemX.BackColor = Color.FromArgb(87, 130, 176);
                                itemX.ForeColor = Color.White;
                                itemX.Font = new Font("Tahoma", 9F, FontStyle.Bold);
                                itemX.Checked = true;
                            }
                        }                          
                        
                        //end:alternate row color
                    }
                }
                catch
                {
                    //throw;
                }
                finally
                {
                    listViewFillDT.Dispose();
                }
                processListView.EndUpdate();
            }

            //ListView fill Overload function with row color enable/disable status,and change column style
            public void fillListView(System.Windows.Forms.ListView processListView, DataTable listViewFillDT, string strColHeader, string strColWidth, string columnToStyle)
            {
                string[] colHeader = null;
                string[] colWidth = null;
                int i, j, count;
                ListViewItem itemX = null;
                processListView.Refresh();
                processListView.View = View.Details;
                processListView.BeginUpdate();
                processListView.Items.Clear();
                if (listViewFillDT == null || listViewFillDT.Rows.Count <= 0)
                {
                    processListView.EndUpdate();
                    return;
                }


                if (!string.IsNullOrEmpty(strColHeader))
                {
                    colHeader = strColHeader.Split(new char[] { ',' });
                }
                else
                {
                    colHeader = (from DataColumn x in listViewFillDT.Columns
                                 select x.ColumnName).ToArray();
                }
                var names = (from col in processListView.Columns.Cast<ColumnHeader>()
                             orderby col.DisplayIndex
                             select col.Text).ToList();
                if ((strColWidth == "" ? strColWidth = null : strColWidth) != null)
                {
                    colWidth = strColWidth.Split(new char[] { ',' });
                    if (colWidth.Count() != 0)
                    {
                        if (names.Count == 0)
                        {
                            for (i = 0; i < colHeader.Count(); i++)
                            {
                                processListView.Columns.Add(colHeader[i].ToString().ToString().Trim(),
                                    int.Parse(colWidth[i].ToString().Trim() == "" ? "0" : colWidth[i].ToString()));
                            }
                        }
                    }
                }
                else
                {
                    if (names.Count == 0)
                    {
                        for (i = 0; i < colHeader.Count(); i++)
                        {
                            processListView.Columns.Add(colHeader[i].ToString().ToString().Trim(),
                                                        (int)processListView.Width / colHeader.Count());
                        }
                    }
                }



                try
                {
                    //row counter for alternate row color
                    j = 1;
                    foreach (DataRow dr in listViewFillDT.Rows)
                    {
                        count = 1;
                        foreach (object rowItem in dr.ItemArray)
                        {
                            if (count == 1)
                            {
                                itemX = processListView.Items.Add(rowItem.ToString());
                                count++;

                            }
                            else if (count == 2)
                            {
                                itemX.SubItems.Add(rowItem.ToString());
                            }
                        }                        

                        //Start: Style the columns
                        // Set UseItemStyleForSubItems property to false to change  
                        // look of subitems.
                        if (!string.IsNullOrEmpty(columnToStyle))
                        {
                            itemX.UseItemStyleForSubItems = false;
                            int col;

                            if (columnToStyle.IndexOf(',') < 0)
                            {
                                col = Convert.ToInt32(columnToStyle);
                                itemX.SubItems[col].ForeColor = Color.Blue;
                                itemX.SubItems[col].Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                            }
                            else
                            {
                                string[] colToStyle = columnToStyle.Split(new char[] { ',' });

                                for (i = 0; i < colToStyle.Count(); i++)
                                {
                                    col = Convert.ToInt32(colToStyle[i]);

                                    itemX.SubItems[col].ForeColor = Color.Blue;
                                    itemX.SubItems[col].Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                                }
                            }
                        }

                        //Start: Style the columns
                        
                    }
                }
                catch
                {
                    //throw;
                }
                finally
                {
                    listViewFillDT.Dispose();
                }
                processListView.EndUpdate();
            }
            // end of Listview fill module        

            //Start:ListView Grouping

            private int lastSortColumn = 0;
            private SortOrder lastSortOrder;
            public void BuildGroups(int column, ListView listView, bool isSort)
            {
                if (isSort)
                {
                    lastSortOrder = SortOrder.Descending;
                }
                else
                {
                    lastSortOrder = SortOrder.Ascending;
                }


                listView.Groups.Clear();

                // Getting the Count forces any internal cache of the ListView to be flushed. Without
                // this, iterating over the Items will not work correctly if the ListView handle
                // has not yet been created.
                int dummy = listView.Items.Count;

                // Separate the list view items into groups, using the group key as the descrimanent
                Dictionary<String, List<ListViewItem>> map = new Dictionary<String, List<ListViewItem>>();
                foreach (ListViewItem lvi in listView.Items)
                {
                    String key = lvi.SubItems[column].Text;
                    //if (column == 0 && key.Length > 0)
                    //    key = key.Substring(0, 1);
                    if (!map.ContainsKey(key))
                        map[key] = new List<ListViewItem>();
                    map[key].Add(lvi);
                }

                // Make a list of the required groups
                List<ListViewGroup> groups = new List<ListViewGroup>();
                foreach (String key in map.Keys)
                {
                    groups.Add(new ListViewGroup(key));
                }

                // Sort the groups
                groups.Sort(new ListViewGroupComparer(this.lastSortOrder));

                // Put each group into the list view, and give each group its member items.
                // The order of statements is important here:
                // - the header must be calculate before the group is added to the list view,
                //   otherwise changing the header causes a nasty redraw (even in the middle of a BeginUpdate...EndUpdate pair)
                // - the group must be added before it is given items, otherwise an exception is thrown (is this documented?)
                ColumnComparer itemSorter = new ColumnComparer(column, this.lastSortOrder);
                foreach (ListViewGroup group in groups)
                {
                    listView.Groups.Add(group);
                    map[group.Header].Sort(itemSorter);
                    group.Items.AddRange(map[group.Header].ToArray());
                }
            }

            internal class ListViewGroupComparer : IComparer<ListViewGroup>
            {
                public ListViewGroupComparer(SortOrder order)
                {
                    this.sortOrder = order;
                }

                public int Compare(ListViewGroup x, ListViewGroup y)
                {
                    int result = String.Compare(x.Header, y.Header, true);

                    if (this.sortOrder == SortOrder.Descending)
                        result = 0 - result;

                    return result;
                }

                private SortOrder sortOrder;
            }

            internal class ColumnComparer : IComparer, IComparer<ListViewItem>
            {
                private int column;
                private SortOrder sortOrder;

                public ColumnComparer(int col, SortOrder order)
                {
                    this.column = col;
                    this.sortOrder = order;
                }

                public int Compare(object x, object y)
                {
                    return this.Compare((ListViewItem)x, (ListViewItem)y);
                }

                public int Compare(ListViewItem x, ListViewItem y)
                {
                    int result = String.Compare(x.SubItems[this.column].Text, y.SubItems[this.column].Text, true);

                    if (this.sortOrder == SortOrder.Descending)
                        result = 0 - result;

                    return result;

                }
            }

            //End:Listview Grouping

            //Start: Sort listviews and show the up and down arrow
            public void ListViewSort(ListView listView, int Column)
            {
                ItemComparer sorter = listView.ListViewItemSorter as ItemComparer;
                if (sorter == null)
                {
                    sorter = new ItemComparer(Column);
                    sorter.Order = SortOrder.Ascending;
                    listView.ListViewItemSorter = sorter;
                }
                // if clicked column is already the column that is being sorted
                if (Column == sorter.Column)
                {
                    // Reverse the current sort direction
                    if (sorter.Order == SortOrder.Ascending)
                        sorter.Order = SortOrder.Descending;
                    else
                        sorter.Order = SortOrder.Ascending;
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    sorter.Column = Column;
                    sorter.Order = SortOrder.Ascending;
                }
                ListViewExtensions.SetSortIcon(listView, Column, sorter.Order);
                listView.Sort();
            }
            //End: Sort listviews and show the up and down arrow


            /// <summary>
            /// fil the PictureBox with specified image
            /// </summary>
            /// <param name="picBox"></param>
            /// <param name="imageObj"></param>
            public void fillPictureBox(object imageObj, PictureBox picBox)
            {
                MemoryStream stmBLOBData = null;
                try
                {
                    if (imageObj != null)
                    {
                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])(imageObj);
                        stmBLOBData = new MemoryStream(byteBLOBData);
                        picBox.Image = Image.FromStream(stmBLOBData);
                        //return stmBLOBData;
                    }
                    //return null;
                }
                catch
                {
                    picBox.Image = null;
                    //return null;
                }
            }
            //end of PictureBox fill module

            //start:Get the First day and last day

            private void GetFirstAndLastDayOfMonth()
            {
                //get the first and last day of month
                DateTime Today = DateTime.Now;
                DateTime FirstDate = new DateTime(Today.Year, Today.Month, 1);
                DateTime LastDate = FirstDate.AddMonths(1).AddDays(-1);
            }

            //end:Get the First day and last day


            /// <summary>
            /// Converts the given month int to month name
            /// </summary>
            /// <param name="month">month in</param>
            /// <param name="abbrev">return abbreviated or not</param>
            /// <returns>Short or long month name</returns>

            public string GetMonthName(int month)
            {
                DateTime date = new DateTime(1900, month, 1);
                return date.ToString("MMMM");
            }

            public void FillMonth(ComboBox cmb)
            {
                try
                {
                    if (cmb.DataSource != null)
                    {
                        cmb.DataSource = null;
                    }
                    var months = DateTimeFormatInfo.InvariantInfo.MonthNames;
                    //filter the white space from list
                    var monthsDB = from m in months where m != "" select m;
                    cmb.DataSource = monthsDB.ToList();
                    cmb.Text = DateTime.Now.ToString("MMMM");
                }
                catch
                {
                    cmb.DataSource = null;
                }
            }

            public string GetAppPath()
            {
                string path;
                path = Path.GetDirectoryName(Application.ExecutablePath); ;
                if (!string.IsNullOrEmpty(path))
                    return path;

                return null;
            }

        }    
}
