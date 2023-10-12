using TMPro;
using UnityEngine;

namespace Counters
{
    public class EffectsCounter : MonoBehaviour
    {
        [ SerializeField ]
        private StatsObject statsObject;
        [ SerializeField ]
        private TMP_Text text;
        private void Start()
        {
            foreach (var e in statsObject.Effects)
            {
                text.text += e.effectName + "\n";
            }
            StatsObject.dataUpdated += UpdateCounter;
        }

        private void UpdateCounter()
        {
            foreach (var e in statsObject.Effects)
            {
                text.text += e.effectName + "\n";
            }
        }
    }
}