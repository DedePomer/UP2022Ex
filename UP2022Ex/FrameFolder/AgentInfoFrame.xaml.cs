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

namespace UP2022Ex.FrameFolder
{

    public partial class AgentInfoFrame : Page
    {
        List<Agent> _StartFilter = ClassFolder.BD.data.Agent.ToList();
        List<Agent> _TemporraryFilter;
        int _UpAndDown =1;
        public AgentInfoFrame()
        {
            InitializeComponent();
            _TemporraryFilter = _StartFilter;
            LVAgent.ItemsSource = _StartFilter;
            CBSort.SelectedIndex = 0;
            CBFilt.SelectedIndex = 0;
        }

        public void Sort()
        {
            switch (CBSort.SelectedIndex)
            {
                case 0:
                    _TemporraryFilter.Sort((x, y) => x.Title.CompareTo(y.Title));
                    break;
                case 1:
                    _TemporraryFilter.Sort((x, y) => x.Sale.CompareTo(y.Sale));
                    break;
                case 2:
                    _TemporraryFilter.Sort((x, y) => x.Priority.CompareTo(y.Priority));
                    break;
            }
        }

        public void Filt()
        {

            switch (CBFilt.SelectedIndex)
            {
                case 0:
                    _TemporraryFilter = _StartFilter;
                    break;
                case 1:
                    _TemporraryFilter = _StartFilter.Where(x => x.AgentTypeID == 1).ToList();
                    break;
                case 2:
                    _TemporraryFilter = _StartFilter.Where(x => x.AgentTypeID == 2).ToList();
                    break;
                case 3:
                    _TemporraryFilter = _StartFilter.Where(x => x.AgentTypeID == 3).ToList();
                    break;
                case 4:
                    _TemporraryFilter = _StartFilter.Where(x => x.AgentTypeID == 4).ToList();
                    break;
                case 5:
                    _TemporraryFilter = _StartFilter.Where(x => x.AgentTypeID == 5).ToList();
                    break;
                case 6:
                    _TemporraryFilter = _StartFilter.Where(x => x.AgentTypeID == 6).ToList();
                    break;

            }
            string SearchStr = TBOXSearch.Text;
            if (!string.IsNullOrWhiteSpace(TBOXSearch.Text))
            {
                _TemporraryFilter = _StartFilter.Where(x => x.Title.Contains(SearchStr)|| x.Title.ToLower().Contains(SearchStr) || x.Email.Contains(SearchStr) || x.Email.ToLower().Contains(SearchStr) || x.Phone.Contains(SearchStr) || x.Phone.ToLower().Contains(SearchStr)).ToList();
            }
            if (_UpAndDown == 1)
            {
                _UpAndDown *= -1;
                Sort();
            }
            else
            {
                _UpAndDown *= -1;
                Sort();
                _TemporraryFilter.Reverse();
            }
            LVAgent.ItemsSource = _TemporraryFilter;
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
            LVAgent.Items.Refresh();
        }

        private void BUP_Click(object sender, RoutedEventArgs e)
        {
            if (_UpAndDown != 1)
            {
                _UpAndDown *= -1;
                _TemporraryFilter.Reverse();
            }
            LVAgent.Items.Refresh();
        }

        private void BDown_Click(object sender, RoutedEventArgs e)
        {
            if (_UpAndDown != -1)
            {
                _UpAndDown *= -1;
                Sort();
            }
            LVAgent.Items.Refresh();
        }

        private void CBFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filt();
            LVAgent.Items.Refresh();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.AddWindow NewWindow = new WindowFolder.AddWindow();
            NewWindow.Show();
        }

        private void TBOXSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filt();
            LVAgent.Items.Refresh();
        }
    }
}
