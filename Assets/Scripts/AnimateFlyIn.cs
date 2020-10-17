using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimateFlyIn : MonoBehaviour
{
    public float frames = 35;
    public GameObject parent2;
    public GameObject parent1;

    public AnimationCurve animCurve;
    public GameObject toggleButton;
    public GameObject animationButton;

    public float spawnHeight = 5;
    public float spawnWidth = 5;
    public float spawnLength = 5;
    public float spawnInterval = .01f;
    public bool playOnStart = false;
    private bool hasAnimated = false;
    void Start() {
        if (parent1.activeSelf && playOnStart){
            FlyIn(parent1);
        } else if (parent2.activeSelf && playOnStart) {
            FlyIn(parent2);
        }
        
    }
    public void FlyIn(GameObject parent){
        if (parent.activeSelf){
            toggleButton.GetComponent<Button>().interactable = false;
            animationButton.GetComponent<Button>().interactable = false;
            Debug.Log("Called");
            foreach (Transform child in parent.transform) {
                child.gameObject.SetActive(false);
            }
        StartCoroutine(CallObjects(parent));
        }
        
    }

    IEnumerator CallObjects(GameObject parent){
        foreach (Transform child in parent.transform) {
            child.gameObject.SetActive(true);
            Vector3 target = child.position;
            /* Rectangular Generation */
            Vector3 origin = new Vector3(Random.Range(-spawnWidth/2,spawnWidth/2),spawnHeight,Random.Range(-spawnLength/2,spawnLength/2));

            /* Use for spherical generation */
            // Vector3 origin = Random.onUnitSphere*5;
            Quaternion targetRot = child.rotation;
            Quaternion origRot = Random.rotation;
            Vector3 targetScale = child.localScale;
            IEnumerator currentCoroutine = MoveIn(child,origin,target,origRot,targetRot,targetScale);
            StartCoroutine(currentCoroutine);
            yield return new WaitForSeconds(spawnInterval);
        }
        toggleButton.GetComponent<Button>().interactable = true;
        animationButton.GetComponent<Button>().interactable = true;

    }

    IEnumerator MoveIn(Transform child, Vector3 origin, Vector3 target, Quaternion origRot, Quaternion targetRot, Vector3 targetScale){
        child.position = origin;
        child.rotation = origRot;
        child.localScale = new Vector3(0.0f, 0.0f, 0.0f);

        for (int i = 0; i < frames+1; i++){
            float value = animCurve.Evaluate(i/frames);
            child.position = Vector3.Lerp(origin, target, value);
            child.rotation = Quaternion.Lerp(origRot, targetRot, value);
            child.localScale = Vector3.Lerp(new Vector3(0.0f, 0.0f, 0.0f), targetScale, value);
            yield return null;
        }


        
        //Debug.Log("Coroutine Finished");
        
    }

}
