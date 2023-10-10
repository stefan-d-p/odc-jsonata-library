using OutSystems.ExternalLibraries.SDK;

namespace JSONata
{
    [OSInterface(
        Description = "Perform complex JSON transformations with JSONata",
        Name = "JSONata",
        IconResourceName = "JSONata.Resources.jsonata.png")]
    public interface IJSONata
    {
        /// <summary>
        /// Transforms a JSON document with a JSONata transformation file
        /// </summary>
        /// <param name="json">A valid source JSON document</param>
        /// <param name="transformation">A JSONata transformation file</param>
        /// <returns>Transformed JSON document</returns>
        /// <exception cref="Jsonata.Net.Native.JsonataException">Transformation document invalid</exception>
        /// <exception cref="Jsonata.Net.Native.Json.JsonParseException">Invalid JSON source document</exception>
        /// <exception cref="System.Exception">Transformation error</exception>

        [OSAction(
            Description = "This Action takes a JSON document and a JSONata transformation as input.",
            ReturnName = "Result",
            ReturnDescription = "Transformed JSON Document",
            ReturnType = OSDataType.Text,
            IconResourceName = "JSONata.Resources.jsonata.png")]
        string Transform(
            [OSParameter(
                DataType = OSDataType.Text,
                Description = "JSON source document")]
            string json,
            [OSParameter(
                DataType = OSDataType.Text,
                Description = "JSONata transformation")]
            string transformation);
    }
}