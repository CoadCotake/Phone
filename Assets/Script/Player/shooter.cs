using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class shooter : MonoBehaviour
{
    public GameObject phonePrefab;  //던질 객체

    private float shotSpeed;            //던질힘
    private float shotSpeedlimit=1000;  //던질힘 제한
    public static int shotlimit = 0;    //총알갯수
    public Text shotcount;              //총알갯수보여주는
    public Text phonemove;              //이동가능한지 보여주는
    public Text Power;
    public bool shotcheak = true;       //던질수 있는지 체크
    public static bool resumecheak;     //차징체크(클릭하여 일시정지풀때 쏘지 않도록 할때도 사용);
    bool a = false;
    public AudioSource audio;   //던질때 나는 효과음

    private void Start()
    {
        shotlimit = 0;
        shotcheak = true;
        resumecheak = true;
    }

    void Update()
    {
        Power.text = "Power: " + shotSpeed;
        if (Player.shotCheak == false)
        {
            if (shotlimit > 0)
            {
                if (GameSystem.IsPause == true)
            {
                if (Input.GetButton("Fire1"))        //차징
                {

                    if (shotSpeed < shotSpeedlimit)
                    {
                        shotSpeed += 20;
                        resumecheak = false;
                    }
                }
            }

           
                if (resumecheak == false)
                {
                    if (Input.GetButtonUp("Fire1"))     //발사
                    {
                        Shot();
                        shotSpeed = 0;
                        shotlimit--;
                        phonemove.text = "Teleportation: yes";
                        shotcount.text = "ShotCount: " + shotlimit;
                        Player.shotCheak = true;

                    }
                }
            }
        }
    }

    public void Shot()
    {
        // 프리팹에서 phone 오브젝트를 생성
        audio.Play();
        GameObject phone = (GameObject)Instantiate(
        phonePrefab,
        transform.position,
        Quaternion.identity
      );

        // 던진다.
        Rigidbody candyRigidBody = phone.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotSpeed);
    }
}

