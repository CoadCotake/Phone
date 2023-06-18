using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpcheak : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            Player.jumpcount = 1;
        }
       
    }
}
