using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Stats.OtherStats
{
    [CreateAssetMenu(fileName = "StatsChanges", menuName = "ScriptableObjects/StatsChanges", order = 5)]
    public class StatChanges : StatsObject
    {
        public string eventStatChangesText;
        public string buttonText;
        public List<Events.Event> additionalEvents;
        public int costGold;
        public int costActionPoints;
        public string nazwaSceny;
        public bool UpdateStats(StatsObject stats, List<Events.Event> events)
        {
            if (stats.ActionPoints < costActionPoints)
            {
                return false;
            }
            if (stats.Gold < costGold && costGold != 0)
            {
                return false;
            }
            foreach (var e in this.Effects)
            {
                e.remainingTime = -1;
                stats.Effects.Add(e);
            }
            foreach (var e in this.Achievements)
            {
                stats.Achievements.Add(e);
            }
            foreach (var e in additionalEvents)
            {
                events.Add(e);
            }
            stats.Popularity += Popularity;
            stats.Gold += Gold;
            stats.GoldIncome += GoldIncome;
            stats.ActionPoints += ActionPoints;
            stats.ActionPoints -= costActionPoints;
            stats.Gold -= costGold;
            return true;
        }
    }
}