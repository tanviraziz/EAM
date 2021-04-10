using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StoreManagement.UTILITY
{
    public static class StatusForm
    {
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int HWND_TOPMOST = -1;
        private const int HWND_BOTTOM = 1;
        private const int HWND_NOTOPMOST = -2;
        private const int HWND_TOP = 0;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_NOOWNERZORDER = 0x0200;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
             int hWnd,           // window handle
             int hWndInsertAfter,    // placement-order handle
             int X,          // horizontal position
             int Y,          // vertical position
             int cx,         // width
             int cy,         // height
             uint uFlags);       // window positioning flags

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        /// <summary>
        /// Make a form like Task Manager
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="form_left"></param>
        /// <param name="form_top"></param>
        /// <param name="form_width"></param>
        /// <param name="form_hight"></param>
        public static void ShowInactiveTopmost(Form frm, int form_left, int form_top, int form_width, int form_hight)
        {
            ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(frm.Handle.ToInt32(), HWND_TOP,
                         form_left, form_top, form_width,
                         form_hight, SWP_NOACTIVATE);
        } 
    }
}
