using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TIASelectionTool_Model.DataModel;

namespace TIASelectionTool_Core.ViewModels
{
    public class NodeGroupViewModel : INotifyPropertyChanged
    {
        private List<NodeViewModel> _nodes;

        public event PropertyChangedEventHandler PropertyChanged;

        public NodeGroup Model { get; }

        public string Type => Model.Type;

        public List<NodeViewModel> Nodes
        {
            get
            {
                return _nodes;
            }
            set
            {
                _nodes = value;
                OnPropertyChanged(nameof(Nodes));
            }
        }

        public NodeGroupViewModel(NodeGroup nodeGroup)
        {
            Model = nodeGroup;
            Nodes = new List<NodeViewModel>(nodeGroup.Nodes.Select(x => new NodeViewModel(x)));
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
