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
        CancellationTokenSource _tokenSource = new CancellationTokenSource();

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
            for (int i = 0; i < 10000; i++)
            {
                randomIntList.Add(random.Next(1000));
            }

            lblListGenerated.Content = "Generated list: " + String.Join(", ", randomIntList.ToArray());

            List<Task<long>> taskList = new List<Task<long>>();

            Task<long> taskSelectionSort = RunSort(SelectionSort.Sort, randomIntList, pbSelectionSort, lblResultSelectionSort, lblResultSelectionSortList, _tokenSource.Token);
            Task<long> taskBubbleSort = RunSort(BubbleSort.Sort, randomIntList, pbBubbleSort, lblResultBubbleSort, lblResultBubbleSortList, _tokenSource.Token);
            Task<long> taskInsertionSort = RunSort(InsertionSort.Sort, randomIntList, pbInsertionSort, lblResultInsertionSort, lblResultInsertionSortList, _tokenSource.Token);
            Task<long> taskBinaryTreeSort = RunSort(BinaryTreeSort.Sort, randomIntList, pbBinaryTreeSort, lblResultBinaryTreeSort, lblResultBinaryTreeSortList, _tokenSource.Token);

            taskList.Add(taskSelectionSort);
            taskList.Add(taskBubbleSort);
            taskList.Add(taskInsertionSort);
            taskList.Add(taskBinaryTreeSort);

            while (taskList.Count > 0)
            {
                Task<long> firstFinishedTask = await Task.WhenAny(taskList);
                taskList.Remove(firstFinishedTask);
                await firstFinishedTask;
            }

            btnCancel.Visibility = Visibility.Collapsed;
            btnRun.Visibility = Visibility.Visible;
            btnRun.IsEnabled = true;
        }

        private async Task<long> RunSort(Func<List<int>, CancellationToken, List<int>> sortFunction, List<int> listToSort, ProgressBar progressBar, Label labelResult, Label labelResultSortedList, CancellationToken cancellationToken)
        {
            progressBar.IsIndeterminate = true;
            labelResult.Content = "Sorting...";
            labelResultSortedList.Content = string.Empty;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Task<List<int>> task = Task.Factory.StartNew(() => sortFunction(listToSort, cancellationToken), cancellationToken);

            bool failed = false;
            bool cancelled = false;
            string message = string.Empty;

            try
            {
                await task;
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

            stopWatch.Stop();

            progressBar.IsIndeterminate = false;

            if (cancelled)
            {
                progressBar.Value = 0;
                labelResult.Content = "Sort cancelled.";
            }
            else if (!failed)
            {
                progressBar.Value = 100;
                labelResult.Content = "Done. Time taken: " + stopWatch.Elapsed.ToString();
                labelResultSortedList.Content = String.Join(", ", task.Result.ToArray());
            }
            else
            {
                labelResult.Content = "Sort failed. Message: " + message;
            }

            return stopWatch.ElapsedMilliseconds;
        }
    }
}
