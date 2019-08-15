using System.Collections.Generic;

namespace TIASelectionTool_Model.DataModel
{
    public class Node
    {
        private string _name;
        public string Type { get; }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    return Id;
                }

                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Id { get; }

        public List<Property> Properties { get; }

        public Node(string type, string name, string id, List<Property> properties)
        {
            Type = type;
            Name = name;
            Id = id;
            Properties = properties;
        }
    }
}
