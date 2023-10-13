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
        public Sprite background;
        public StatChanges option1;
        public StatChanges option2;
        public bool ifTwoOptions;

        public bool UpdateStats(StatsObject stats, int round, List<Events.Event> events, int option)
        {
            var chosenOption = option == 1 ? option1 : option2;
            var ifUpdated = chosenOption.UpdateStats(stats, events);
            return ifUpdated;
        }

        public bool IfOption()
        {
            if (ifTwoOptions)
            {
                return true;
            }

            return false;
        }

        public StatChanges GetOption(int option)
        {
            if (option == 1)
            {
                return option1;
            }
            return option2;
        }
    }
}