using SortingAlgorithmsBusinessAction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Threading;

namespace SortingAlgorithms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int CollectionListSize = 5000;
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

            var randomIntList = new List<int>();

            var random = new Random();
            for (var i = 0; i < CollectionListSize; i++)
            {
                randomIntList.Add(random.Next(1000));
            }

            lblListGenerated.Content = "Generated list: " + String.Join(", ", randomIntList.ToArray());

            var taskList = new List<Task>();

            var taskSelectionSort = PrepareAndRunSort(SelectionSort.Sort, randomIntList, pbSelectionSort, lblResultSelectionSort, lblResultSelectionSortList, _tokenSource.Token);
            var taskBubbleSort = PrepareAndRunSort(BubbleSort.Sort, randomIntList, pbBubbleSort, lblResultBubbleSort, lblResultBubbleSortList, _tokenSource.Token);
            var taskInsertionSort = PrepareAndRunSort(InsertionSort.Sort, randomIntList, pbInsertionSort, lblResultInsertionSort, lblResultInsertionSortList, _tokenSource.Token);
            var taskBinarySearchTree = PrepareAndRunSort(BinarySearchTree.Sort, randomIntList, pbBinarySearchTree, lblResultBinarySearchTree, lblResultBinarySearchTreeList, _tokenSource.Token);

            taskList.Add(taskSelectionSort);
            taskList.Add(taskBubbleSort);
            taskList.Add(taskInsertionSort);
            taskList.Add(taskBinarySearchTree);

            await Task.WhenAll(taskList);

            btnCancel.Visibility = Visibility.Collapsed;
            btnRun.Visibility = Visibility.Visible;
            btnRun.IsEnabled = true;
        }

        private async Task PrepareAndRunSort(Func<List<int>, CancellationToken, IProgress<int>, List<int>> sortFunction, List<int> listToSort, ProgressBar progressBar, Label labelResult, Label labelResultSortedList, CancellationToken cancellationToken)
        {
            var progress = new Progress<int>(value => progressBar.Value = value);
            var startingSort = new Progress<bool>(value => labelResult.Content = "Sorting...");

            labelResult.Content = "Pending...";
            labelResultSortedList.Content = string.Empty;
            progressBar.Value = 0;
            progressBar.Maximum = CollectionListSize;

            var task = Task.Factory.StartNew(() => RunSort(sortFunction, listToSort, progress, startingSort, cancellationToken), cancellationToken);

            var failed = false;
            var cancelled = false;
            var message = string.Empty;

            var durationOfSort = new TimeSpan();

            try
            {
                await task;

                durationOfSort = task.Result.Duration;
            }
            catch (OperationCanceledException)
            {
                cancelled = true;
            }
            catch (Exception ex)
            {
                failed = true;
                message = ex.Message;
            }

            if (cancelled)
            {
                progressBar.Value = 0;
                labelResult.Content = "Sort cancelled.";
            }
            else if (!failed)
            {
                progressBar.Value = CollectionListSize;
                labelResult.Content = "Done. Time taken: " + durationOfSort;
                labelResultSortedList.Content = String.Join(", ", task.Result.SortedList);
            }
            else
            {
                labelResult.Content = "Sort failed. Message: " + message;
            }
        }

        private static SortResult RunSort(Func<List<int>, CancellationToken, IProgress<int>, List<int>> sortFunction, List<int> listToSort, IProgress<int> progress, IProgress<bool> startingSort, CancellationToken cancellationToken)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            startingSort.Report(true);
            var sortedList = sortFunction(listToSort, cancellationToken, progress);

            stopWatch.Stop();

            return new SortResult { Duration = stopWatch.Elapsed, SortedList = sortedList };
        }
    }
}
