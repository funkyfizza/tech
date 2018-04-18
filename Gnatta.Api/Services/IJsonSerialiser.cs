namespace Gnatta.Api.Services
{
    public interface IJsonSerialiser
    {
        TTarget DeserialiseObject<TTarget>(string json);
    }
}