using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catch : MonoBehaviour
{

    bool itemCheak = false;
    bool[] BoxName = new bool[4];

    //큐브가지고 벽을 뚫을 시도 했을경우 나오는 경고문
    public Text bugtext; 
    public GameObject bug;

    // Update is called once per frame
    void Update()
    {
        if (itemCheak == true)
        {
            if (GameObject.Find("Box").transform.GetComponent<BoxCollider>().isTrigger == false
                && GameObject.Find("Box2").transform.GetComponent<BoxCollider>().isTrigger == false
                && GameObject.Find("Box3").transform.GetComponent<BoxCollider>().isTrigger == false
                && GameObject.Find("Box4").transform.GetComponent<BoxCollider>().isTrigger == false
                )
            {
                if (Input.GetKey(KeyCode.E))
                {
                    if (BoxName[0])
                    {
                        GameObject.Find("Box").transform.parent = transform;
                        GameObject.Find("Box").transform.GetComponent<Rigidbody>().isKinematic = true;
                        GameObject.Find("Box").transform.GetComponent<BoxCollider>().isTrigger = true;
                    }
                    if (BoxName[1])
                    {
                        GameObject.Find("Box2").transform.parent = transform;
                        GameObject.Find("Box2").transform.GetComponent<Rigidbody>().isKinematic = true;
                        GameObject.Find("Box2").transform.GetComponent<BoxCollider>().isTrigger = true;
                    }
                    if (BoxName[2])
                    {
                        GameObject.Find("Box3").transform.parent = transform;
                        GameObject.Find("Box3").transform.GetComponent<Rigidbody>().isKinematic = true;
                        GameObject.Find("Box3").transform.GetComponent<BoxCollider>().isTrigger = true;
                    }
                    if (BoxName[3])
                    {
                        GameObject.Find("Box4").transform.parent = transform;
                        GameObject.Find("Box4").transform.GetComponent<Rigidbody>().isKinematic = true;
                        GameObject.Find("Box4").transform.GetComponent<BoxCollider>().isTrigger = true;
                    }
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.E))
                {
                    if (BoxName[0])
                    {
                        GameObject.Find("Box").transform.parent = null;
                        GameObject.Find("Box").transform.GetComponent<Rigidbody>().isKinematic = false;
                        GameObject.Find("Box").transform.GetComponent<BoxCollider>().isTrigger = false;
                    }
                    if (BoxName[1])
                    {
                        GameObject.Find("Box2").transform.parent = null;
                        GameObject.Find("Box2").transform.GetComponent<Rigidbody>().isKinematic = false;
                        GameObject.Find("Box2").transform.GetComponent<BoxCollider>().isTrigger = false;
                    }
                    if (BoxName[2])
                    {
                        GameObject.Find("Box3").transform.parent = null;
                        GameObject.Find("Box3").transform.GetComponent<Rigidbody>().isKinematic = false;
                        GameObject.Find("Box3").transform.GetComponent<BoxCollider>().isTrigger = false;
                    }
                    if (BoxName[3])
                    {
                        GameObject.Find("Box4").transform.parent = null;
                        GameObject.Find("Box4").transform.GetComponent<Rigidbody>().isKinematic = false;
                        GameObject.Find("Box4").transform.GetComponent<BoxCollider>().isTrigger = false;
                    }
                }
            }
        }
        else
        {
            if (GameObject.Find("Box").transform.GetComponent<BoxCollider>().isTrigger == true
                || GameObject.Find("Box2").transform.GetComponent<BoxCollider>().isTrigger == true
                || GameObject.Find("Box3").transform.GetComponent<BoxCollider>().isTrigger == true
                || GameObject.Find("Box4").transform.GetComponent<BoxCollider>().isTrigger == true
                )
            {
                if (Input.GetKey(KeyCode.E))
                {
                    bug.SetActive(true);
                    bugtext.text = "You tried to pass a wall (Box) !! Restart!";
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Box2")
            || other.gameObject.CompareTag("Box3") || other.gameObject.CompareTag("Box4"))
        {
            itemCheak = true;
            if (other.gameObject.CompareTag("Box"))    //앞에 박스가 있는지 체크
            {
                BoxName[0] = true;
            }
            if (other.gameObject.CompareTag("Box2"))    //앞에 박스가 있는지 체크
            {
                BoxName[1] = true;
            }
            if (other.gameObject.CompareTag("Box3"))    //앞에 박스가 있는지 체크
            {
                BoxName[2] = true;
            }
            if (other.gameObject.CompareTag("Box4"))    //앞에 박스가 있는지 체크
            {
                BoxName[3] = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Box2")
            || other.gameObject.CompareTag("Box3") || other.gameObject.CompareTag("Box4"))
        {
            itemCheak = false;
            if (other.gameObject.CompareTag("Box"))    //앞에 박스가 있는지 체크
            {
                BoxName[0] = false;
            }
            if (other.gameObject.CompareTag("Box2"))    //앞에 박스가 있는지 체크
            {
                BoxName[1] = false;
            }
            if (other.gameObject.CompareTag("Box3"))    //앞에 박스가 있는지 체크
            {
                BoxName[2] = false;
            }
            if (other.gameObject.CompareTag("Box4"))    //앞에 박스가 있는지 체크
            {
                BoxName[3] = false;
            }
        }
    }
}
