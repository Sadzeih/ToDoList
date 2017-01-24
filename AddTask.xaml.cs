using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddTask : Page
    {
        public AddTask()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.IsPaneOpen = !Menu.IsPaneOpen;
        }

        private void HomeMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = new DateTime(TaskDate.Date.DateTime.Year, TaskDate.Date.DateTime.Month, TaskDate.Date.DateTime.Day, TaskTime.Time.Hours, TaskTime.Time.Minutes, TaskTime.Time.Seconds);
            Task task = new ToDoList.Task(TaskName.Text, TaskDescription.Text, date.ToLocalTime());
            TaskModel.add(task);
            Frame.Navigate(typeof(MainPage));
        }
    }
}
