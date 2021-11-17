using Prism.Events;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDemo.ViewModel;

namespace WpfDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEventAggregator eventAggregator;

        public MainWindow()
        {
            InitializeComponent();

            eventAggregator = ContainerLocator.Container.Resolve<IEventAggregator>();

            eventAggregator.GetEvent<MyPubSubEvent>().Subscribe(DoWork);
        }

        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            //StudentViewModel model = new StudentViewModel();
            //model.LoadStudents();

            //StudentViewControl.DataContext = model;
        }

        private void DoWork(string info)
        {
            MessageBox.Show(info);
        }

        private void BTN_01_Click(object sender, RoutedEventArgs e)
        {
            eventAggregator.GetEvent<MyPubSubEvent>().Publish(DateTime.Now.ToString());
        }
    }
}
