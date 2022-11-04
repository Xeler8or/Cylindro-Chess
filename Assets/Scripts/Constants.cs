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

    public const string COLLECT_COINS_FOR_POWERUPS =
        "Collects coins to buy powerups during the game.";

    public const string COLLECT_RAINBOW_POWERUP =
        "This is a rainbow powerup. Once you collect this, you can pass through any color obstacle irrespective of player color.\n2 Coins = 1 Rainbow powerup.";

    public const string COLLECT_SLOWDOWN_POWERUP =
        "This is the showdown powerup. Once you collect his, the speed of the player reduces.\n2 Coins = 1 Slowdown powerup.";

    public const string BOUNCE_OBSTACLE =
        "This is a bounce obstacle, you need to bounce your way through the obstacle. Try it!";

    public const string HEALTH =
        "These are healths.\n You need these to go to the outer cylinder.\nOn the outer cylinder the points are double.";

    public const string PORTALS =
        "These are portal, hit these and you will move between inner and outer cylinders.";

    public const string UP_SIDE_DOWN =
        "Wohoo! Welcome to the upside-down.\nYou get double points here but you also need to constantly collect health to stay here.";

    public const string TURN_RIGHT_INSIDE_BOUNCE =
        "Right after entering, turn right to bounce your way out. If you don't the game ends!";

    public const float INITIAL_PLAYER_SPEED = 10f;

    public const float HEALTH_TIMER = 5f;

    public const float PLAYER_MAX_SPEED = 30f;
    
    public const string MOVEMENT_TUTORIAL = "MOVEMENT";
    
    public const string SHAPE_TUTORIAL = "SHAPE";
    
    public const string COLOR_TUTORIAL = "COLOR";
    
    public const string DEFAULT_LEFT_TUTORIAL = "DEFAULT_LEFT";
    
    public const string LOCK_OBSTACLE_TUTORIAL = "LOCK";
    
    public const string COINS_TUTORIAL = "COINS";
    
    public const string BOUNCE_TUTORIAL = "BOUNCE";
    
    public const string HEALTH_TUTORIAL = "HEALTH";

    public const string ENDLESS = "ENDLESS";
}
