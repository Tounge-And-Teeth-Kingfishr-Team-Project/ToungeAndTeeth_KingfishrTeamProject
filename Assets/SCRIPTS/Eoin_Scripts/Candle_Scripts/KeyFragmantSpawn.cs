using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System.Collections;
using System.Collections.Generic;
public class KeyFragmantSpawn : MonoBehaviour
{
    public CandleScript candleScript;
    public float meltTime;
    public Transform teleport;
    public GameObject keyFragment;
    public GameObject candle;
    void Start()
    {
        keyFragment.SetActive(!keyFragment.activeSelf);
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
        keyFragment.SetActive(!keyFragment.activeSelf);
        Destroy(gameObject);
    }
}
