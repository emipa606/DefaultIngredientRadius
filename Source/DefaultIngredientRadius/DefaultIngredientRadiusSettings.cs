using Verse;

namespace DefaultIngredientRadius;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class DefaultIngredientRadiusSettings : ModSettings
{
    public float DefaultRadius = 999f;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref DefaultRadius, "DefaultRadius", 999f);
    }
}