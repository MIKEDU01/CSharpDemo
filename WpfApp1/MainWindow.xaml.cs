using Emgu.CV;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Mat mat = new Mat(1024, 1024, Emgu.CV.CvEnum.DepthType.Cv8U, 3);
            CvInvoke.Circle(mat, new System.Drawing.Point(500, 500), 400, new Emgu.CV.Structure.MCvScalar(255), -1);
            CvInvoke.Imshow("mat", mat);
        }
    }
}
