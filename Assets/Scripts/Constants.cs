public static class Constants
{
    public enum Color
    {
        Red,
        Blue,
        Green,
        Yellow,
        Black,
        Rainbow
    }

    public enum Shapes
    {
        Sphere,
        Cube,
        Cone
    }

    public const string MOVE_LEFT_RIGHT = 
        "Press A/Left Arrow to move left.\nPress D/Right Arrow to move right.";

    public const string CHANGE_SHAPE =
        "Press Q to change the shape of the player.\nAvailable shapes are Sphere, Cube and Triangle.";

    public const string CHANGE_TO_CUBE =
        "Change shape to change to a cube to pass through the next obstacle.";

    public const string COLOR_CHANGE =
        "The player has a color which helps him pass through obstacles of the same color.\nColor of the player changes at regular intervals.";

    public const string PASS_THROUGH_RED_PORTION =
        "Pass through the section where the color is the same as the player.";

    public const string LOCK_TUTORIAL =
        "This is a lock obstacle.\nTo clear this, remember the pattern to perform shown on top.";

    public const string AUTOMATIC_RIGHT_SECTION =
        "There are sections in the game where the player moves right by default. \nThis is indicated by the arrows on the ground.";

    public const string ROTATE_RIGHT_360 =
        "When the lock appears, first rotate 2 right 360 degree turns.";

    public const string ROTATE_LEFT_360 =
        "After performing 2 right 360 turns, you need to perform 2 left 360 degree turns";

    public const string PERFORM_ON_LOCK =
        "Now when the lock appears, you need to perform 2 right 360 degree turns and 2 left 360 degree turns with respect to the line.";

    public const float INITIAL_PLAYER_SPEED = 10f;

    public const float HEALTH_TIMER = 5f;
}
