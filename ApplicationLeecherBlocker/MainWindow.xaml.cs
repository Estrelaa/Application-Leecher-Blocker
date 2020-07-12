using ApplicationLeacherBlocker.Processes;
using ApplicationLeecherBlocker.Json_Parser;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace ApplicationLeacherBlocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Stopwatch stopWatch = new Stopwatch();
        readonly DispatcherTimer timer = new DispatcherTimer();
        int TimeToRunHours;
        int TimeToRunMinutes;
        int TimeToRunInSeconds;
        bool CanCloseProgram = true;
        readonly ProcessesModel ListOfBlockedProcesses;
        public MainWindow()
        {
            InitializeComponent();
            Logging.LogToLoggingTextBoxInUI("Application started");
            ListOfBlockedProcesses = new JsonHandler().LoadBlockList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Logging.LogToLoggingTextBoxInUI("Starting Blocker...");

            try
            {
                TimeToRunHours = int.Parse(UserInputHours.Text);
                TimeToRunMinutes = int.Parse(UserInputMinutes.Text);
                Logging.LogToLoggingTextBoxInUI($"Parsed {TimeToRunHours} hour(s) {TimeToRunMinutes} minutes");
            }
            catch
            {
                Logging.LogToLoggingTextBoxInUI("Failed to parse input, Defaulting to 1 minutes");
                TimeToRunHours = 1;
            }

            try
            {
                StartBlocker();
                Logging.LogToLoggingTextBoxInUI("Started sucessfully!");
            }
            catch (Exception ex)
            {
                Logging.LogToLoggingTextBoxInUI($"Failed to start Blocker: {ex.Message}");
            }
        }

        private void StartBlocker()
        {
            StartBlockerButton.IsEnabled = false;
            CanCloseProgram = false;
            var TimeBlockEnds = DateTime.Now.AddHours(TimeToRunHours).AddMinutes(TimeToRunMinutes);
            TimeToRunInSeconds = (TimeToRunHours * 3600) + (TimeToRunMinutes * 60);
            TimeLeftLabel.Content = $"Block ends at {TimeBlockEnds.Hour}:{TimeBlockEnds.Minute}";
            StartTimer();
        }

        private void StartTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += DispatcherTimer_Tick;
            timer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!stopWatch.IsRunning)
            {
                stopWatch.Restart();
            }
            else
            {
                new ProcessHandler().ScanAndKillBlockedProcesses(ListOfBlockedProcesses);

                if (stopWatch.Elapsed.TotalSeconds > TimeToRunInSeconds)
                {
                    StopTimerAndStopWatch();
                }
            }
        }

        private void StopTimerAndStopWatch()
        {
            stopWatch.Stop();
            timer.Stop();

            ((MainWindow)Application.Current.MainWindow).StartBlockerButton.IsEnabled = true;
            CanCloseProgram = true;
            TimeLeftLabel.Content = $"Blocker ended at {DateTime.Now}";
            Logging.LogToLoggingTextBoxInUI("Blocker disabled");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CanCloseProgram == false)
            {
                Logging.LogToLoggingTextBoxInUI("You cannot close the program while the timer is running");
                e.Cancel = true;
            }
        }
    }
}
