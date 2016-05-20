using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NVIDIASurroundToggle.Native.Stractures;

namespace NVIDIASurroundToggle
{
    /// <summary>
    ///     Holds configurations of a display monitor
    /// </summary>
    public class DisplaySetting
    {
        /// <summary>
        ///     Gets or sets display properties and configurations
        /// </summary>
        public DevMode DevMode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the display monitor
        /// </summary>
        public string DisplayName { get; set; }

        internal static string ArrayToXml(DisplaySetting[] array)
        {
            var serializer = new XmlSerializer(typeof (DisplaySetting[]));
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, array);
            }
            return sb.ToString();
        }

        internal static DisplaySetting[] XmlToArray(string xml)
        {
            var serializer = new XmlSerializer(typeof (DisplaySetting[]));
            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                return (DisplaySetting[]) serializer.Deserialize(reader);
            }
        }
    }
}