using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTree.Data.ShellElements.Pack1
{
    internal class Win32
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0; // Large icon
        public const uint SHGFI_SMALLICON = 0x1; // Small icon

        public Win32()
        {
        }

        public virtual IntPtr ShellGetFileInfoWrap(string pszPath, uint dwFileAttributes, ref ShellFileInfo psfi, uint cbSizeFileInfo, uint uFlags)
        {
            return SHGetFileInfo(pszPath, dwFileAttributes, ref psfi, cbSizeFileInfo, uFlags);
        }

        public virtual int DestroyIconWrap(IntPtr hIcon)
        {
            return DestroyIcon(hIcon);
        }

        public virtual int ExtractIconExWrap(string libName, int iconIndex, IntPtr[] largeIcon, IntPtr[] smallIcon, uint nIcons)
        {
            return ExtractIconEx(libName, iconIndex, largeIcon, smallIcon, nIcons);
        }



        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref ShellFileInfo psfi, uint cbSizeFileInfo, uint uFlags);

        [DllImport("User32.dll")]
        private static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("Shell32.dll")]
        private extern static int ExtractIconEx(string libName, int iconIndex, IntPtr[] largeIcon, IntPtr[] smallIcon, uint nIcons);
    }
}

