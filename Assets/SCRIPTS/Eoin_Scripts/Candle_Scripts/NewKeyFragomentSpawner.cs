using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System.Collections;
using System.Collections.Generic;

public class NewKeyFragomentSpawner : MonoBehaviour
{
    public GameObject keyFragment;
    public CandleScript candleScript;
    public bool fragmentMove;
    public float meltTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (candleScript.correct == true)
        {
            StartCoroutine(DelayAction());
        }
    }

    public IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(meltTime);
        fragmentMove = true;
        Destroy(gameObject);
    }
}
