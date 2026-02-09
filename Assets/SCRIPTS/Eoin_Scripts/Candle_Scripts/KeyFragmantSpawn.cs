using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System.Collections;
using System.Collections.Generic;
public class KeyFragmantSpawn : MonoBehaviour
{
    public CandleScript candleScript;
    public float meltTime;
    public Transform teleport;
    public GameObject keyFragment1;
    public GameObject keyFragment2;
    public GameObject keyFragment3;
    public GameObject candle;
    void Start()
    {
        keyFragment1.SetActive(!keyFragment1.activeSelf);
        keyFragment2.SetActive(!keyFragment2.activeSelf);
        keyFragment3.SetActive(!keyFragment3.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (candleScript.correct == true)
        {
            StartCoroutine(DelayAction());
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KeyFragment"))
        {
            candle.SetActive(!candle.activeSelf);
        }
    }

    public IEnumerator DelayAction()
    {
        
        yield return new WaitForSeconds(meltTime);
        keyFragment1.SetActive(!keyFragment1.activeSelf);
        keyFragment2.SetActive(!keyFragment2.activeSelf);
        keyFragment3.SetActive(!keyFragment3.activeSelf);
        Destroy(gameObject);
    }
}
