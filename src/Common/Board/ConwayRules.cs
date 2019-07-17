
namespace Common.Board
{
    public class ConwayRules
    {
        public ConwayRules(int minCreate = 3, int maxCreate = 3, int minContinue = 2, int maxContinue = 3)
        {
            this.minCreate = minCreate;
            this.maxCreate = maxCreate;
            this.minContinue = minContinue;
            this.maxContinue = maxContinue;
        }
        public int minCreate { get; set; }
        public int maxCreate { get; set; }
        public int minContinue { get; set; }
        public int maxContinue { get; set; }
    }
}