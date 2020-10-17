using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAnimation : MonoBehaviour
{
    public GameObject menu;
    public AnimationCurve animCurve;
    private float frames = 50.0f;

    void OnEnable()
    {
        foreach (Transform child in menu.transform) {
            child.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        }
        StartCoroutine(StartAnim());
    }

    IEnumerator StartAnim() {
        foreach (Transform child in menu.transform) {
            StartCoroutine(FadeIn(child));
            yield return new WaitForSeconds(.15f);
        }
        yield return null;
    }

    IEnumerator FadeIn(Transform toAnimate) {

        Vector3 target = toAnimate.position;
        Vector3 offset = new Vector3(0.0f, 60.0f, 0.0f);
        toAnimate.Translate(offset);
        Vector3 origin = toAnimate.position;


        toAnimate.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        for (int i = 0; i < frames+1; i++) {
            float value = animCurve.Evaluate(i/frames);
            toAnimate.position = Vector3.Lerp(origin, target, value);
            toAnimate.gameObject.GetComponent<CanvasGroup>().alpha += 1.0f/frames;
            yield return null;
        }
        yield return null;
    }
}
