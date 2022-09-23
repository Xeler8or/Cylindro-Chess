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
        "Great start! You have been upgraded to a Knight.\nCollect another black Knight to upgrade to a Rook.";
    public static string UPGRADE_TO_ROOK =
        "Great! You have now been upgraded to a Rook.\nCollect another black Rook to upgrade to a Queen.";
    public static string UPGRADE_TO_QUEEN =
        "Awesome! You have been upgraded to a Queen.\nCollect another black Queen to upgrade to a KING!";
    public static string UPGRADE_TO_KING =
        "You are now a KING!\nHang in there, try now to hit any white pieces.";
    public static string END_GAME_SAME_COLOR = 
        "You cannot a white piece.";
    public static string END_GAME_HIGHER_POWER = 
        "You cannot hit a black piece of higher power.\nPower Hierarchy: Pawn, Knight, Rook, Queen and King.";
}
