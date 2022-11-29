using UnityEngine;

public static class Levels
{
    private static string _currentLevel;
    public static int[] Platforms()
    {
        switch (_currentLevel)
        {
            case Constants.MOVEMENT_TUTORIAL:
                GameTutorial.setTutorialIndex(0);
                return new int[] {0, 1};
            case Constants.SHAPE_TUTORIAL:
                GameTutorial.setTutorialIndex(1);
                return new int[] { 0, 2 };
            case Constants.COLOR_TUTORIAL:
                GameTutorial.setTutorialIndex(5);
                return new int[] { 0, 3 };
            case Constants.DEFAULT_LEFT_TUTORIAL:
                GameTutorial.setTutorialIndex(7);
                return new int[] { 0, 4 };
            case Constants.LOCK_OBSTACLE_TUTORIAL:
                GameTutorial.setTutorialIndex(8);
                return new[] { 0, 5 };
            case Constants.COINS_TUTORIAL:
                GameTutorial.setTutorialIndex(12);
                return new[] { 0, 6, 7 };
            case Constants.BOUNCE_TUTORIAL:
                GameTutorial.setTutorialIndex(15);
                return new[] { 0, 8 };
            case Constants.HEALTH_TUTORIAL:
                GameTutorial.setTutorialIndex(17);
                return new[] { 0, 9, 10 };
            case Constants.EASY1:
                return new int[] { 0, 1, 2, 3, 12 };
            case Constants.EASY2:
                return new int[] { 0, 2, 3, 4, 12 };
            case Constants.EASY3:
                return new int[] { 0, 3, 4, 5, 12 };
            case Constants.MEDIUM1:
                return new int[] { 0, 1, 2, 6, 7, 12 };
            case Constants.MEDIUM2:
                return new[] { 0, 2, 3, 7, 8, 12 };
            case Constants.MEDIUM3:
                return new[] { 0, 3, 4, 5, 6, 7, 8, 12 };
            case Constants.HARD1:
                return new[] { 0, 2, 3, 9, 10, 12 };
            case Constants.HARD2:
                return new[] { 0, 1, 4, 5, 7, 10, 11, 12 };
            case Constants.HARD3:
                 return new[] { 0, 6, 7, 8, 9, 10, 11, 12 };
            case Constants.ENDLESS:
                return new int[] { };
        }

        return new int[] { };
    }

    public static void SetCurrentLevel(string level)
    {
        _currentLevel = level;
    }
}