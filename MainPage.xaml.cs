using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ToDoList
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = TaskModel.findAll();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.IsPaneOpen = !Menu.IsPaneOpen;
        }

        private void TaskCheckbox_Check(object sender, RoutedEventArgs e)
        {
            int id = (int)(((CheckBox)sender).Tag);
            Task task = TaskModel.findById(id);
            task.completed = !task.completed;
            TaskModel.update(task);
        }

        private void TaskDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)(((Button)sender).Tag);
            TaskModel.removeById(id);
            DataContext = TaskModel.findAll();
        }
    }
}
