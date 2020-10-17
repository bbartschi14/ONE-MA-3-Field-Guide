using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAnimation : MonoBehaviour
{
    public GameObject toAnimate;
    private Vector3 origPos;
    private float vel = 0.1f;
    private float maxDelta = .05f;

    private void Awake(){
        origPos = toAnimate.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(toAnimate.transform.position.x-origPos.x) > maxDelta){
            vel = -vel;
        }
        toAnimate.transform.Translate(Vector3.right * Time.deltaTime * vel);
    }

    private void OnDisable(){
        toAnimate.transform.position = origPos;
    }
}
