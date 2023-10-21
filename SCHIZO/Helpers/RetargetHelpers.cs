namespace SCHIZO.Helpers;

public static class RetargetHelpers
{
    public static
#if SUBNAUTICA
        TSubnautica
#else
        TBelowZero
#endif
        Pick<TSubnautica, TBelowZero>(TSubnautica subnautica, TBelowZero belowZero)
    {
#if SUBNAUTICA
        return subnautica;
#else
        return belowZero;
#endif
    }

    public static bool IsStoryEnabled()
#if BELOWZERO
        => GameModeManager.GetOption<bool>(GameOption.Story);
#else
        => true;
#endif
}
