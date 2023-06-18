using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //움직임 및 점프
    public static int jumpcount = 1;
    public Rigidbody play;

    // 마우스 감도, 상하 범위
    public float mouseSensitivity = 2f;
    float UpRange = 90;
    float DownRange = 90;

    //속도
    private Vector3 speed;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5;
    public float downSpeed = 5;
    private float forwardSpeed;
    private float sideSpeed;

    //회전
    private float RotateLR;
    private float RotateUD;
    private float verticalRotation = 0f;

    //총 및 UI
    public static bool shotCheak = false;   //내가 쐈을시
    public Text phonemove;  //이동가능여부
    public Text shotcount;  //phone 갯수
    public Text Getitem;    //이동시킬 아이템

    public static bool ItemMoveCheak=false;   //아이템 이동가능 체크
    GameObject item;    //이동시킬 객체
    public Animator animator;   //움직임 애니메이션

    public string SceneAfterName;    //다음 스테이지 제목
    public string DieSceneName; //현재스테이지 (죽을때 사용)
    public AudioSource audio;   //텔레포트 효과음
    public AudioSource move;   //발소리 
    bool movelimt; //무한반복제어

    // Use this for initialization
    void Start()
    {
        ItemMoveCheak = false;
        shotCheak = false;
        movelimt = true;
        
    }

    // Update is called once per frame
    void Update()
    {
       
            if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)) //애니메이션
        {
            if (move.isPlaying) {   
            }
            else move.Play();
            animator.SetBool("runcheak", true);
        }
        else { animator.SetBool("runcheak", false); }

        Moving();   //움직임
        Rotating(); //시점회전

        if (shotCheak == true)          //순간이동
        {
            if (Input.GetKey(KeyCode.F))
            {
                audio.Play();
                this.transform.position = Phone.pos;
                phonemove.text = "Teleportation: no";
            }

            if (Input.GetKey(KeyCode.G))
            {
               
                if (ItemMoveCheak == true)
                {
                    audio.Play();
                    item.transform.position = Phone.pos;
                    phonemove.text = "Teleportation: no";
                }
            }
        }
            if (this.transform.position.y < -10)
            {
                SceneManager.LoadScene(DieSceneName);
            }
        
    }


    // Player x축, z축 움직임을 담당
    void Moving()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Wallcheak.wallcheak == false)
            {
                this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))    //점프
        {
            if (jumpcount > 0)
            {
                jumpcount -= 1;
                play.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                transform.parent = null;
            }
        }
    }


    // Player의 회전을 담당
    void Rotating()
    {
        //좌우 회전
        RotateLR = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, RotateLR, 0f);

        //상하 회전
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -UpRange, DownRange);
        
        // Main 카메라
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("item"))    //phone을 먹을때
        {
            shooter.shotlimit += 1;
            shotcount.text = "ShotCount: " + shooter.shotlimit;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Box"))     //이동시킬 아이템 체크
        {
            ItemMoveCheak = true;
            Getitem.text = "MoveObject : Box";
            item = item = GameObject.Find("Box");
        }
        if (other.gameObject.CompareTag("Box2"))     //이동시킬 아이템 체크
        {
            ItemMoveCheak = true;
            Getitem.text = "MoveObject : Box2";
            item = item = GameObject.Find("Box2");
        }
        if (other.gameObject.CompareTag("Box3"))     //이동시킬 아이템 체크
        {
            ItemMoveCheak = true;
            Getitem.text = "MoveObject : Box3";
            item = item = GameObject.Find("Box3");
        }
        if (other.gameObject.CompareTag("Box4"))     //이동시킬 아이템 체크
        {
            ItemMoveCheak = true;
            Getitem.text = "MoveObject : Box4";
            item = item = GameObject.Find("Box4");
        }

        if (other.CompareTag("GroundMove"))
        {
            //transform.parent = GameObject.Find("GroundMove").transform; //만약 움직이는 블럭에 있으면 부모로 지정
            Player.jumpcount = 1;
        }
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneAfterName);
        }
    }
    bool aa = false;
    void run()
    {
        movelimt = true;
    }
    
}



