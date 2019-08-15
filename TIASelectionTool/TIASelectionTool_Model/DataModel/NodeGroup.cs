using System.Collections.Generic;

namespace TIASelectionTool_Model.DataModel
{
    public class NodeGroup
    {
        public string Type { get; }
        public IEnumerable<Node> Nodes { get; }

        public NodeGroup(string type, IEnumerable<Node> nodes)
        {
            Type = type;
            Nodes = nodes;
        }

    }
}
