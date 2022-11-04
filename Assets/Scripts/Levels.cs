public static class Levels
{
    private static string _currentLevel;
    public static int[] Platforms()
    {
        switch (_currentLevel)
        {
            case Constants.MOVEMENT_TUTORIAL:
                return new int[] {0, 1};
            case Constants.SHAPE_TUTORIAL:
                return new int[] { 0, 2 };
            case Constants.COLOR_TUTORIAL:
                return new int[] { 0, 3 };
            case Constants.DEFAULT_LEFT_TUTORIAL:
                return new int[] { 0, 4 };
            case Constants.LOCK_TUTORIAL:
                return new[] { 0, 5 };
            case Constants.COINS_TUTORIAL:
                return new[] { 0, 6, 7 };
            case Constants.BOUNCE_TUTORIAL:
                return new[] { 0, 8 };
            case Constants.HEALTH_TUTORIAL:
                return new[] { 0, 9, 10 };
        }

        return new int[] { };
    }

    public static void SetCurrentLevel(string level)
    {
        _currentLevel = level;
    }
}