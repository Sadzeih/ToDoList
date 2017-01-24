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
    public sealed partial class EditTask : Page
    {
        Task _task;

        public EditTask()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _task = e.Parameter as Task;
            DataContext = _task;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.IsPaneOpen = !Menu.IsPaneOpen;
        }

        private void HomeMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void AddTaskMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddTask));
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = new DateTime(TaskDate.Date.DateTime.Year, TaskDate.Date.DateTime.Month, TaskDate.Date.DateTime.Day, TaskTime.Time.Hours, TaskTime.Time.Minutes, TaskTime.Time.Seconds);
            _task.dueDate = date;
            _task.name = TaskName.Text;
            _task.content = TaskDescription.Text;
            TaskModel.update(_task);
            Frame.Navigate(typeof(MainPage));
        }
    }
}

namespace ToDoList.Converters
{

    public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTime date = (DateTime)value;
                return new DateTimeOffset(date);
            }
            catch (Exception ex)
            {
                return DateTimeOffset.MinValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTimeOffset dto = (DateTimeOffset)value;
                return dto.DateTime;
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }
    }
};
