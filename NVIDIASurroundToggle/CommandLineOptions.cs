namespace NVIDIASurroundToggle
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using CommandLine;
    using CommandLine.Text;

    using NVIDIASurroundToggle.Resources;

    internal class CommandLineOptions
    {
        public enum Actions
        {
            None,

            ToggleMode,

            GoSurround,

            GoExtended,

            OpenOptions,

            OpenTools
        }

        private static CommandLineOptions defaultObject;

        private CommandLineOptions()
        {
        }

        [Option('a', "action", HelpText = "What you expect me to do? (ToggleMode, Go{Mode}, Open{Form})",
            DefaultValue = Actions.None)]
        public Actions Action { get; set; }

        [Option('e', "execute", HelpText = "For this program only? (Filename)", DefaultValue = null)]
        public string StartFilename { get; set; }

        [Option("arguments", HelpText = "The other program execution options.", DefaultValue = null)]
        public string StartArguments { get; set; }

        [Option('w', "waitfor",
            HelpText =
                "Wait for this specific process to exit instead of the filename provided, useful when there is a launcher involved.",
            DefaultValue = null)]
        public string StartProcess { get; set; }

        [Option('t', "timeout",
            HelpText = "The maximum time in seconds to wait for the process since the execution of the program.",
            DefaultValue = 20)]
        public int StartProcessTimeout { get; set; }

        public static CommandLineOptions Default
        {
            get
            {
                if (defaultObject == null)
                {
                    defaultObject = new CommandLineOptions();
                    Parser.Default.ParseArguments(Environment.GetCommandLineArgs().Skip(1).ToArray(), defaultObject);
                    Console.WriteLine(string.Join(" ", Environment.GetCommandLineArgs().Skip(1)));
                    if (defaultObject.LastParserState != null && defaultObject.LastParserState.Errors.Count > 0)
                    {
                        throw new Exception(defaultObject.LastParserState.Errors[0].ToString());
                    }
                }
                return defaultObject;
            }
        }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        // ReSharper disable once UnusedMember.Global
        public string GetUsage()
        {
            var help = HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
            MessageBox.Show(help, Language.CommandLineOptions_Help, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(0);
            return help;
        }
    }
}