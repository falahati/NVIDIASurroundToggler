namespace NVIDIASurroundToggle
{
    internal class ComboBoxItem
    {
        public ComboBoxItem(string text)
        {
            Text = text;
        }

        public ComboBoxItem()
        {
        }

        public string Text { get; set; }
        public object Tag { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}