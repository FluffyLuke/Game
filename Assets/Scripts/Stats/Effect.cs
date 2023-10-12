using Unity.VisualScripting;
using UnityEngine;

namespace Stats.OtherStats
{
    [CreateAssetMenu(fileName = "Effect", menuName = "ScriptableObjects/Effect", order = 4)]
    public class Effect : ScriptableObject
    {
        private int remainingTime = -1;
        public int duration;
        public int goldIncome;
        public string effectName;
        public int startingActionPoints;

        public bool CheckIfTime(StatsObject stats)
        {
            if (remainingTime == -1)
            {
                remainingTime = duration;
                stats.GoldIncome += goldIncome;
                stats.StartingActionPoints += startingActionPoints;
            }
            if (remainingTime == 0)
            {
                stats.GoldIncome -= goldIncome;
                stats.StartingActionPoints -= startingActionPoints;
                return true;
            }
            remainingTime -= 1;
            return false;
        }
    }
}