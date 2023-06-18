using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor_Stage : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
   public static bool[] BoxCheak= new bool[4];

    private void Update()
    {
        if (BoxCheak[0] && BoxCheak[1] && BoxCheak[2] && BoxCheak[3])
        {
            animator.SetBool("DoorCheak", true);
        }
        else
        {
            animator.SetBool("DoorCheak", false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))    //박스가 있는지 체크
        {
            BoxCheak[0] = true;
        }
        if (other.gameObject.CompareTag("Box2"))    //박스가 있는지 체크
        {
            BoxCheak[1] = true;
        }
        if (other.gameObject.CompareTag("Box3"))    //박스가 있는지 체크
        {
            BoxCheak[2] = true;
        }
        if (other.gameObject.CompareTag("Box4"))    //박스가 있는지 체크
        {
            BoxCheak[3] = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))    //박스와 충돌이 안할때 체크
        {
            BoxCheak[0] = false;
        }
        if (other.gameObject.CompareTag("Box2"))    //박스와 충돌이 안할때 체크
        {
            BoxCheak[1] = false;
        }
        if (other.gameObject.CompareTag("Box3"))    //박스와 충돌이 안할때 체크
        {
            BoxCheak[2] = false;
        }
        if (other.gameObject.CompareTag("Box4"))    //박스와 충돌이 안할때 체크
        {
            BoxCheak[3] = false;
        }
    }
}
