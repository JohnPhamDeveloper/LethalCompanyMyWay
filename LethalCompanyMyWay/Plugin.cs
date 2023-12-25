using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using LethalCompanyMyWay.Patches;
using UnityEngine;

namespace LethalCompanyMyWay
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "Juny.MyWay";
        private const string modName = "Jester My Way Chase Song";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static Plugin Instance;

        public static AudioClip myWayAudioClip;

        private void Awake()
        {
            if (Instance == null) {
                Instance = this;
            }

            var DLLDirectoryName = Path.GetDirectoryName(this.Info.Location);
            AssetBundle assetBundle = AssetBundle.LoadFromFile(Path.Combine(DLLDirectoryName, "myway"));
            Debug.Log($"assetBundle: {assetBundle}");

            myWayAudioClip = assetBundle.LoadAsset<AudioClip>("MyWayLethalCompany");
            if (myWayAudioClip)
            {
                Debug.Log($"[MyWayJester] - Successfully loaded audio file");
            }
            else {
                Debug.LogError("[MyWayJester] = Failed to load audio file");
            }

            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(JesterAIPatch));
        }
    }
}
