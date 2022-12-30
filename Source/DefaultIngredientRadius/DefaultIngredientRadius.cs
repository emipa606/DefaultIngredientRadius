using System.Reflection;
using HarmonyLib;
using Verse;

namespace DefaultIngredientRadius;

[StaticConstructorOnStartup]
public static class DefaultIngredientRadius
{
    static DefaultIngredientRadius()
    {
        new Harmony("Mlie.DefaultIngredientRadius").PatchAll(Assembly.GetExecutingAssembly());
    }
}