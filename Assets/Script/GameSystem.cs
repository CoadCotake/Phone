using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public static bool IsPause;
    public GameObject Menu;
    public string SceneName;    //재시작 씬제목

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IsPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPause = !IsPause;
            shooter.resumecheak = true;
        }
        /*일시정지 활성화*/
        if (IsPause == false)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Menu.SetActive(true);
            return;
        }

        /*일시정지 비활성화*/
        if (IsPause == true)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Menu.SetActive(false);
            return;
        }
        
    }
    public void Restart()       //재시작
    {
        Debug.Log("sad");
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void MainMenu()      //메인메뉴
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void End()       //게임종료
    {
        Application.Quit();
    }
    public void Resume()    //이어서시작
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Menu.SetActive(false);
        IsPause = true;
    }
}
