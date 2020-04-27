using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.ShellElements.Pack1
{
    public class ShellIcon
    {
        private ShellFileInfo shellFileInfo;
        private Win32 win32;


        internal ShellIcon(Win32 win32 = null)
        {
            this.ShellFileInfo = new ShellFileInfo();
            this.Win32 = win32 ?? new Win32();
        }


        public Icon GetSmallIcon(string fileName)
        {
            this.Win32.ShellGetFileInfoWrap(fileName, 0, ref shellFileInfo, (uint)Marshal.SizeOf(ShellFileInfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);
            Icon icon = (Icon)Icon.FromHandle(ShellFileInfo.hIcon).Clone();
            this.Win32.DestroyIconWrap(ShellFileInfo.hIcon);
            return icon;
        }


        public Icon GetLargeIcon(string fileName)
        {
            this.Win32.ShellGetFileInfoWrap(fileName, 0, ref shellFileInfo, (uint)Marshal.SizeOf(ShellFileInfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);
            try
            {
                Icon icon = (Icon)Icon.FromHandle(ShellFileInfo.hIcon).Clone();
                this.Win32.DestroyIconWrap(ShellFileInfo.hIcon);
                return icon;
            }
            catch
            {
                // maybe a registry test necessary?
                return null;
            }
        }


        private ShellFileInfo ShellFileInfo { get => shellFileInfo; set => shellFileInfo = value; }


        private Win32 Win32 { get => win32; set => win32 = value; }
    }
}
