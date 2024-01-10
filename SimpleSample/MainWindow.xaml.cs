using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.Controls.Notification;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SimpleSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int startValue = 10;       
        SfBusyIndicator busyIndicator;

        public MainWindow()
        {
            InitializeComponent();
            //Adding busy indicator control
            busyIndicator = new SfBusyIndicator();
            busyIndicator.HorizontalAlignment = HorizontalAlignment.Right;                  
            busyIndicator.IsBusy = false;
            busyIndicator.Foreground = new SolidColorBrush(Colors.Turquoise);
            busyIndicator.AnimationType = AnimationTypes.Cupertino;
            grid.Children.Add(busyIndicator);
        }
       
        private async void chart_PanChanged(object sender, PanChangedEventArgs e)
        {           
            var position = xAxis.ZoomPosition - xAxis.ZoomFactor;
            
            if (e.Axis.Equals(xAxis) &&  position>=0)
            {
                busyIndicator.IsBusy = true;
                await Task.Delay(2000);
                busyIndicator.IsBusy = false;

                // Update the data based on your requirement 
                for (int i = 0; i < 4; i++)
                {   
                    viewModel.Data.Add(new Model(startValue, new Random().Next(10, 40)));
                    startValue++;                 
                }
                xAxis.ZoomPosition = 1;
            }            
        }
    }
}
