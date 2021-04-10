using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagement.UTILITY
{
    class MultilineComboBox : ComboBox
    {
        public MultilineComboBox()
            : base()
        {
            // add event handlers
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.DrawItem += new DrawItemEventHandler(ComboBoxWrap_DrawItem);
            this.MeasureItem += new MeasureItemEventHandler(ComboBoxWrap_MeasureItem);
        }

        void ComboBoxWrap_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // set the height of the item, using MeasureString with the font and control width
            MultilineComboBox ddl = (MultilineComboBox)sender;
            string text = ddl.Items[e.Index].ToString();
            SizeF size = e.Graphics.MeasureString(text.ToString(), this.Font, ddl.Width);
            e.ItemHeight = (int)Math.Ceiling(size.Height) + 1;  // plus one for the border
            //e.ItemWidth = ddl.DropDownWidth;
        }

        void ComboBoxWrap_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            // draw a lighter blue selected BG colour, the dark blue default has poor contrast with black text on a dark blue background
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(Brushes.PowderBlue, e.Bounds);
            else
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);

            // get the text of the item
            MultilineComboBox ddl = (MultilineComboBox)sender;
            string text = ddl.Items[e.Index].ToString();

            // don't dispose the brush afterwards
            Brush b = Brushes.Black;
            e.Graphics.DrawString(text, this.Font, b, e.Bounds, StringFormat.GenericDefault);

            // draw a light grey border line to separate the items
            Pen p = new Pen(Brushes.Gainsboro, 1);
            e.Graphics.DrawLine(p, new Point(e.Bounds.Left, e.Bounds.Bottom - 1), new Point(e.Bounds.Right, e.Bounds.Bottom - 1));
            p.Dispose();

            e.DrawFocusRectangle();
        }
    }
}
