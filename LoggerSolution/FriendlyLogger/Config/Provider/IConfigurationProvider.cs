using System.Xml;

namespace FriendlyLogger.Config.Provider
{
    public interface IConfigurationProvider
    {
        XmlDocument LoadConfiguration();
    }
}
