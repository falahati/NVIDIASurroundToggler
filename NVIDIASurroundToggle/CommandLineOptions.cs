using System;
using System.Linq;
using System.Windows.Forms;
using CommandLine;
using CommandLine.Text;
using NVIDIASurroundToggle.Resources;

namespace NVIDIASurroundToggle
{
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

        private static CommandLineOptions _defaultObject;

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

        [Option('l', "lang",
            HelpText = "Providing the language of NVidia Control Panel, if different from the default value or the Windows UI culture. (en-US, de-DE)")]
        public string Language { get; set; }

        public static CommandLineOptions Default
        {
            get
            {
                if (_defaultObject == null)
                {
                    _defaultObject = new CommandLineOptions();
                    Parser.Default.ParseArguments(Environment.GetCommandLineArgs().Skip(1).ToArray(), _defaultObject);
                    Console.WriteLine(string.Join(" ", Environment.GetCommandLineArgs().Skip(1)));
                    if (_defaultObject.LastParserState != null && _defaultObject.LastParserState.Errors.Count > 0)
                    {
                        throw new Exception(_defaultObject.LastParserState.Errors[0].ToString());
                    }
                }
                return _defaultObject;
            }
        }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        // ReSharper disable once UnusedMember.Global
        public string GetUsage()
        {
            var help = HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
            MessageBox.Show(help, Resources.Language.CommandLineOptions_Help, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(0);
            return help;
        }
    }
}