using Jsonata.Net.Native;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.JSONata
{
    public class JSONata : IJSONata
    {
        public string Transform(string json, string transformation)
        {
            JsonataQuery query = new JsonataQuery(transformation);
            return query.Eval(json);
        }
    }
}