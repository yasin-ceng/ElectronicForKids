using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BatteryPlug : MonoBehaviour
{
    public GameObject success;
    public GameObject batAAA;
        //NTC Tanimlari
    public GameObject ntc;
    public GameObject ntcMiddle;
    public GameObject ntcHot;
        //LED Tanimlari
    public GameObject ledOff;
    public GameObject ledLow;
    public GameObject ledHigh;
        // Alev Tanimlari
    public GameObject burnerOff;
    public GameObject burnerMiddle;
    public GameObject burnerHot;


    public Slider mainSlider;
   
    public static float heatVolume = 0.5f;

    private bool batPlugged = false;

    private byte firstStep = 0;
    private byte secondStep = 0;

    private bool succeeded = false;


    void Start()
    {
        batAAA.SetActive(false);
        ntc.SetActive(true);
        ntcMiddle.SetActive(false);
        ntcHot.SetActive(false);
        ledOff.SetActive(true);
        ledLow.SetActive(false);
        ledHigh.SetActive(false);
        burnerOff.SetActive(true);
        burnerMiddle.SetActive(false);
        burnerHot.SetActive(false);
        mainSlider.value = 0f;
        batPlugged= false;
        firstStep=0;
        secondStep=0;
    } 


    // Update is called once per frame
    void Update()
    {
        
    }


    public void plugBat() {
        batAAA.SetActive(true);
        batPlugged = true;
    }

    public void getValue(){
        
            if(mainSlider.value < 0.33){
                if(batPlugged){
                ntcMiddle.SetActive(false);
                ntc.SetActive(true);
                ntcHot.SetActive(false);
                ledOff.SetActive(true);
                ledLow.SetActive(false);
                ledHigh.SetActive(false);
                }
                burnerOff.SetActive(true);
                burnerMiddle.SetActive(false);
                burnerHot.SetActive(false);
            }

            if(mainSlider.value > 0.33 && mainSlider.value < 0.66){
                if(batPlugged && !(ntcMiddle.activeSelf)){
                ntcMiddle.SetActive(true);
                ntc.SetActive(false);
                ntcHot.SetActive(false);
                ledOff.SetActive(false);
                ledLow.SetActive(true);
                ledHigh.SetActive(false);
                firstStep++;
            }
                burnerOff.SetActive(false);
                burnerMiddle.SetActive(true);
                burnerHot.SetActive(false);
            }

            if(mainSlider.value > 0.66 ){
                if(batPlugged && !(ntcHot.activeSelf)){
                ntcHot.SetActive(true);
                ntc.SetActive(false);
                ntcMiddle.SetActive(false);
                ledOff.SetActive(false);
                ledLow.SetActive(false);
                ledHigh.SetActive(true);
                secondStep++;
                }
                burnerOff.SetActive(false);
                burnerMiddle.SetActive(false);
                burnerHot.SetActive(true);
            }
            if(firstStep > 3 && secondStep > 3){
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
