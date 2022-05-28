using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GasController : MonoBehaviour
{
    public GameObject success;
    public GameObject batAAA;
 
        // Duman Tanimi
    public GameObject smoke;
        //LED Tanimi
    public GameObject ledOff;
    public GameObject ledHigh;

    private bool succeeded = false;

    private float timer = 0.0f;
    private float waitTime = 10.0f;
    private float visualTime = 0.0f;





    void Start()
    {
        batAAA.SetActive(false);
        smoke.SetActive(false);
        ledOff.SetActive(true);
        ledHigh.SetActive(false);
        succeeded = false;
        StartCoroutine(ExampleCoroutine());

    } 

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
    }

    // Update is called once per frame
    void Update()
    {
        AlarmSound.alarm=false;
        if(batAAA.activeSelf && smoke.activeSelf){
                
            timer += Time.deltaTime;
            AlarmSound.alarm=true;


            if(timer > waitTime)
            {
                visualTime = timer;
                Success();
                AlarmSound.alarm=false;

            }

            if(Mathf.Round(timer % 2) == 0)
            {
                ledHigh.SetActive(true);
                ledOff.SetActive(false);
                ExampleCoroutine();
            }
            if(Mathf.Round(timer % 2) == 1)
            {
                ledHigh.SetActive(false);
                ledOff.SetActive(true);
                ExampleCoroutine();
            }
        }


    }


    public void plugBat() {
        batAAA.SetActive(true);
    }

    public void pressGas(){
        if(!success.activeSelf)
            if(smoke.activeSelf)
                smoke.SetActive(false);
            else
                smoke.SetActive(true);
    }

    public void Success(){
        if(!succeeded){
            ScoreManager.instance.AddPoint();
            success.SetActive(true);
            EndGame.GameIsSuccess = true;
            succeeded= true;
        }

    }
    
    public void Bonus() {
        ScoreManager.instance.MinusPoint(10);
    }
    
    
}
