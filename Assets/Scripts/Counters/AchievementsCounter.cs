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
                text.text += e.name + "\n";
            }
            StatsObject.dataUpdated += UpdateCounter;
        }

        private void UpdateCounter()
        {
            foreach (var e in statsObject.Achievements)
            {
                text.text += e.name + "\n";
            }
        }
    }
}