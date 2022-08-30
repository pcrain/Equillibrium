using BepInEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using static MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers;
using System.IO;
using BepInEx.Configuration;

namespace Equillibrium
{
    public class EquillibriumConfig
    {
        public static void Init()
        {
            CreateConfig(configurationFile);
        }
        public static void CreateConfig(ConfigFile config)
        {
            VanillaChanceMultiplier = config.Bind<float>("Eqiullibrium:", "Vanilla Item Chance Multiplier", 0.1f, "(Default of 0.1f) Multiplies the weight of Vanilla/base game items when certain calcualtions are done.");
            advancedMode = config.Bind<bool>("Eqiullibrium:", "Advanced Mode", false, "(Default as false) If enabled, also re-processes the weights of items when they appear.");
            PickupCoefficient = config.Bind<int>("Eqiullibrium:", "Pickup Co-effecient", 1, "(Default: 1, Requires Advanced Mode) When an item is spawned, divides the weight of its pool by the Pickup Co-effecient, and reduces the Pickup Co-effecient by 1 every time a new item that isn't of its pool is spawned.");
            ModAmountScaling = config.Bind<bool>("Eqiullibrium:", "Mod Quantity Scaling", true, "(Default: true, Requires Advanced Mode)  When enabled, certain calculations will scale depending on how many separate mod pools the mod is able to detect.");

        }
        public static ConfigEntry<int> PickupCoefficient;
        public static ConfigEntry<bool> ModAmountScaling;
        public static ConfigEntry<float> VanillaChanceMultiplier;
        public static ConfigEntry<bool> advancedMode;

        public static ConfigFile configurationFile;
    }
}
