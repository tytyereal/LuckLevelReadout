using HarmonyLib;
using MelonLoader;
using TMPro;

namespace LuckLevelReadout
{
    public class LuckLevelReadout : MelonMod
    {
        [HarmonyPatch(typeof(GameManager), "Start")]
        class LuckStartPatch
        {
            static void Postfix(ref Player __instance, ref TextMeshProUGUI ___goldText)
            {
                ___goldText.enableWordWrapping = false;
                ___goldText.wordWrappingRatios = 5000;
                ___goldText.fontSizeMax = 45;
                ___goldText.autoSizeTextContainer = true;
            }
        }

        [HarmonyPatch(typeof(GameManager), "Update")]
        class LuckUpdatePatch
        {
            static void Postfix(ref GameManager __instance, ref TextMeshProUGUI ___goldText)
            {
                ___goldText.text =
                __instance.goldAmount +
                " uncommonLuck: " + UnityEngine.Object.FindObjectOfType<Player>().uncommonLuck.ToString() +
                " rareLuck: " + UnityEngine.Object.FindObjectOfType<Player>().rareLuck.ToString() +
                " legendaryLuck: " + UnityEngine.Object.FindObjectOfType<Player>().legendaryLuck.ToString();
            }
        }
    }
}