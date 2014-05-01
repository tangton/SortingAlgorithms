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

namespace SortingAlgorithms
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

        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            btnRun.IsEnabled = false;

            List<int> randomIntList = new List<int>();

            Random random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                randomIntList.Add(random.Next(1000));
            }

            lblListGenerated.Content = "Generated list: " + String.Join(", ", randomIntList.ToArray());

            Task<long> taskSelectionSort = RunSort(SelectionSort.Sort, randomIntList, pbSelectionSort, lblResultSelectionSort);
            Task<long> taskBubbleSort = RunSort(BubbleSort.Sort, randomIntList, pbBubbleSort, lblResultBubbleSort);
            Task<long> taskInsertionSort = RunSort(InsertionSort.Sort, randomIntList, pbInsertionSort, lblResultInsertionSort);
            Task<long> taskBinaryTreeSort = RunSort(BinaryTreeSort.Sort, randomIntList, pbBinaryTreeSort, lblResultBinaryTreeSort);

            await taskSelectionSort;
            await taskBubbleSort;
            await taskInsertionSort;
            await taskBinaryTreeSort;

            btnRun.IsEnabled = true;
        }

        private async Task<long> RunSort(Func<List<int>, List<int>> sortFunction, List<int> listToSort, ProgressBar progressBar, Label labelResult)
        {
            progressBar.IsIndeterminate = true;
            labelResult.Content = "Sorting...";

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Task<List<int>> task = Task.Factory.StartNew(() => sortFunction(listToSort));

            bool failed = false;
            string failMessage = string.Empty;

            try
            {
                await task;
            }
            catch (Exception ex)
            {
                failed = true;
                failMessage = ex.Message;
            }

            stopWatch.Stop();

            progressBar.IsIndeterminate = false;
            progressBar.Value = 100;

            if (!failed)
            {
                labelResult.Content = "Done. Time taken: " + stopWatch.Elapsed.ToString();
            }
            else
            {
                labelResult.Content = "Sort failed. Message: " + failMessage;
            }

            return stopWatch.ElapsedMilliseconds;
        }
    }
}
