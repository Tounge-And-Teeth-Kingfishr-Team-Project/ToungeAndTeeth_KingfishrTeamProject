using UnityEngine;
using System.Collections;

public class NewKeyFragomentSpawner : MonoBehaviour
{
    public GameObject keyFragment;
    public CandleScript candleScript;

    [Header("Fragment Movement")]
    public bool fragmentMove = false;   // 🔥 Add this
    public float meltTime = 2f;

    void Start()
    {
        fragmentMove = false;
    }

    void Update()
    {
        if (candleScript != null && candleScript.correct)
        {
            StartCoroutine(DelayAction());
        }
    }

    private IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(meltTime);
        fragmentMove = true;
        Destroy(gameObject); // optional: destroy the spawner
    }
}
