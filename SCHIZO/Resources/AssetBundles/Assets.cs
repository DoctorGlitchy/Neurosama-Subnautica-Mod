

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was automatically generated. PLEASE DO NOT MODIFY THIS FILE MANUALLY!
// </auto-generated>
//------------------------------------------------------------------------------

// Resharper disable all

namespace SCHIZO.Resources;

public static class Assets
{
    private const int _rnd = 851960290;

    private static readonly UnityEngine.AssetBundle _a = ResourceManager.GetAssetBundle("assets");

    public static T[] All<T>() where T : UnityEngine.Object => _a.LoadAllAssets<T>();
    public static UnityEngine.Object[] All() => _a.LoadAllAssets();
        
    public static SCHIZO.Items.Data.ItemData Mod_Gymbag_GymbagBZ = _a.LoadAsset<SCHIZO.Items.Data.ItemData>("Assets/Mod/Gymbag/Gymbag BZ.asset");
    public static SCHIZO.Items.Data.ItemData Mod_Gymbag_GymbagSN = _a.LoadAsset<SCHIZO.Items.Data.ItemData>("Assets/Mod/Gymbag/Gymbag SN.asset");
    public static UnityEngine.Sprite Mod_Loading_Icon_LoadingIcon = _a.LoadAsset<UnityEngine.Sprite>("Assets/Mod/Loading/Icon/loading icon.png");
    public static SCHIZO.Options.Bool.ToggleModOption Mod_Options_DisableAllSounds = _a.LoadAsset<SCHIZO.Options.Bool.ToggleModOption>("Assets/Mod/Options/Disable all sounds.asset");
    public static SCHIZO.Options.Bool.ToggleModOption Mod_Options_EnableAutomaticEvents = _a.LoadAsset<SCHIZO.Options.Bool.ToggleModOption>("Assets/Mod/Options/Enable automatic events.asset");
    public static SCHIZO.Registering.ModRegistry Mod_Registry = _a.LoadAsset<SCHIZO.Registering.ModRegistry>("Assets/Mod/Registry.asset");
}
