using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Rotate : MonoBehaviour{
    public enum Dir {Right, Left, Up, Down};
    [SerializeField] private float rotateSpeed;
    [SerializeField] Dir rotateDir;

    Vector3 rotateValue = new Vector3(10, 0, 0);
    Quaternion targetRotate;

    void Start() {
        if(rotateSpeed == 0) rotateSpeed = 5;
        InitRotate();
        StartCoroutine(StartAlter());
        
    }

    void InitRotate() {
        switch(rotateDir) {
            case Dir.Right:
                targetRotate = Quaternion.Euler(179, 0, 0);
                break;
            case Dir.Left:
                targetRotate = Quaternion.Euler(270, 0, 0);
                break;
            case Dir.Up:
                targetRotate = Quaternion.Euler(0, 0, 179);
            break;
            case Dir.Down:
                targetRotate = Quaternion.Euler(0, 0, 180);
            
            break;
        }
    }

    IEnumerator StartAlter() {
        Quaternion previousRotate = this.transform.rotation;
        while(true) {
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotate, rotateSpeed);
            yield return new WaitForSeconds(0.05f);
            if(transform.rotation == targetRotate) {
                //this.transform.rotation = Quaternion.Euler(previousRotate.eulerAngles);
                StageAlter.instance.Invert();
                yield break;
            }
        }
    }
    void Update()
    {

    }

}
