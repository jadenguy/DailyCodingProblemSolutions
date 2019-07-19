
using System;

namespace Common.Board
{
    public class ConwayRules
    {
        public enum LifeAction
        {
            StayDead, StayAlive, Destroy, Create
        }
        public ConwayRules(int minBirth = 3, int maxBirth = 3, int minSurvive = 2, int maxSurvive = 3)
        {
            MinBirth = minBirth;
            MaxBirth = maxBirth;
            MinSurvive = minSurvive;
            MaxSurvive = maxSurvive;
        }
        public int MinBirth { get; set; }
        public int MaxBirth { get; set; }
        public int MinSurvive { get; set; }
        public int MaxSurvive { get; set; }

        public LifeAction Apply(int neighbors, bool amAlive)
        {
            LifeAction action = LifeAction.Destroy;
            if (!amAlive)
            {
                if (neighbors >= MinBirth && neighbors <= MaxBirth)
                {
                    action = LifeAction.Create;
                }
                else { action = LifeAction.StayDead; }
            }
            else
            {
                if (neighbors >= MinSurvive && neighbors <= MaxSurvive)
                {
                    action = LifeAction.StayAlive;
                }
            }
            return action;
        }
    }
}