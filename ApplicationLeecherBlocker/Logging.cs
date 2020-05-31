using System;
using System.Windows;

namespace ApplicationLeacherBlocker
{
    class Logging
    {
        public static void LogToLoggingTextBoxInUI(string Message)
        {
            ((MainWindow)Application.Current.MainWindow).LoggerTextBox.Text += $"[{DateTime.Now}] {Message}\r\n";
            ((MainWindow)Application.Current.MainWindow).LoggerTextBox.ScrollToEnd();
        }
    }
}
