namespace GameZone.Common
{
    public static class ValidationConstants
    {
        // Game
        public const int GameTitleMinLength = 2;
        public const int GameTitleMaxLength = 50;
        public const int GameDescriptionMinLength = 10;
        public const int GameDescriptionMaxLength = 500;
        public const int GameImageUrlMaxLength = 2083;
        public const string GameReleaseDateFormat = "yyyy-MM-dd";

        // Genre
        public const int GenreNameMinLength = 3;
        public const int GenreNameMaxLength = 25;
    }
}
