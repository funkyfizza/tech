using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Gnatta.Api.Services
{
    public class JsonNetSerialiser : IJsonSerialiser
    {
        private readonly JsonSerializerSettings _settings;

        public JsonNetSerialiser()
        {
            _settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
        
        public TTarget DeserialiseObject<TTarget>(string json)
        {
            return JsonConvert.DeserializeObject<TTarget>(json, _settings);
        }
    }
}