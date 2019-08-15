using TIASelectionTool_Model.DataModel;

namespace TIASelectionTool_Core.ViewModels
{
    public class NodeViewModel
    {
        public Node Model { get; }

        public NodeViewModel(Node node)
        {
            Model = node;
        }
    }
}
