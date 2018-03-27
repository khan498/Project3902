
namespace SuperMarioBrothers.GameMetrics
{
    class ScoreInfo
    {
        public int x;
        public int y;
        public int value;
        public int timeValue;

        public ScoreInfo(int x, int y, int value, int time)
        {
            this.x = x;
            this.y = y;
            this.value = value;
            this.timeValue = time;
        }
    }
}
