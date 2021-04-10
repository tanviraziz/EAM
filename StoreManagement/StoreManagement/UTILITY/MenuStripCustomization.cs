using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.UTILITY
{
    class MenuStripCustomization : MenuStrip
    {
        public MenuStripCustomization()
        {
            this.Renderer = new MyRenderer();
        }
    }

    public class MyRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderMenuItemBackground(e);
                e.Item.BackColor = Color.FromArgb(83, 80, 80);
            }
            else
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                e.Graphics.FillRectangle(Brushes.Gray, rc);
                e.Graphics.DrawRectangle(Pens.SteelBlue, 1, 0, rc.Width - 2, rc.Height - 1);
                e.Item.BackColor = Color.FromArgb(128, 128, 128);
            }
        }
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            if (!e.Item.Selected)
            {
                e.Item.ForeColor = Color.FromArgb(212, 184, 184);
            }
            else
            {
                e.Item.ForeColor = Color.FromArgb(221, 201, 201);
            }
        }
    } 
}
