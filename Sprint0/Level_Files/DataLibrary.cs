namespace SuperMarioBrothers.Level_Files
{
    public class DataLibrary
    {
        private static DataLibrary instance = new DataLibrary();

        private DataLibrary()
        {
        }

        public static DataLibrary Instance
        {
            get { return instance; }
        }
        
        public const int DEFAULT_SIZE = 32;

        public const int BLOCK_SCALE = 1;
        public const int ENEMY_SCALE = 1;
        public const int PLAYER_SCALE = 1;
        public const int ITEM_SCALE = 1;
        public const int PIPE_SCALE = 1;
        public const int CASTLE_SCALE = 1;

        public const int BRICK_BLOCK_OFFSET = 12;
        public const int COIN_OFFSET = 6;

        public const int STAR_MARIO_TIMER = 500;
        public const int PLAYER_MOVEMENT_SPEED = 3;
        public const int DEFAULT_GRAVITY = 1;
        public const int DEFAULT_LIVES = 3;
        public const int ARENA_LIVES = 4;
    }
}
