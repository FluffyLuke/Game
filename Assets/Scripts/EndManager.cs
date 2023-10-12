using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class EndManager : MonoBehaviour
    {
        public TMP_Text text;
        public StatsObject statsObject;
        public void EndGame()
        {
            Application.Quit(); 
        }

        public void Start()
        {
            foreach (var e in statsObject.Achievements)
            {
                text.text += e.longDescription + "\n";
            }
        }
    }
}