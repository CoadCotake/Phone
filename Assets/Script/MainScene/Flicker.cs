using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flicker : MonoBehaviour
{
    public GameObject a;    //깜박임 객체
    bool aa = true;         //bool을 true ,false 반복시키기 위한 bool

    

    
    void Start()
    {
        Screen.SetResolution(1024, 768, true);
        StartCoroutine(Light());
    }

    IEnumerator Light()
    {
        while (true)
        {
            if (aa == true)
            {
                aa = false;
            }
            else aa = true;
            a.SetActive(aa);
            yield return new WaitForSeconds(1);
        }
    }



}
