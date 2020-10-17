using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanAnimation : MonoBehaviour
{
    
    public GameObject cam;

    public Transform center;
    private Transform camTransform;

    private Quaternion origRot;
    private Vector3 origPos;
    public float radius = 6.0f;
    public Vector3 axis;
    public float angle = 1.0f;

    public GameObject toSpawn;
    public Transform childTransform;
    public Transform picContainer;
    private IEnumerator currentCoroutine;

    private int count = 0;

    // Start is called before the first frame update
    void Awake()
    {
        camTransform = cam.transform;
        camTransform.position = center.position;
        camTransform.rotation = center.rotation;
        camTransform.Translate(radius,0,0);
        origPos = camTransform.position;
        origRot = camTransform.rotation;
        
    }

    void OnDisable()
    {   
        camTransform.position = origPos;
        camTransform.rotation = origRot;
        foreach(Transform child in picContainer) {
            Destroy(child.gameObject);
        }
    }

    void OnEnable() {
        currentCoroutine = TakePicture(camTransform, center, axis, angle, count);
        StartCoroutine(currentCoroutine);
    }
   

   
    IEnumerator TakePicture(Transform camera, Transform center, Vector3 axis, float angle, int count) {
        for (int i = 0; i < 36; i++){
            camera.RotateAround(center.position, axis, angle);
            yield return null;
        }
        count++;

        GameObject tmp = Instantiate(toSpawn);
        tmp.transform.parent = picContainer;
        tmp.transform.position = childTransform.position;
        tmp.transform.rotation = childTransform.rotation;
        tmp.transform.Translate(0,0,-0.5f);
        if (count < 10) {
            

            yield return new WaitForSeconds(.2f);
            yield return TakePicture(camera, center, axis, angle, count);
        }
        else {
            yield return null;
        }

    }
}
