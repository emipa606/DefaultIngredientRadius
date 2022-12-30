using Mlie;
using UnityEngine;
using Verse;

namespace DefaultIngredientRadius;

[StaticConstructorOnStartup]
internal class DefaultIngredientRadiusMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static DefaultIngredientRadiusMod instance;

    private static string currentVersion;

    /// <summary>
    ///     The private settings
    /// </summary>
    private DefaultIngredientRadiusSettings settings;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public DefaultIngredientRadiusMod(ModContentPack content) : base(content)
    {
        instance = this;
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal DefaultIngredientRadiusSettings Settings
    {
        get
        {
            if (settings == null)
            {
                settings = GetSettings<DefaultIngredientRadiusSettings>();
            }

            return settings;
        }
        set => settings = value;
    }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Default Ingredient Radius";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.Label(
            Settings.DefaultRadius >= 100f
                ? "DIR.DefaultRadiusUnlimited".Translate()
                : "DIR.DefaultRadius".Translate(Settings.DefaultRadius.ToString("F0")), -1,
            "DIR.DefaultRadiusTT".Translate());
        Settings.DefaultRadius =
            listing_Standard.Slider(Settings.DefaultRadius > 100f ? 100f : Settings.DefaultRadius, 3f, 100f);
        if (Settings.DefaultRadius >= 100f)
        {
            Settings.DefaultRadius = 999f;
        }

        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("DIR.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }
}