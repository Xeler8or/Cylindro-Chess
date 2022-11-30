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
        "Move Left: A/Left\nMove Right: D/Right";

    public const string CHANGE_SHAPE =
        "Q: Shape Change\nAvailable shapes are Sphere, Cube and Triangle.";

    public const string CHANGE_TO_CIRCLE =
        "Change shape to a circle to pass through.";
    
    public const string CHANGE_TO_RECTANGLE =
        "Change shape to a rectangle to pass through.";
    
    public const string CHANGE_TO_TRIANGLE =
        "Change shape to a triangle to pass through.";

    public const string COLOR_CHANGE =
        "The player can pass through obstacles of the same color.";

    public const string PASS_THROUGH_RED_PORTION =
        "Pass through the section where the color is the same as the player.";

    public const string LOCK_TUTORIAL =
        "This is a lock obstacle.\nTo clear this, remember the pattern to perform shown on top.";

    public const string AUTOMATIC_RIGHT_SECTION =
        "This section moves left by default.\nThis is indicated by the arrows on the ground.";

    public const string ROTATE_RIGHT_360 =
        "When the lock appears, first rotate 2 right 360 degree turns.";

    public const string ROTATE_LEFT_360 =
        "After performing 2 right 360 turns, you need to perform 2 left 360 degree turns";

    public const string PERFORM_ON_LOCK =
        "Now when the lock appears, you need to perform 2 right 360 degree turns and 2 left 360 degree turns with respect to the line.";

    public const string COLLECT_COINS_FOR_POWERUPS =
        "Collects coins to buy powerups during the game.";

    public const string COLLECT_RAINBOW_POWERUP =
        "Rainbow Powerup: Pass through any colored obstacle.\n2 Coins = 1 Rainbow powerup.";

    public const string COLLECT_SLOWDOWN_POWERUP =
        "Slowdown Powerup: Slows the player down.\n2 Coins = 1 Slowdown powerup.";

    public const string BOUNCE_OBSTACLE =
        "This is a bounce obstacle, you need to bounce your way through the obstacle. Try it!";

    public const string HEALTH =
        "Health: These help you stay on the outer cylinder.\nPoints are 2x on the outer cylinder.";

    public const string PORTALS =
        "Portals: These help move between outer and inner cylinder";

    public const string UP_SIDE_DOWN =
        "Wohoo! Welcome to the upside-down.\nYou get double points here but you also need to constantly collect health to stay here.";

    public const string TURN_RIGHT_INSIDE_BOUNCE =
        "Right after entering, turn right to bounce your way out. If you don't the game ends!";

    public const float INITIAL_PLAYER_SPEED = 10f;

    public const float HEALTH_TIMER = 8f;

    public const float PLAYER_MAX_SPEED = 25f;
    
    public const string MOVEMENT_TUTORIAL = "MOVEMENT";
    
    public const string SHAPE_TUTORIAL = "SHAPE";
    
    public const string COLOR_TUTORIAL = "COLOR";
    
    public const string DEFAULT_LEFT_TUTORIAL = "DEFAULT_LEFT";
    
    public const string LOCK_OBSTACLE_TUTORIAL = "LOCK";
    
    public const string COINS_TUTORIAL = "COINS";
    
    public const string BOUNCE_TUTORIAL = "BOUNCE";
    
    public const string HEALTH_TUTORIAL = "HEALTH";

    public const string ENDLESS = "ENDLESS";
    
    public const string EASY1 = "EASY1";
    
    public const string EASY2 = "EASY2";
    
    public const string EASY3 = "EASY3";
    
    public const string MEDIUM1 = "MEDIUM1";
    
    public const string MEDIUM2 = "MEDIUM2";
    
    public const string MEDIUM3 = "MEDIUM3";
    
    public const string HARD1 = "HARD1";
    
    public const string HARD2 = "HARD2";

    public const string HARD3 = "HARD3";

    public const int CONTINUE_COINS = 10;
}
