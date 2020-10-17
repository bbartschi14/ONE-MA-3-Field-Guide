using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScanAnimation : MonoBehaviour
{
    public GameObject head;
    public GameObject laser;
    private IEnumerator currentCoroutine;
    private IEnumerator currentCoroutine2;


    private Quaternion origRot;
    private Quaternion origRotLaser;



    void Awake()
    {
        origRot = head.transform.rotation;
        origRotLaser = laser.transform.rotation;
    }
    void OnDisable(){
        head.transform.rotation = origRot;
        laser.transform.rotation = origRotLaser;
    }
    void OnEnable() {
        currentCoroutine = PlayAnim();
        StartCoroutine(currentCoroutine);
        currentCoroutine2 = MoveLaser();
        StartCoroutine(currentCoroutine2);

    }

    IEnumerator PlayAnim() {
        for (int i=0; i<1440; i++) {
            head.transform.Rotate(0.0f, 0.0f, 0.25f, Space.Self);
            yield return null;
        }
        yield return PlayAnim();
    }

    IEnumerator MoveLaser() {
        float delta = -1.0f;
        for (int i=0; i<100; i++) {
            laser.transform.Rotate(delta,0.0f,0.0f, Space.Self);
            yield return null;
        }
        for (int i=0; i<100; i++) {
            laser.transform.Rotate(-delta,0.0f,0.0f, Space.Self);
            yield return null;
        }
        yield return MoveLaser();
    }
}
