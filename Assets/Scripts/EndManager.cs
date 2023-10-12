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
                switch (statsObject.Gold)
                {
                    case > 1000:
                        text.text += "Byles bardzo bogatym czlowiekiem" + "\n";
                        break;
                    case < 301:
                        text.text += "Byles biednym czlowiekiem" + "\n";
                        break;
                }

                text.text += statsObject.Popularity switch
                {
                    > 80 => "Byles bardzo popularnym i szanowanym artystą!" + "\n",
                    > 40 => "Byles dosc popularnym tworca swoich czasow!" + "\n",
                    _ => "Nie nalezales do popularnych tworcow" + "\n"
                };
            }
        }
    }
}