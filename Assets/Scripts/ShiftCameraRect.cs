using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiftCameraRect : MonoBehaviour
{
    private bool cameraShrunk;
    public GameObject textPanel;
    public GameObject textControl;
    public GameObject button1;
    public GameObject button2;

    public bool hideObject;
    public void ToggleInteractive(){
        button1.GetComponent<Button>().interactable = !button1.GetComponent<Button>().interactable;
        button2.GetComponent<Button>().interactable = !button2.GetComponent<Button>().interactable;
    }
    public void CameraEvent() {
        if (textPanel.activeSelf) {
            StartCoroutine(GrowCamera());
            textPanel.SetActive(false);
            if (hideObject){
                textControl.SetActive(false);
            }


        } else {
            StartCoroutine(ShrinkCamera());     
            textPanel.SetActive(true);       
            if (hideObject){
                textControl.SetActive(true);
            }

        }
        
    }

    IEnumerator ShrinkCamera(){
        for (int i=0;i<30;i++){
            Camera.main.rect = new Rect (0,0,1-(.4f*i/30),1);
            yield return null;
        }
    }

    IEnumerator GrowCamera(){
        for (float j=0;j<30;j++){
            Camera.main.rect = new Rect (0,0,.6f+(j/30*.4f),1);
            yield return null;
        }
    }


}
