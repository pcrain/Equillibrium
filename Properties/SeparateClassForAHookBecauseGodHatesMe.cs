using BepInEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;

namespace Equillibrium
{
    public class SeparateClassForAHookBecauseGodHatesMe
    {
        public static void Init()
        {
            new Hook(typeof(LootData).GetMethod("GetSingleItemForPlayer", BindingFlags.Instance | BindingFlags.Public), typeof(SeparateClassForAHookBecauseGodHatesMe).GetMethod("GetSingleItemForPlayerHook"));
        }
        public static PickupObject GetSingleItemForPlayerHook(Func<LootData, PlayerController, int, PickupObject> orig, LootData self, PlayerController player, int tierShift = 0)
        {
            PickupObject p = orig(self, player, tierShift);
            try
            {
                foreach (ModdedItemTracker moddedItemTracker in EquillibriumModule.moddedItemTrackers)
                {
                    EquillibriumModule.ReprocessWeights(moddedItemTracker, moddedItemTracker.ID == "gungeon" ? EquillibriumModule.VanillaMultiplier() : 1, moddedItemTracker.ItemIDs.Contains(p.PickupObjectId) == true ? false : true);
                }
                return p;
            }
            catch
            {
                return p;
            }
        }
    }
}
