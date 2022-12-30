using HarmonyLib;
using RimWorld;

namespace DefaultIngredientRadius;

[HarmonyPatch(typeof(BillUtility), "MakeNewBill")]
public class BillUtility_MakeNewBill_Detour
{
    public static void Postfix(ref Bill __result)
    {
        if (DefaultIngredientRadiusMod.instance.Settings.DefaultRadius >= 100)
        {
            // Setting is the same as vanilla
            return;
        }

        if (__result is not Bill_Production billProduction)
        {
            return;
        }

        if (billProduction.ingredientSearchRadius < 100)
        {
            // Something else have changed the radius already
            return;
        }

        billProduction.ingredientSearchRadius = DefaultIngredientRadiusMod.instance.Settings.DefaultRadius;
    }
}