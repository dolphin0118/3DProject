using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float smoothRotate = 5.0f;
    private Vector3 InitPos;
    private Transform tr;

    void Awake() {
        tr = GetComponent<Transform>();
        InitPos = this.transform.position;
    }

    public void CamMove() {
        tr.position += new Vector3(0, 0, 0.003f);
    }

    void Update() {
        if(InitPos.z + 3 > this.transform.position.z) CamMove();
        float currYAngle = Mathf.LerpAngle(tr.eulerAngles.z, target.eulerAngles.z, smoothRotate * Time.deltaTime);
        Quaternion rot = Quaternion.Euler(0, 0,currYAngle);

        //tr.position = target.position - (rot * Vector3.forward * distance) + (Vector3.up * height);
        //tr.LookAt(target);
    }
}
