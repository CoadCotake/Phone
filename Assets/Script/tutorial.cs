using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public Text text;    //튜토리얼 설명
    public GameObject TutorialMenu; //설명보여주는창
    public Animator animator;   //문열때 텍스트뜨게하려고
    int i = 0;  //다음텍스트 넘기는 변수

    public string[] TutorialText= { "Oh Hi Welcome", "Let me tell you a few things.","press down a key (A, S, W, D ,SpaceBar) to move"
            , "Go to the front of the cube and press key (E)", "press down a key(E) to put the cube","Put the cube in on the door device"};
   
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
        if(animator.GetBool("DoorCheak"))   //문이 열렸을때
        {
            text.text = "Good, go to the next Training";
        }
        
    }
    public void show()  //시간에 따라 나오게 하는
    {
        if (i < 4)
        {
            text.text = TutorialText[i];
            i++;
            Invoke("show", 5);
        }
        if (i < 6 && i > 4)
        {
            text.text = TutorialText[i];
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Box"))
        {
            if (i < 5&&i>3)
            {
                text.text = TutorialText[i];
                i++;
                Invoke("show", 5);
            }
        }
    }
}
