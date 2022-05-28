using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    public static bool GameIsSuccess = false;
    public static bool BonusRight = false;

    [SerializeField]  public GameObject andInfo;

    public GameObject nextGameButtonUI;
    public GameObject endGameMenuUI;
    public GameObject bonusButtonUI;


    void Start()
    {
        andInfo.SetActive(false);
    }

   
    void Update()
    {
            if(GameIsPaused)
                Pause();
            if(GameIsSuccess)
                NextGameBtn();
            if(BonusRight)
                BonusBtn();
    }
    
    public void NextGame ()
    {
        nextGameButtonUI.SetActive(false);
        GameIsSuccess=false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

    public void NextGameBtn ()
    {
        nextGameButtonUI.SetActive(true);
    }

    public void BonusBtn ()
    {
        bonusButtonUI.SetActive(true);
    }

    public void BonusUsing ()
    {
        andInfo.SetActive(true);
        ScoreManager.instance.MinusPoint(4);

        //andInfo.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        endGameMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }


    public void BurnGame ()
    {
        endGameMenuUI.SetActive(true);
       // GameIsPaused = false;

    }


    void Pause ()
    {
        endGameMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    

}
