using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Counters
{
    public class Popularity : MonoBehaviour
    {
        [ SerializeField ]
        private StatsObject statsObject;
        [ SerializeField ]
        private Slider slider;
        private void Start()
        {
            this.slider.value = statsObject.Popularity;
            StatsObject.dataUpdated += UpdateCounter;
        }

        private void UpdateCounter()
        {
            this.slider.value = statsObject.Popularity;
        }
    }
}