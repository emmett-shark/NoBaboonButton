using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace NoBaboonButton;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private void Awake() => new Harmony(PluginInfo.PLUGIN_GUID).PatchAll();

    [HarmonyPatch(typeof(PointSceneController), nameof(PointSceneController.Start))]
    public static class PointSceneControllerStartPatches
    {
        public static void Postfix()
        {
            GameObject.Find("Canvas/buttons/BABOON").SetActive(false);
            GameObject.Find("Canvas/buttons/CARDS").SetActive(false);
        }
    }

    [HarmonyPatch(typeof(PointSceneController), nameof(PointSceneController.showContinue))]
    public static class PointSceneControllerShowContinuePatches
    {
        public static void Postfix()
        {
            GameObject.Find("Canvas/buttons/BABOON").SetActive(false);
            GameObject.Find("Canvas/buttons/CARDS").SetActive(false);
        }
    }
}
