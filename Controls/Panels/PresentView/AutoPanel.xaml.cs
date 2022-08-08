using Appear.Core;
using Appear.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Appear.Controls.Panels.PresentView
{
    /// <summary>
    /// Interaction logic for AutoPanel.xaml
    /// </summary>
    public partial class AutoPanel : ObservableControl
    {        
        private string timeValue = "8";

        private Timer timer;
        private string time { get; set; }
        public string Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged(); }
        }

        private bool isPlaying { get; set; } = false;
        public bool IsPlaying
        {
            get { return isPlaying; }
            set { isPlaying = value; OnPropertyChanged(); }
        }

        public AutoPanel()
        {
            Time = timeValue;

            timer = new Timer();
            timer.Tick += new EventHandler(onTimerTick);
            timer.Interval = 1000;

            InitializeComponent();

        }

        public static readonly RoutedEvent TimerTickEvent =
            EventManager.RegisterRoutedEvent("IconButtonClicked", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(AutoPanel));

        public event RoutedEventHandler TimerTick
        {
            add { AddHandler(TimerTickEvent, value); }
            remove { RemoveHandler(TimerTickEvent, value); }
        }

        private void onTimerTick(object sender, EventArgs e)
        {
            int value = Int32.Parse(Time);
            value--;

            if(value <= 0)
            {
                value = Int32.Parse(timeValue);
                RaiseEvent(new TimerTickEventArgs(TimerTickEvent));
            }

            Time = value.ToString();
        }

        public void Timer(bool start)
        {
            if (start)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
                IsPlaying = false;
                Time = timeValue;
            }
        }

        private void OnTimeBoxTextChanged(object sender, RoutedEventArgs e)
        {
            string value = ((System.Windows.Controls.TextBox)sender).Text;

            bool canConvert = long.TryParse(value, out _);
            if (canConvert == true)
            {
                timeValue = value;

                if (!timer.Enabled)
                {
                    Time = value;
                }
            }
        }
    }
}
