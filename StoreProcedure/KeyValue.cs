using System;
namespace StoreProcedure
{
    public class KeyValue
    {
        public KeyValue(string key)
        {
            this.Key = key;
        }

        public KeyValue(string key, object value)
        {
            this.Key = key;
            this.Value = value;
        }
        public string Key { get; set; }
        public object Value { get; set; }
    }
}