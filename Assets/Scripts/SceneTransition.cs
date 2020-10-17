using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{

    public void CloseMain(Animator anim) {
        anim.SetBool("Open", !anim.GetBool("Open"));
    }
}
