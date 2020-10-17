using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextController : MonoBehaviour
{
    private List<GameObject> texts = new List<GameObject>();
    private List<GameObject> textboxes = new List<GameObject>();

    private List<GameObject> buttons = new List<GameObject>();
    public GameObject textParent;
    public GameObject textboxParent;

    public GameObject buttonParent;
    private int textIndex = 0;
    void Start(){
        foreach (Transform child in textParent.transform) {
            texts.Add(child.gameObject);
        }
        foreach (Transform child in buttonParent.transform) {
            buttons.Add(child.gameObject);
        }
        foreach (Transform child in textboxParent.transform) {
            textboxes.Add(child.gameObject);
        }

        for (int i=0;i<texts.Count;i++){
            if (i==0) {
                texts[i].SetActive(true);
            } else {
                texts[i].SetActive(false);

            }
        }
    }

    
    
    public void AdvanceText(){
        if (textIndex == texts.Count-1){
            textIndex = 0;
        } else {
            textIndex++;
        }
        for (int i=0;i<texts.Count;i++){
            if (i==textIndex) {
                texts[i].SetActive(true);
                textboxes[i].SetActive(true);
                buttons[i].SetActive(true);
            } else {
                texts[i].SetActive(false);
                buttons[i].SetActive(false);
                textboxes[i].SetActive(false);
            }
        }
    }

    public void BackUpText(){
        if (textIndex == 0){
            textIndex = texts.Count-1;
        } else {
            textIndex--;
        }
        for (int i=0;i<texts.Count;i++){
            if (i==textIndex) {
                texts[i].SetActive(true);
                buttons[i].SetActive(true);
                textboxes[i].SetActive(true);

            } else {
                texts[i].SetActive(false);
                buttons[i].SetActive(false);
                textboxes[i].SetActive(false);
            }
        }
    }

}
