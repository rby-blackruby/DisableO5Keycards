using Harmony;
using System;

namespace DisableO5Keycards
{
    [HarmonyPatch(typeof(Scp914.Scp914Machine), "UpgradeItem", new Type[] { typeof(Pickup) } )]
    class YouCantUpgradeToO5haha
    {

        public static bool Prefix(Scp914.Scp914Machine __instance, Pickup item)
        {
            ItemType itemType = __instance.UpgradeItemID(item.info.itemId);
            if (itemType == ItemType.KeycardO5)
            {
                return false;
            }
            if (itemType < ItemType.KeycardJanitor)
            {
                item.Delete();
                return false;
            }
            item.SetIDFull(itemType);
            return true;

        }
    }
}
