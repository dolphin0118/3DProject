using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAlter : MonoBehaviour {
    public static bool isDarkness = true;
    public static StageAlter instance;

    void Awake() {
        if(instance == null) instance = this;
        else return;
    }

    void Update() {
        
    }

    public void Invert() {
        isDarkness = false ? isDarkness = true : isDarkness = false;
    }
}
