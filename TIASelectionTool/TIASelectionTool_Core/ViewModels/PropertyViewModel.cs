using TIASelectionTool_Model.DataModel;

namespace TIASelectionTool_Core.ViewModels
{
    public class PropertyViewModel
    {
        public Property Model { get; }

        public PropertyViewModel(Property property)
        {
            Model = property;
        }

        public PropertyViewModel()
        {

        }
    }
}
