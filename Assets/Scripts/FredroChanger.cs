using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace {
public class FredroChanger : MonoBehaviour {
    [SerializeField] public StatsObject stats;
    public Image oldImage;
    public Sprite z1, z2, z3, z4, z5, z6, z7, z8, z9;
    void Update() {
        if (stats.Age == 29) { oldImage.sprite = z1; };
        if (stats.Age == 35) { oldImage.sprite = z2; };
        if (stats.Age == 41) { oldImage.sprite = z3; };
        if (stats.Age == 47) { oldImage.sprite = z4; };
        if (stats.Age == 53) { oldImage.sprite = z5; };
        if (stats.Age == 59) { oldImage.sprite = z6; };
        if (stats.Age == 65) { oldImage.sprite = z7; };
        if (stats.Age == 71) { oldImage.sprite = z8; };
        if (stats.Age == 77) { oldImage.sprite = z9; };
    }
}
}