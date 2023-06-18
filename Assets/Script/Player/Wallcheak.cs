using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallcheak : MonoBehaviour
{
    public static bool wallcheak = false;
    private void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))    //앞에 벽이 있는지 체크
        {
            wallcheak = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))    //벽과 충돌이 안할때 체크
        {
            wallcheak = false;
        }
    }
}
