using System;
using System.Collections.Generic;

namespace StoreProcedure
{
    public class Param : List<KeyValue>
    {
        public void Add(string key, object value)
        {
            this.Add(new KeyValue(key, value));
        }
    }

    public class Json : List<KeyValue>
    {
        public void Add(string key, object value)
        {
            this.Add(new KeyValue(key, value));
        }
    }

    public class Output : List<KeyValue>
    {
        public void Add(string key)
        {
            this.Add(new KeyValue(key));
        }
    }
}