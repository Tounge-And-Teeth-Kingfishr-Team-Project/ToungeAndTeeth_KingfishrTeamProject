using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CandleCounter : MonoBehaviour
{
    public List<CandleChecker> candleCheckers = new List<CandleChecker>();
    public GameObject[] keyFragments;
    public int candlesLit = 0;
    public PlayableDirector melt;
    public float meltTime = 2f;
    public bool correct = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (candlesLit == 3)
        {
            CheckIfCorrect();
        }
    }
    void CheckIfCorrect()
    {
        if (candleCheckers[0].correct && candleCheckers[1].correct && candleCheckers[2].correct)
        {
            AllCorrect();
        }
        else
        {
            Incorrect();
        }
    }
    void AllCorrect()
    {
        Debug.Log("Candles good");
        correct = true;
        melt.Play();
        StartCoroutine(DelayAction());
        for (int i = 0; i < keyFragments.Length; i++)
        {
            keyFragments[i].SetActive(true);
        }
        Destroy(gameObject);
    }
    void Incorrect()
    {
        Debug.Log("Candles bad");

        for (int i = 0; i < candleCheckers.Count; i++)
        {
            candleCheckers[i].BlowOutCandles();
        }
        candleCheckers.Clear();
        candlesLit = 0;
    }

    private IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(meltTime);
    }
}
