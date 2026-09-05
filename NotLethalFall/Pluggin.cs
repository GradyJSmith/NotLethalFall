using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using NotLethalFall.Patches;

namespace NotLethalFall
{
    [BepInPlugin(modGUID, modName, modVersion)]

    public class NotLethalFallBase : BaseUnityPlugin
    {
        private const string modGUID = "GStar.NotLethalFall";
        private const string modName = "NotLethalFall";
        private const string modVersion = "1.1.0";

        public static ConfigEntry<bool> configFallDamageOn;

        private readonly Harmony harmony = new Harmony(modGUID);

        private static NotLethalFallBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("NotLethalFall is running...");

            configFallDamageOn = Config.Bind("Fall Damage",
                                                "Fall Damage On",
                                                false,
                                                "Whether or not to enable fall damage");

            harmony.PatchAll(typeof(NotLethalFallBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
            harmony.PatchAll(typeof(KickIfModNotInstalled));
        }

    }
}
