using SortingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SortingAlgorithms.UserControls
{
    /// <summary>
    /// Interaction logic for SelectionSortControl.xaml
    /// </summary>
    public partial class SortControl : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(SortControl));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public SortControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public async Task Run(ISortingAlgorithm sortingAlgorithm, IList<int> listToSort, CancellationToken cancellationToken)
        {
            IProgress<int> progressBar;
            IProgress<bool> progressStatusLabel;

            progressBar = new Progress<int>(value => pbStatus.Value = value);
            progressStatusLabel = new Progress<bool>(value => lblStatusState.Content = "Sorting...");

            lblStatusState.Content = "Pending...";
            lblResultSortList.Content = string.Empty;
            pbStatus.Value = 0;
            pbStatus.Maximum = listToSort.Count;

            var task = Task.Factory.StartNew(() =>
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                progressStatusLabel.Report(true);
                var sortedList = sortingAlgorithm.Sort(listToSort, cancellationToken, progressBar);

                stopWatch.Stop();

                return new SortResult { Duration = stopWatch.Elapsed, SortedList = sortedList };
            });

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
                pbStatus.Value = 0;
                lblStatusState.Content = "Sort cancelled.";
            }
            else if (!failed)
            {
                pbStatus.Value = listToSort.Count;
                lblStatusState.Content = "Done. Time taken: " + durationOfSort;
                lblResultSortList.Content = String.Join(", ", task.Result.SortedList);
            }
            else
            {
                lblStatusState.Content = "Sort failed. Message: " + message;
            }
        }
    }
}
