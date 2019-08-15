namespace TIASelectionTool_Model.DataModel
{
    public class Property
    {
        public string Key { get; }
        public string Value { get; }

        public Property(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
