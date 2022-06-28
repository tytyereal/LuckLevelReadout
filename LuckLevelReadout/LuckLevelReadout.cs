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
                if(__instance.level == __instance.chosenCharacter.levelUps.Count - 1)
                {
                    ___experienceText.text =
                    "Max Level" +
                    " uncommonLuck: " + __instance.uncommonLuck.ToString() +
                    " rareLuck: " + __instance.rareLuck.ToString() +
                    " legendaryLuck: " + __instance.legendaryLuck.ToString();
                    return;
                }
                ___experienceText.text =
                "Experience: " + __instance.experience.ToString() + " / " + __instance.chosenCharacter.levelUps[__instance.level+1].xpRequired +
                " uncommonLuck: " + __instance.uncommonLuck.ToString() +
                " rareLuck: " + __instance.rareLuck.ToString() +
                " legendaryLuck: " + __instance.legendaryLuck.ToString();
            }
        }
    }
}