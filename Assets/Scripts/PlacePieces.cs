using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePieces : MonoBehaviour
{
    private List<Transform> childrenObjects = new List<Transform>();
    private List<int> childIndices = new List<int>();
    private float height = 1.5f;
    private int frames = 30;
    public Transform parent;
    // Start is called before the first frame update
    // void Awake() {
        
    // }

    void OnEnable()
    {   
        int i = 0;
        foreach (Transform child in parent) {
            childrenObjects.Add(child);
            if (Random.value > 0.7f) {
                childIndices.Add(i);
            }
            i++;
        }
        Debug.Log(childIndices.Count);
        for (int j = 0; j < childIndices.Count; j++) {
           //childrenObjects[childIndices[j]].Translate(0,0,height);
           childrenObjects[childIndices[j]].gameObject.SetActive(false); 
        }
        StartCoroutine(RunAnim());
    }

    void OnDisable(){
        
        StopAllCoroutines();
        foreach (Transform child in parent) {
            child.gameObject.SetActive(true);
            child.localPosition = new Vector3(0,0,0);
        }   
        childrenObjects = new List<Transform>();
        childIndices = new List<int>();
    }

    IEnumerator RunAnim() {
        for (int j = 0; j < childIndices.Count; j++) {
           childrenObjects[childIndices[j]].gameObject.SetActive(true);
           StartCoroutine(Place(childrenObjects[childIndices[j]]));
           yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator Place(Transform obj) {
        float origZ = obj.position.z;
        obj.Translate(0,0,height);
        for (int i = 0; i < frames; i++) {
            obj.Translate(0,0,-(height)/frames);
            yield return null;
        }
    }
}
