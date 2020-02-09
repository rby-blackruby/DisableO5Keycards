using Harmony;

namespace DisableO5Keycards
{
    public class Plugin : EXILED.Plugin
    {
        public override string getName { get; } = "DisableO5Keycards - blackruby";
        public static bool DisableO5;
        public static uint PatchCount;

        public static HarmonyInstance HarmonyInstance { set; get; }

        public override void OnEnable()
        {
            DisableO5 = Plugin.Config.GetBool("disable_o5", true);

            if(DisableO5 == false)
            {
                Plugin.Info("DisableO5Keycards is disabled on this server.");
                return;
            }

            Plugin.Info("Thank you for using DisableO5Keycards - blackruby");
            Plugin.Info("While disable_o5 is set to true, nobody is able to upgrade their keycards to O5 on the server.");

            HarmonyInstance = HarmonyInstance.Create($"blackruby.exiled.disableo5{PatchCount}");
            PatchCount++;
            HarmonyInstance.PatchAll();
        }

        public override void OnDisable()
        {
            HarmonyInstance.UnpatchAll();
        }

        public override void OnReload()
        {
        }

    }
}
