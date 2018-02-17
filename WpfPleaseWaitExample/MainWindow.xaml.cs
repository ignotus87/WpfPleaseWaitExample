using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace BusyIndicatorExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainWindowViewModel;

        public MainWindow()
        {
            DataContext = _mainWindowViewModel = new MainWindowViewModel();

            InitializeComponent();
        }

        private void FillListBox(object sender, RoutedEventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();

            // The "Work"
            backgroundWorker.DoWork += (o, eargs) =>
            {
                var itemsList = new List<string>();

                for (int i = 0; i < 100; ++i)
                {
                    itemsList.Add($"Item {i}");

                    Thread.Sleep(50);
                }

                Dispatcher.Invoke((Action)(() => 
                {
                    _mainWindowViewModel.ItemsList = itemsList;
                    
                }));
            };

            // What to do when work is done
            backgroundWorker.RunWorkerCompleted += (o, eargs) => 
            {
                _busyIndicator.IsBusy = false;
            };

            // Set indicator as busy
            _busyIndicator.IsBusy = true;

            // Start worker
            backgroundWorker.RunWorkerAsync();
        }
    }
}
