using UnityEngine;
using System.Collections;

public class NewKeyFragomentSpawner : MonoBehaviour
{
    public GameObject keyFragment;
    public CandleManager candleManager;

    public float meltTime = 2f;

    private bool hasTriggered = false;

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
        yield return new WaitForSeconds(meltTime);

        Instantiate(keyFragment, transform.position, Quaternion.identity);

        // 🔥 destroy the candle that triggered this
        if (candleManager != null)
        {
            foreach (CandleScript candle in candleManager.candles)
            {
                if (candle.correct && candle.isLit)
                {
                    Destroy(candle.gameObject);
                }
            }
        }

        Destroy(gameObject);
    }
}
