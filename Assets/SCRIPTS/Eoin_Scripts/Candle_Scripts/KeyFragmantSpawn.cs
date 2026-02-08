using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System.Collections;
using System.Collections.Generic;
public class KeyFragmantSpawn : MonoBehaviour
{
   public CandleScript candleScript;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KeyFragment"))
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator DelayAction()
    {
        
        yield return new WaitForSeconds(meltTime);
        Destroy(gameObject);
    }
}
