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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = TaskModel.findAll();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.IsPaneOpen = !Menu.IsPaneOpen;
        }

        private void AddTaskMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddTask));
        }

        private void TaskCheckbox_Check(object sender, RoutedEventArgs e)
        {
            int id = (int)(((CheckBox)sender).Tag);
            Task task = TaskModel.findById(id);
            task.completed = (bool?)(((CheckBox)sender).IsChecked);
            TaskModel.update(task);
            task = TaskModel.findById(id);
        }

        private void TaskDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)(((Button)sender).Tag);
            TaskModel.removeById(id);
            DataContext = TaskModel.findAll();
        }

        private void Tasks_ItemClick(object sender, ItemClickEventArgs e)
        {
            Task task = (Task)e.ClickedItem;
            Frame.Navigate(typeof(EditTask), task);
        }

        private void FilterDone_Click(object sender, RoutedEventArgs e)
        {
            DataContext = TaskModel.findAllDone();
        }

        private void FilterNotDone_Click(object sender, RoutedEventArgs e)
        {
            DataContext = TaskModel.findAllNotDone();
        }

        private void FilterAll_Click(object sender, RoutedEventArgs e)
        {
            DataContext = TaskModel.findAll();
        }
    }
}
