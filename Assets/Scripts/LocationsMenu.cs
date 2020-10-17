using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationsMenu : MonoBehaviour
{
    public void LoadScene(string SceneName){
        //public string SceneName;
        SceneManager.LoadScene(SceneName);
    }
}
