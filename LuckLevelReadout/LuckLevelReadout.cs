using HarmonyLib;
using MelonLoader;
using TMPro;

namespace LuckLevelReadout
{
    public class LuckLevelReadout : MelonMod
    {
        [HarmonyPatch(typeof(Player), "Update")]
        class LuckUpdatePatch
        {
            static void Postfix(ref Player __instance, ref TextMeshProUGUI ___experienceText)
            {
                ___experienceText.text =
                "Experience: " + __instance.experience.ToString() + " / " + __instance.experienceToLevels[__instance.level].ToString() +
                " uncommonLuck: " + __instance.uncommonLuck.ToString() +
                " rareLuck: " + __instance.rareLuck.ToString() +
                " legendaryLuck: " + __instance.legendaryLuck.ToString();
            }
        }
    }
}