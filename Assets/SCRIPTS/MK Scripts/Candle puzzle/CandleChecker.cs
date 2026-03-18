using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CandleChecker : MonoBehaviour
{
    public bool correct;

    public bool canLight = false;
    public bool isLit = false;
    public ParticleSystem fire;
    public GameObject candleCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fire.Stop();
        candleCounter = GameObject.Find("CANDLECHECKER");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canLight && !isLit)
            {
                candleCounter.GetComponent<CandleCounter>().candlesLit++;
                candleCounter.GetComponent<CandleCounter>().candleCheckers.Add(this);
                fire.Play();
                isLit = true;
            }
        }
        if (candleCounter.GetComponent<CandleCounter>().correct)
        {
            TurnOffFunction();
        }
    }
    public void BlowOutCandles()
    {
        isLit = false;
        fire.Stop();
    }
    void TurnOffFunction()
    {
        fire.Stop();
        this.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            canLight = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            canLight = false;
        }
    }
}
