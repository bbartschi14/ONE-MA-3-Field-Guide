using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransition : MonoBehaviour
{
    public GameObject menuOff;
    public GameObject menuOn;
    // public Transform ripple;

    private float frames = 12.0f;

    // private Vector2 sizeChange = new Vector2(3.0f,2.5f);
    // private Vector2 originalSize;

    // void Start() {
    //     RectTransform rt = (RectTransform)ripple;
    //     originalSize = rt.sizeDelta;
    // }
    // void OnDisable() {
    //     RectTransform rt = (RectTransform)ripple;
    //     rt.sizeDelta = originalSize;
    //     ripple.gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
    // }
    public void StartTransition(Transform animated) {
        StartCoroutine(HandleTransition(animated));
    }

    IEnumerator HandleTransition(Transform animated) {
        // StartCoroutine(HandleRipple());
        foreach (Transform child in animated) {
            StartCoroutine(FadeOut(child));
            yield return new WaitForSeconds(.05f);
        }            
        yield return new WaitForSeconds(.35f);

        menuOn.SetActive(true);
        menuOff.SetActive(false);
    }

    IEnumerator FadeOut(Transform toAnimate) {
        for (int i = 0; i < frames+1; i++) {
            toAnimate.gameObject.GetComponent<CanvasGroup>().alpha -= 1.0f/frames;
            
            yield return null;
        }
    }

    // IEnumerator HandleRipple() {
    //     RectTransform rt = (RectTransform)ripple;

    //     ripple.gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
    //     for (int i = 0; i < frames+1; i++) {
    //         rt.sizeDelta += sizeChange;
    //         yield return null;
    //     }
    // }

      // IEnumerator MenuChange(Transform go) {
    //     Vector3 offset = new Vector3(0.0f, 30.0f, 0.0f);
    //     Vector3 origin = go.position;
    //     Vector3 target = origin + offset;
    //     for (int i = 0; i < frames+1; i++) {
    //         float value = animCurve.Evaluate(i/frames);
    //         go.position = Vector3.LerpUnclamped(origin, target, value);
    //         yield return null;
    //     }
    //     yield return new WaitForSeconds(.1f);
    //     menuOn.SetActive(true);
    //     menuOff.SetActive(false);
    // }

}
