using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System.Collections;
using System.Collections.Generic;

public class CandleScript : MonoBehaviour
{
    //public CandleManager candleManager;
    public Color litColour;
    public Color unlitColour;
    public Color correctColour;
    public bool isLit;
    public bool correct;
    public bool incorrect;
    public float incorrectTime;
    public CandleManager candleManager;

    public float durationTime;
    public bool cooldown;
    public float cooldownTime;

    //public GameObject candleFlame;
    //public GameObject candleFlameCorrect;
    //public Transform fireballSpawnPoint;
    void Start()
    {
        //resets the candle at the start

        GetComponent<Renderer>().material.color = unlitColour;
        correct = false;
        incorrect = false;
    }

    
    void Update()
    {
        //changes colour to the solved colour
        if (correct == true)
        {
            GetComponent<Renderer>().material.color = correctColour;
        }
        //puts out the candle if incorrect
        if (incorrect == true)
        {
            StartCoroutine(DelayAction());
            
        }


    }

    private void OnTriggerEnter(Collider other) 
    {
        //lights the candle when the player touches the candle
        if (other.gameObject.CompareTag("Player") && isLit != true)
        {
            //flameSpawn();
            Debug.Log("Player touched candle");
            isLit = true;
            GetComponent<Renderer>().material.color = litColour;
            //increases the lit count and correct count in the candle manager
            candleManager.litCount++;
            candleManager.correctCount++;
        }
        
    }

    public IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(incorrectTime);
        isLit = false;
        GetComponent<Renderer>().material.color = unlitColour;
        incorrect = false;
    }

        //private void flameSpawn()
        //{
        //    GameObject fireBall;
        //    fireBall = Instantiate(candleFlame, fireballSpawnPoint.position, Quaternion.identity);
        //}
    }
