using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;

namespace NotLethalFall.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        [HarmonyPatch("PlayerHitGroundEffects")]
        [HarmonyPrefix]
        static void NotLethalFallPatch(ref bool ___takingFallDamage)
        {
            // This line is added for debugging, uncomment is this loop is not running.
            //Console.WriteLine("Preventing Fall Damage");
            ___takingFallDamage = false;
        }
    }
}
