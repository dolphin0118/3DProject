using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlphaChage : MonoBehaviour {
    Renderer renderer;
    void Start() {
        renderer = this.GetComponent<Renderer>();
    }

    void FadeIn(){
        Color c = renderer.material.color;
        c.a = 1;
        renderer.material.color = c;
    }

    void FadeOut() {
        Color c = renderer.material.color;
        c.a = 0;
        renderer.material.color = c;
    }

    void Update(){
        if(StageAlter.isDarkness) FadeOut();
        else FadeIn();
    }
}

