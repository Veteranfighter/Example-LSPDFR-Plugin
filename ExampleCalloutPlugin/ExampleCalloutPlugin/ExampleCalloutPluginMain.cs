using LSPD_First_Response.Mod.API;
using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleCalloutPlugin
{
    public class ExampleCalloutPluginMain : Plugin
    {

        public override void Initialize()
        {
            VersionString = UtilFunctions.GetAssemblyVersion();
            Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;
        }

        private static void LoadPlugin()
        {
            IniHelper.InitializeConfigurations();
            RegisterCallouts();
            EupInstalled = NativeFunction.Natives.IS_DLC_PRESENT<bool>(Game.GetHashKey("eup"));
            SupInstalled = NativeFunction.Natives.IS_DLC_PRESENT<bool>(Game.GetHashKey("sup"));

            Game.DisplayNotification("web_lossantospolicedept", "web_lossantospolicedept", "Example Plugin", "~y~" + VersionString + " ~o~by Len IT.", "Thanks for using ~b~Example Plugin.~w~ If you find any bugs, don't hesitate ~y~joining my discord.");
        }

        private static void UnloadPlugin()
        {
            Game.DisplayNotification("Bye Bye :)");
        }

        private static void RegisterCallouts()
        {
            // Uncomment this and change ExampleClass:
            // Functions.RegisterCallout(typeof(ExampleClass));
        }

        private static void OnOnDutyStateChangedHandler(bool OnDuty)
        {
            if (OnDuty) LoadPlugin();
            else UnloadPlugin();
        }

        public override void Finally()
        {
            throw new NotImplementedException();
        }

        public static String VersionString
        {
            get { return VersionString; }
            private set { VersionString = value; }
        }

        public static bool EupInstalled
        {
            get { return EupInstalled; }
            private set { EupInstalled = value; }
        }

        public static bool SupInstalled
        {
            get { return SupInstalled; }
            private set { SupInstalled = value; }
        }

    }
}
