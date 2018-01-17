using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArchiveHelper
{
    public class ToastMessage
    {
        private static void setting()
        {
            ToastNotification.ToastFont = new Font("微软雅黑", 12);
            ToastNotification.DefaultToastPosition = eToastPosition.MiddleCenter;
            ToastNotification.DefaultToastGlowColor = eToastGlowColor.None;
            ToastNotification.ToastBackColor = Color.FromArgb(252, 92, 102);
            ToastNotification.ToastForeColor = Color.Black;
            ToastNotification.DefaultTimeoutInterval = 1500;
        }

        /// <summary>
        /// 使用默认配置 显示一个toast提醒
        /// </summary>
        /// <param name="control">要显示的控件</param>
        /// <param name="msg">需要显示的消息</param>
        public static void Show(Control control, string msg)
        {
            setting();
            ToastNotification.Show(control, msg);
        }
    }
}
