namespace NVIDIASurroundToggle
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using NVIDIASurroundToggle.Native.Stractures;

    public class DisplaySetting
    {
        public DevMode Devmode { get; set; }

        public string DisplayName { get; set; }

        public static string ArrayToXml(DisplaySetting[] array)
        {
            var serializer = new XmlSerializer(typeof(DisplaySetting[]));
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, array);
            }
            return sb.ToString();
        }

        public static DisplaySetting[] XmlToArray(string xml)
        {
            var serializer = new XmlSerializer(typeof(DisplaySetting[]));
            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                return (DisplaySetting[])serializer.Deserialize(reader);
            }
        }
    }
}