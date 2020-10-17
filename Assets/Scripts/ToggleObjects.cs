using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleObjects : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;

    private GameObject go3;
    public GameObject go4;
    public string text1;
    public string text2;

    
    public void SwitchActive() {
        if (go1.activeSelf) {
            go2.SetActive(true);
            go1.SetActive(false);
            if (go4.activeSelf) {
                UseButton();
            }
            
            go3 = GameObject.FindWithTag("Close");
            go3.GetComponent<Button>().interactable = false;
            
        }
        else {
            go1.SetActive(true);
            go2.SetActive(false);
            
            
            go3 = GameObject.FindWithTag("Close");
            go3.GetComponent<Button>().interactable = true;
            
        }
    }

    public void ChangeButtonText(GameObject button){
        string text = button.GetComponentInChildren<Text>().text;
        Debug.Log(text);

        if (text != text1) {
            button.GetComponentInChildren<Text>().text = text1;
        } else {
            button.GetComponentInChildren<Text>().text = text2;
        }
    }

    private GameObject buttonToUse; 
    public string tag;
    public void UseButton(){
        buttonToUse = GameObject.FindWithTag(tag);

        buttonToUse.GetComponent<Button>().onClick.Invoke();
        //buttonToUse.SetActive(false);
    }
}
