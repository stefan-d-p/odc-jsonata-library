
using Newtonsoft.Json;
using NuGet.Frameworks;
using NUnit.Framework;

namespace JSONata.Test
{
    [TestFixture]
    public class Tests
    {

        private static readonly IJSONata _actions = new JSONata();

        private static readonly string sourceJSON = @"{
              ""FirstName"": ""Fred"",
              ""Surname"": ""Smith"",
              ""Age"": 28,
              ""Address"": {
                ""Street"": ""Hursley Park"",
                ""City"": ""Winchester"",
                ""Postcode"": ""SO21 2JN""
              },
              ""Phone"": [
                {
                  ""type"": ""home"",
                  ""number"": ""0203 544 1234""
                },
                {
                  ""type"": ""office"",
                  ""number"": ""01962 001234""
                },
                {
                  ""type"": ""office"",
                  ""number"": ""01962 001235""
                },
                {
                  ""type"": ""mobile"",
                  ""number"": ""077 7700 1234""
                }
              ],
              ""Email"": [
                {
                  ""type"": ""office"",
                  ""address"": [
                    ""fred.smith@my-work.com"",
                    ""fsmith@my-work.com""
                  ]
                },
                {
                  ""type"": ""home"",
                  ""address"": [
                    ""freddy@my-social.com"",
                    ""frederic.smith@very-serious.com""
                  ]
                }
              ],
              ""Other"": {
                ""Over 18 ?"": true,
                ""Misc"": null,
                ""Alternative.Address"": {
                  ""Street"": ""Brick Lane"",
                  ""City"": ""London"",
                  ""Postcode"": ""E1 6RF""
                }
              }
            }";

        public static readonly string invalidSourceJson = "hfkjfhkfhdkjsfhkjds";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Transform_Returns_Successful()
        {
            string transformation = @"{
                ""name"": FirstName & "" "" & Surname,
                ""mobile"": Phone[type = ""mobile""].number
            }";

            string expectedResult = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(@"{
              ""name"": ""Fred Smith"",
              ""mobile"": ""077 7700 1234""
            }"));

            var result = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(_actions.Transform(sourceJSON,transformation)));
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Transform_Returns_InvalidTransformation()
        {
            string transformation = "Invalid Transformation";
            
            Assert.Throws<Jsonata.Net.Native.JsonataException>(() => _actions.Transform(sourceJSON,transformation));

        }

        [Test]
        public void Transform_Returns_InvalidSourceDocument()
        {
            string transformation = @"{
                ""name"": FirstName & "" "" & Surname,
                ""mobile"": Phone[type = ""mobile""].number
            }";

            Assert.Throws< Jsonata.Net.Native.Json.JsonParseException>(() => _actions.Transform(invalidSourceJson,transformation));
        }
    }
}