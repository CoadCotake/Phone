using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
        public Animator animator;
        // Start is called before the first frame update

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Box"))    //박스가 있는지 체크
            {
                animator.SetBool("DoorCheak", true);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Box"))    //박스와 충돌이 안할때 체크
            {
                animator.SetBool("DoorCheak", false);
            }
        }
}
