using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDetection : MonoBehaviour
{
    bool inPoint2Start = false;

    bool statePoint0Start = false;
    bool statePoint1Start = false;



    [SerializeField]  public GameObject burn;
    [SerializeField]  public GameObject success;
    [SerializeField]  public GameObject current;
    [SerializeField]  public GameObject homeLight;

   

    void Start()
    {
       burn.SetActive(false);
       success.SetActive(false);
       current.SetActive(false);
       homeLight.SetActive(false);
       
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("logic2State1"))
            statePoint1Start = true;

        if(collision.CompareTag("logic3State0"))
            statePoint0Start = true;

        if(collision.CompareTag("inPoint2"))
            inPoint2Start = true;



        if(statePoint0Start)
            if(collision.CompareTag("inPoint2"))
            {
                Burn();
            }

        if(statePoint1Start)
            if(collision.CompareTag("inPoint2"))
            {  
                CheckOK();
            }

        if(inPoint2Start)
            if(collision.CompareTag("logic2State1"))
                CheckOK();
            else if(collision.CompareTag("logic3State0"))
                Burn();

    }

    private void CheckOK()
    {
        Debug.Log("Check OK");
        current.SetActive(true);
        success.SetActive(true);
        homeLight.SetActive(true);
        ScoreManager.instance.AddPoint();
        EndGame.GameIsSuccess = true;
    }

    private void Burn()
    {
        Debug.Log("Burning");
        burn.SetActive(true);
        ScoreManager.instance.MinusPoint(2);
        EndGame.GameIsPaused = true;
    }

    
        
}

