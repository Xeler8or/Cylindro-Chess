public static class Constants
{
    public enum Pieaces
    {
        Pawn,
        Knight,
        Rook,
        Queen,
        King
    }

    public enum Color
    {
        Black,
        White
    }

    public static float PLAYER_VELOCITY_Z = 10f;

    public static string UPGRADE_TO_KNIGHT =
        "Great start! You have been upgraded to a Knight.\nCollect another black Knight to upgrade to a Rook.\nHit Spacebar to continue.";
    public static string UPGRADE_TO_ROOK =
        "Great! You have now been upgraded to a Rook.\nCollect another black Rook to upgrade to a Queen.\nHit Spacebar to continue.";
    public static string UPGRADE_TO_QUEEN =
        "Awesome! You have been upgraded to a Queen.\nCollect another black Queen to upgrade to a KING!\nHit Spacebar to continue.";
    public static string UPGRADE_TO_KING =
        "Congratulations! You are now a KING! You will receive double points till you remain KING. " +
        "\nBut hang in there, all the pieces are white. Press E to use powerup.\nHit Spacebar to continue.";

    public static string POWER_UP_USED = "Powerup used, you can pass through all the pieces.";
    public static string END_GAME_SAME_COLOR = 
        "You cannot hit a white piece.";
    public static string END_GAME_HIGHER_POWER = 
        "You cannot hit a black piece of higher power.\nPower Hierarchy: Pawn, Knight, Rook, Queen and King.";
    public static string COLLECT_A_PAWN =
        "Let's go!\nTry collecting a black pawn now.\nHit Spacebar to continue.";
}
