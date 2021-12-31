using System;
namespace StoreProcedure
{
    public class KeyValue
    {
        internal KeyValue(string key)
        {
            this.Key = key;
        }

        internal KeyValue(string key, object value)
        {
            this.Key = key;
            this.Value = value;
        }
        public string Key { get; set; }
        public object Value { get; set; }
    }
}