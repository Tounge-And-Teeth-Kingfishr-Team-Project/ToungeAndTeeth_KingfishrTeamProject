using UnityEngine;
using System.Collections.Generic;

public class CandleManager : MonoBehaviour
{
    [Header("Candle Tracking")]
    public List<CandleScript> candles = new List<CandleScript>();
    public int litCount = 0;
    public int correctCount = 0;
    public int incorrectCount = 0;

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

        // Debugging: display current counts
        Debug.Log($"Lit: {litCount}, Correct: {correctCount}, Incorrect: {incorrectCount}");
    }

    // Optional helper: check if all correct candles are lit
    public bool AreAllCorrectCandlesLit()
    {
        if (!allCorrectRequired) return true;

        foreach (CandleScript candle in candles)
        {
            if (candle.correct && !candle.isLit)
                return false;
        }
        return true;
    }
}
