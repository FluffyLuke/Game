using UnityEngine;

namespace Stats.OtherStats
{
    [CreateAssetMenu(fileName = "Achievement", menuName = "ScriptableObjects/Achievement", order = 5)]
    public class Achievement : ScriptableObject
    {
        public string achievementName;
        public string longDescription;
    }
}