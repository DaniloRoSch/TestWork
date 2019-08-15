using System.Linq;
using System.Windows;
using TIASelectionTool_Model.Reader;
using TIASelectionTool_Model.Resources.Strings;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using TIASelectionTool_Core.ViewModels;
using Microsoft.Win32;

namespace TIASelectionTool_WpfDialog
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _windowTitlePrefix =
            Labels.Window_TitleText + " - " + Labels.Window_TitleSubText;
        public string FileName { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Title = _windowTitlePrefix;
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "TIA File | *.tia";

            if (dialog.ShowDialog() != true)
            {
                return;
            }
            
            Title = _windowTitlePrefix + " - " + "\"" + dialog.SafeFileName + "\"";

            var reader = new FileReader();

            ((HeaderViewModel)PART_HeaderControl.DataContext).Clear();
            ((HeaderViewModel)PART_HeaderControl.DataContext).NodeGroups = 
                new ObservableCollection<NodeGroupViewModel>(reader.ReadFile(dialog.FileName)
                .Select(x => new NodeGroupViewModel(x)));
        }

        private void PART_HeaderControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(sender is ListBox headerListBox))
            {
                return;
            }

            PART_ContentControl.ItemsSource = ((NodeGroupViewModel)headerListBox.SelectedItem)?.Nodes;
        }
    }
}
