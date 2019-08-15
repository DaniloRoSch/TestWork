using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using TIASelectionTool_Model.DataModel;

namespace TIASelectionTool_Model.Reader
{
    public class FileReader
    {
        public List<NodeGroup> ReadFile(string filePath)
        {
            var nodesList = new List<Node>();
            if (!File.Exists(filePath))
            {
                return null;
            }
            
            var document = new XmlDocument();

            document.Load(filePath);

            var graphNode = document.SelectSingleNode("tiaselectiontool")
                .SelectSingleNode("business")
                .SelectSingleNode("graph");

            var nodes = graphNode.SelectSingleNode("nodes");

            foreach (var childNode in nodes.ChildNodes.Cast<XmlElement>())
            {
                if (!childNode.HasAttribute("Type"))
                {
                    continue;
                }

                var type = childNode.GetAttribute("Type");

                List<Property> nodeProperties = CreateNodeProperties(childNode.SelectSingleNode("properties"));

                var node = new Node(type,
                            nodeProperties.FirstOrDefault(x => x.Key.Equals("name", StringComparison.InvariantCultureIgnoreCase))?.Value,
                            nodeProperties.FirstOrDefault(x => x.Key.Equals("id", StringComparison.InvariantCultureIgnoreCase))?.Value,
                            nodeProperties);

                nodesList.Add(node);
            }

            var nodeGroups = new List<NodeGroup>();
            var groupedNodes = nodesList.GroupBy(x => x.Type);

            foreach (var grouped in groupedNodes)
            {
                nodeGroups.Add(new NodeGroup(grouped.Key, grouped.Select(x => x).ToList()));
            }

            return nodeGroups;
        }

        private static List<Property> CreateNodeProperties(XmlNode child)
        {
            var nodeProperties = new List<Property>();

            foreach (var property in child.ChildNodes.Cast<XmlElement>())
            {
                var key = property.SelectSingleNode("key")?.InnerText;
                var value = property.SelectSingleNode("value")?.InnerText;

                if (key == null || value == null)
                {
                    continue;
                }

                nodeProperties.Add(new Property(key, value));
            }

            return nodeProperties;
        }
    }
}
