using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalNunit.utilities
{
    public class JsonReader
    {
        public JsonReader()
        {
        }

        public string extractData(string tokenName)
        {
            
                string myJsonString = File.ReadAllText("utilities/testData.json");

                var jsonObject = JToken.Parse(myJsonString);
                return jsonObject.SelectToken(tokenName).Value<string>();
            


        }

    }
}
