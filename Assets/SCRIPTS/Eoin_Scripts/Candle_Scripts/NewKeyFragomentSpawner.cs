using UnityEngine;
using System.Collections;

public class NewKeyFragomentSpawner : MonoBehaviour
{
    public GameObject keyFragment;
    public GameObject candleBlaze;
    public CandleManager candleManager;

    public float meltTime = 2f;

    private bool hasTriggered = false;

    void Start()
    { 
    
    }

        void Update()
    {
        if (candleManager == null) return;

        Debug.Log("All correct lit? " + candleManager.AreAllCorrectCandlesLit());

        if (!hasTriggered && candleManager.AreAllCorrectCandlesLit())
        {
            hasTriggered = true;
            StartCoroutine(DelayAction());
        }
    }

    private IEnumerator DelayAction()
    {
        Debug.Log($"candles are melting {gameObject.name} ");
        yield return new WaitForSeconds(meltTime);

        GameObject kf = Instantiate(keyFragment, transform.position, Quaternion.identity);

        Debug.Log($"key fragment spawned {kf.name} ");

        //if (candleManager != null)
        //{
        //    foreach (CandleScript candle in candleManager.candles)
        //    {
        //        if (candle.correct && candle.isLit)
        //        {
        //            Destroy(candle.gameObject);
        //        }
        //    }
        //}

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log($"Candle {gameObject.name} destroyed");
    }
}
