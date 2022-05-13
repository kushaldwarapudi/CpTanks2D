using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool IsPause;
    public bool resume;
   
    public GameObject P_Menu;
    public GameObject Menu;
    
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
        resume = true;
        P_Menu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pause()
    {
        IsPause = true;
        Time.timeScale = 0f;
        resume = false;
        P_Menu.SetActive(true);
        Menu.SetActive(false);

    }
    public void Resume()
    {
        resume = true;
        Time.timeScale = 1f;
        IsPause = false;
        P_Menu.SetActive(false);
        Menu.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
