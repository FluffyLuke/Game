using TMPro;
using UnityEngine;

namespace Counters
{
    public class AchievementsCounter : MonoBehaviour
    {
        [ SerializeField ]
        private StatsObject statsObject;
        [ SerializeField ]
        private TMP_Text text;
        private void Start()
        {
            foreach (var e in statsObject.Achievements)
            {
                text.text += e.achievementName + "\n";
            }
            StatsObject.dataUpdated += UpdateCounter;
        }

        private void UpdateCounter()
        {
            text.text = "";
            foreach (var e in statsObject.Achievements)
            {
                text.text += e.achievementName + "\n";
            }
        }
    }
}