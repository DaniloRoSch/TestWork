using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TIASelectionTool_Core.ViewModels
{
    public class HeaderViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<NodeGroupViewModel> _nodeGroups = new ObservableCollection<NodeGroupViewModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<NodeGroupViewModel> NodeGroups
        {
            get
            {
                return _nodeGroups;
            }
                set
            {
                _nodeGroups = value;
                OnPropertyChanged(nameof(NodeGroups));
            }
        }

        public void Clear()
        {
            _nodeGroups?.Clear();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
