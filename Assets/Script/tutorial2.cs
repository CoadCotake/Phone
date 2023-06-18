using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial2 : MonoBehaviour
{
    public Text text;    //튜토리얼 설명
    public GameObject TutorialMenu; //설명보여주는창
    public Animator animator;   //문열때 텍스트뜨게하려고
    int i = 0;  //다음텍스트 넘기는 변수

    public string[] TutorialText = { "this samll cube named 'Phone' is teleport device ","take the Phone(small white cube) to use Teleportation"
        ,"Click on the mouse to fire","if you finish fire, press down a Key (F) to Teleportation "
    ,"if you  teleport cube, touch cube and press down a Key (G)","Solve the small riddle and open Door "};

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        Invoke("show", 3);
        TutorialMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("DoorCheak"))  //문이 열렸을때
        {
            text.text = "Good, go to the next real Training";
        }

    }
    public void show()  //시간에 따라 나오게 하는
    {
        if (i < 2)
        {
            text.text = TutorialText[i];
            i++;
            Invoke("show", 6);
        }
        if (i < 6 && i > 2)
        {
            text.text = TutorialText[i];
            i++;
            Invoke("show", 10);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("item"))
        {
            if (i <3 && i > 1)
            {
                text.text = TutorialText[i];
                i++;
                Invoke("show", 6);
            }
        }
    }
}
