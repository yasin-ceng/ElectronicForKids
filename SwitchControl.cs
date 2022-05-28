using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwitchControl : MonoBehaviour
{
    public GameObject success;
    public GameObject batAAA;
        //LED Tanimlari
    public GameObject ledOff;
    public GameObject ledLow;

    public GameObject swOpen;
    public GameObject swClose;

    private bool batPlugged = false;

    private byte firstStep = 0;
    private byte secondStep = 0;

    private bool succeeded = false;


    void Start()
    {
        batAAA.SetActive(false);
        ledOff.SetActive(true);
        ledLow.SetActive(false);
        swClose.SetActive(false);
        swOpen.SetActive(true);
        batPlugged = false;
        firstStep=0;
        secondStep=0;
    } 

    public void plugBat() {
        batAAA.SetActive(true);
        batPlugged = true;
    }

    public void clickSw(){
        
        if(batPlugged){
            if(swClose.activeSelf){
                swClose.SetActive(false);
                swOpen.SetActive(true);
                ledOff.SetActive(true);
                ledLow.SetActive(false);
                firstStep++;
            }

            else if(swOpen.activeSelf){
                swClose.SetActive(true);
                swOpen.SetActive(false);
                ledOff.SetActive(false);
                ledLow.SetActive(true);
                secondStep++;
            }
        }

        if(firstStep > 2 && secondStep > 2){
            Success();
        }
    }

    public void Success(){
        if(!succeeded){    
            ScoreManager.instance.AddPoint();
            success.SetActive(true);
            EndGame.GameIsSuccess = true;
        }
    }
    
    public void Bonus() {
        ScoreManager.instance.MinusPoint(10);
    }
    
}


