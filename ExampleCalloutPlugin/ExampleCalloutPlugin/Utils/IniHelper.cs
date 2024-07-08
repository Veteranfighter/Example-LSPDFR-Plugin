using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleCalloutPlugin
{
    internal class IniHelper
    {
        private static InitializationFile ConfigurationSettings = new InitializationFile("Plugins/LSPDFR/ExampleCalloutPlugin/configuration.ini");

        //public static Keys _endCalloutKey = Keys.End;
        public static Keys EndCalloutKey
        {
            get { return EndCalloutKey; }
            private set { EndCalloutKey = value; }
        }


        public static void InitializeConfigurations()
        {
            // Initialize Keys
            try
            {
                EndCalloutKey = ConfigurationSettings.ReadEnum("Keybindings", "EndCallout", Keys.End);
            }
            catch (Exception ex)
            {
                Game.DisplayNotification("~r~Important: ~w~DO NOT IGNORE THIS MESSAGE. ~o~An error occurred while processing the configuration file. ~w~Please reinstall ~o~ExampleCalloutPlugin ~w~and ~r~report~w~ this incident to the Developer.");
            }
        }

    }
}
