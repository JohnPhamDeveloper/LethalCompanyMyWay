using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace LethalCompanyMyWay.Patches
{
    [HarmonyPatch]
    internal class JesterAIPatch
    {
        [HarmonyPatch(typeof(JesterAI), "SetJesterInitialValues")]
        [HarmonyPostfix]
        public static void JesterStartPatch(ref AudioClip ___screamingSFX) {
            if (Plugin.myWayAudioClip) {
                ___screamingSFX = Plugin.myWayAudioClip;
            } 
        }
    }
}
