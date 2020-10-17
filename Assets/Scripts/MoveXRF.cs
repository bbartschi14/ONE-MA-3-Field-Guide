using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXRF : MonoBehaviour
{
    public GameObject XRF;
    private Vector3 origPos;
    private List<Vector3> positions;
    private int counter = 0;
    private IEnumerator currentCoroutine;

    void Awake() {
        counter = 0;
        positions= new List<Vector3>();
        origPos = XRF.transform.position;
        positions.Add(new Vector3(-1.149f, 2.23f,-1.03f));
        positions.Add(new Vector3(0.055f, 3.47f,-1.03f));
        positions.Add(new Vector3(1.28f, 3.016f,-1.03f));
        positions.Add(new Vector3(1.057f, 1.609f,-1.03f));
        positions.Add(new Vector3(-0.532f, 1.355f,-1.03f));
    }

    void OnDisable() {
        XRF.transform.position = origPos;
        counter = 0;
    }

    void OnEnable() {
        currentCoroutine = ShiftPos();
        StartCoroutine(currentCoroutine);
    }

    IEnumerator ShiftPos() {
        Vector3 origin = XRF.transform.position;
        Vector3 target = positions[counter];
        float frames = 50.0f;
        for (int i = 0; i < frames; i++){
            Vector3 newPos = Vector3.Lerp(origin, target, i/(frames-1));
            XRF.transform.position = newPos;
            yield return null;
        }
        counter++;
        if (counter >= positions.Count) {
            counter = 0;
        }
        yield return new WaitForSeconds(.8f);
        yield return ShiftPos();
    }
}
