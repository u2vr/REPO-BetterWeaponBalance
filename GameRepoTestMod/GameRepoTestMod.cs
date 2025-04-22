using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using UnityEngine;

[BepInPlugin("ru.u2vr.betterweaponbalance", "BetterWeaponBalance Mod", "0.1.0")]
public class Program: BaseUnityPlugin
{
    public static BepInEx.Logging.ManualLogSource Log;

    public void Awake()
    {
        var harmony = new Harmony("ru.u2vr.betterweaponbalance");
        harmony.PatchAll();
        Logger.LogInfo("Gun Battery Mod loaded!");
        Log = Logger;
    }
}

[HarmonyPatch(typeof(ItemGun), "Update")]
public class ItemGun_Update_Patch
{
    public static void Prefix(ItemGun __instance)
    {
        if (__instance == null)
            return;
        if (__instance.name.Contains("Item Gun Tranq"))
        {
            __instance.batteryDrain = 10f;
            __instance.batteryDrainFullBar = false;
            __instance.batteryDrainFullBars = 1;
        }
        else if (__instance.name.Contains("Item Gun Shotgun"))
        {
            __instance.batteryDrain = 20f;
            __instance.batteryDrainFullBar = false;
            __instance.batteryDrainFullBars = 1;
        }
        else if (__instance.name.Contains("Item Gun Handgun"))
        {
            __instance.batteryDrain = 10f;
            __instance.batteryDrainFullBar = false;
            __instance.batteryDrainFullBars = 1;
        }
        else if (__instance.name.Contains("Item Gun"))
        {
            __instance.batteryDrain = 20f;
            __instance.batteryDrainFullBar = false;
            __instance.batteryDrainFullBars = 1;
            //Program.Log.LogInfo(__instance.name);
        }
    }
}