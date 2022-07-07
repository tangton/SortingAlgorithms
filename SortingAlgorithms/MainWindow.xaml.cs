using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using SortingAlgorithms.Library;
using SortingAlgorithms.Library.Services;

namespace SortingAlgorithms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int ListSize = 20000;
        private IRandomListGeneratorService _randomListGeneratorService = new RandomListGeneratorService();
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _tokenSource.Cancel();

            btnCancel.Visibility = Visibility.Collapsed;
            btnRun.Visibility = Visibility.Visible;
            btnRun.IsEnabled = true;
        }

        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            _tokenSource = new CancellationTokenSource();

            btnCancel.Visibility = Visibility.Visible;
            btnRun.Visibility = Visibility.Collapsed;
            btnRun.IsEnabled = false;

            var randomIntList = _randomListGeneratorService.GenerateRandomList(ListSize);

            lblListGenerated.Content = "Generated list: " + String.Join(", ", randomIntList);

            var taskList = new List<Task>();

            var taskSelectionSort = ucSelectionSortControl.Run(new SelectionSortAlgorithm(), randomIntList, _tokenSource.Token);
            var taskBubbleSort = ucBubbleSortControl.Run(new BubbleSortAlgorithm(), randomIntList, _tokenSource.Token);
            var taskInsertionSort = ucInsertionSortControl.Run(new InsertionSortAlgorithm(), randomIntList, _tokenSource.Token);
            var taskBinarySearchTree = ucBinarySearchTreeControl.Run(new BinarySearchTreeAlgorithm(), randomIntList, _tokenSource.Token);

            taskList.Add(taskSelectionSort);
            taskList.Add(taskBubbleSort);
            taskList.Add(taskInsertionSort);
            taskList.Add(taskBinarySearchTree);

            await Task.WhenAll(taskList);

            btnCancel.Visibility = Visibility.Collapsed;
            btnRun.Visibility = Visibility.Visible;
            btnRun.IsEnabled = true;
        }
    }
}
