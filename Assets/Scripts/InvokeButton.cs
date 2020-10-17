using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InvokeButton : MonoBehaviour
{
    public string tag;
    private GameObject buttonToUse; 
    public void UseButton(){
        buttonToUse = GameObject.FindWithTag(tag);

        buttonToUse.GetComponent<Button>().onClick.Invoke();
        //buttonToUse.SetActive(false);
    }
}
