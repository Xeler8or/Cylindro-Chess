public static class Constants
{
    public enum Color
    {
        Red,
        Blue,
        Green,
        Yellow,
        Black
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

    public const string COLOR_CHANGE =
        "The player has a color which helps him pass through obstacles of the same color.\nColor of the player changes at regular intervals.";

    public const string LOCK_TUTORIAL =
        "The game consists of a Lock obstacles, for which you need to perform actions available on top of the lock.";

    public const string AUTOMATIC_RIGHT_SECTION =
        "There is a section in the game where the player moves right by default.";

    public const float INITIAL_PLAYER_SPEED = 10f;
}
