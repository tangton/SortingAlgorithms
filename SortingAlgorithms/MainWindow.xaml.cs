using SortingAlgorithmsBusinessAction;
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
using System.Diagnostics;
using System.Collections;
using System.Threading;

namespace SortingAlgorithms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _collectionListSize = 5000;
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

            List<int> randomIntList = new List<int>();

            Random random = new Random();
            for (int i = 0; i < _collectionListSize; i++)
            {
                randomIntList.Add(random.Next(1000));
            }

            lblListGenerated.Content = "Generated list: " + String.Join(", ", randomIntList.ToArray());

            List<Task> taskList = new List<Task>();

            Task taskSelectionSort = PrepareAndRunSort(SelectionSort.Sort, randomIntList, pbSelectionSort, lblResultSelectionSort, lblResultSelectionSortList, _tokenSource.Token);
            Task taskBubbleSort = PrepareAndRunSort(BubbleSort.Sort, randomIntList, pbBubbleSort, lblResultBubbleSort, lblResultBubbleSortList, _tokenSource.Token);
            Task taskInsertionSort = PrepareAndRunSort(InsertionSort.Sort, randomIntList, pbInsertionSort, lblResultInsertionSort, lblResultInsertionSortList, _tokenSource.Token);
            Task taskBinarySearchTree = PrepareAndRunSort(BinarySearchTree.Sort, randomIntList, pbBinarySearchTree, lblResultBinarySearchTree, lblResultBinarySearchTreeList, _tokenSource.Token);

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
            Progress<int> progress = new Progress<int>(value => progressBar.Value = value);
            Progress<bool> startingSort = new Progress<bool>(value => labelResult.Content = "Sorting...");

            labelResult.Content = "Pending...";
            labelResultSortedList.Content = string.Empty;
            progressBar.Value = 0;
            progressBar.Maximum = _collectionListSize;

            Task<Tuple<TimeSpan, List<int>>> task = Task.Factory.StartNew(() => RunSort(sortFunction, listToSort, progress, startingSort, cancellationToken), cancellationToken);

            bool failed = false;
            bool cancelled = false;
            string message = string.Empty;

            TimeSpan durationOfSort = new TimeSpan();

            try
            {
                await task;

                durationOfSort = task.Result.Item1;
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
                progressBar.Value = _collectionListSize;
                labelResult.Content = "Done. Time taken: " + durationOfSort.ToString();
                labelResultSortedList.Content = String.Join(", ", task.Result.Item2.ToArray());
            }
            else
            {
                labelResult.Content = "Sort failed. Message: " + message;
            }
        }

        private Tuple<TimeSpan, List<int>> RunSort(Func<List<int>, CancellationToken, IProgress<int>, List<int>> sortFunction, List<int> listToSort, IProgress<int> progress, IProgress<bool> startingSort, CancellationToken cancellationToken)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            startingSort.Report(true);
            List<int> sortedList = sortFunction(listToSort, cancellationToken, progress);

            stopWatch.Stop();

            return new Tuple<TimeSpan, List<int>>(stopWatch.Elapsed, sortedList);
        }
    }
}
