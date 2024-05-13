
using Newtonsoft.Json;
using System.Collections.Generic;

public class Eng : IData
{
    public Dictionary<string, string> _data { get; private set; }

    [JsonConstructor]
    public Eng(Dictionary<string, string> data)
    {
        _data = data;
    }
}
