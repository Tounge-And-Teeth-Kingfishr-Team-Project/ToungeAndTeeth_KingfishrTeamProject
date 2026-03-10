using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class CandleManager : MonoBehaviour
{
    [Header("Candle Tracking")]
    public List<CandleScript> candles = new List<CandleScript>();
    public List<IncorrectCandleScript> incorrectCandles = new List<IncorrectCandleScript>();
    public int litCount = 0;
    public int correctCount = 0;
    public int incorrectCount = 0;
    public float extinguishTime;

    [Header("Settings")]
    public bool allCorrectRequired = true;

    void Start()
    {
        // Initialize counts
        litCount = 0;
        correctCount = 0;
        incorrectCount = 0;

        if (candles.Count == 0)
        {
            // Use the new method instead of FindObjectsOfType
            CandleScript[] foundCandles = Object.FindObjectsByType<CandleScript>(FindObjectsSortMode.None);
            foreach (CandleScript candle in foundCandles)
            {
                candle.candleManager = this; // ensure manager reference is set
                candles.Add(candle);
            }
        }
    }

    void Update()
    {
        // Reset counts each frame (to account for dynamic lighting/unlighting)
        litCount = 0;
        correctCount = 0;
        incorrectCount = 0;

        

        foreach (CandleScript candle in candles)
        {
            if (candle.isLit)
            {
                litCount++;

                if (candle.correct)
                    correctCount++;
                else if (candle.incorrect)
                    incorrectCount++;
                else
                    incorrectCount++; // default to incorrect if neither explicitly set
            }
        }

        if (litCount >= 3f && correctCount != 3f)
        {
            StartCoroutine(DelayAction());
        }

        // Debugging: display current counts
        Debug.Log($"Lit: {litCount}, Correct: {correctCount}, Incorrect: {incorrectCount}");
    }

    public bool AreAllCorrectCandlesLit()
    {
        if (!allCorrectRequired) return true;

        bool hasCorrectCandle = false;

        foreach (CandleScript candle in candles)
        {
            if (candle.correct)
            {
                hasCorrectCandle = true;

                if (!candle.isLit)
                    return false;
            }
        }

        return hasCorrectCandle; // only true if at least one correct exists
    }

    public IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(extinguishTime);
        foreach (CandleScript candle in candles)
        {
            
            candle.ExtinguishCandle();
            candle.incorrect = false;
            candle.correct = false;
        }
    }

    
}

