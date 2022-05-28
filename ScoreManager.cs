using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
public static ScoreManager instance;

    public Text scoreText;
    public Text bonusText;
    

    int score = 0;
    int bonus = 0;

    private void Awake() {
        instance = this;
        
    }

   

    void Start()
    {
        //resetPoints();
        bonus = PlayerPrefs.GetInt("bonus", 0);
        score = PlayerPrefs.GetInt("score",0); 
        scoreText.text = score.ToString();
        bonusText.text = bonus.ToString();   
        
        if(bonus > 3) 
            EndGame.BonusRight=true;
        else
            EndGame.BonusRight=false;
    }


    public void AddPoint() {
       PlayerPrefs.SetInt("score",(score+=100));
        //score += 100;
        //scoreText.text = score.ToString();
        if(score > 90 )
           PlayerPrefs.SetInt("bonus", (bonus+=1));
    }

    public void MinusPoint(int point) {
        PlayerPrefs.SetInt("score",(score-=50));
        //score -=50;
        //if (score<0) score=0;
        if(PlayerPrefs.GetInt("score",0) < 0) PlayerPrefs.SetInt("score",(score=0));
        //scoreText.text = score.ToString();
        PlayerPrefs.SetInt("bonus", (bonus -= point));
        if(PlayerPrefs.GetInt("bonus", 0) < 0) PlayerPrefs.SetInt("bonus", (bonus=0));

    }

    public void resetPoints(){
        PlayerPrefs.SetInt("score",(score=0));
        PlayerPrefs.SetInt("bonus",(score=0));
    }

    public int GetBonus() 
    {
        return PlayerPrefs.GetInt("bonus",0);
    }

}
