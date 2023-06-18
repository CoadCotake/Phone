using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Phone : MonoBehaviour
{
    public static Vector3 pos= new Vector3(0,0,0);

    // Update is called once per frame
    void Update()
    {
        pos = this.transform.position;      //위치전송
        if (Input.GetKey(KeyCode.F))      //순간이동
        {
            Player.shotCheak = false;
            Destroy(this.gameObject);
        }
        if (Input.GetKey(KeyCode.G))      //순간이동
        {
            if (Player.ItemMoveCheak == true)
            {
                Player.shotCheak = false;
                Destroy(this.gameObject);
                Player.ItemMoveCheak = false;
                
            }
        }
    }
 
    

    private void OnCollisionEnter(Collision col)    //땅 붙게만드는 함수
    {
        if (col.collider.CompareTag("Ground"))      //땅
        {

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Destroy(gameObject.GetComponent<Rigidbody>());
           
        }
        if (col.collider.CompareTag("wall"))    //벽
        {

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Destroy(gameObject.GetComponent<Rigidbody>());

        }   
        if (col.collider.CompareTag("GroundMove"))      //움직이는바닥
        {   
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.parent = GameObject.Find("GroundMove").transform;
            Destroy(gameObject.GetComponent<Rigidbody>());
            
        }
    }
    
}

