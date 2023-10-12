using System.Collections.Generic;
using Stats.OtherStats;
using UnityEngine;
using UnityEngine.UI;

namespace Events
{
    [CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 3)]
    public class Event : ScriptableObject
    {
        public string eventText;
        public string eventDescription;
        public int whenHappensRound;
        public Image background;
        public StatsObject.StatChanges option1;
        public StatsObject.StatChanges option2;

        public bool UpdateStats(StatsObject stats, int round, List<Events.Event> events, int option)
        {
            var chosenOption = option == 1 ? option1 : option2;
            var ifUpdated = chosenOption.UpdateStats(stats, events);
            return ifUpdated;
        }

        public bool IfOption()
        {
            if (option2 != null && option1 != null)
            {
                return true;
            }

            return false;
        }

        public StatsObject.StatChanges GetOption(int option)
        {
            if (option == 1)
            {
                return option1;
            }
            return option2;
        }
    }
}