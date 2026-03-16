using UnityEngine;

public class CandleCounter : MonoBehaviour
{
    public CandleChecker[] candleCheckers;
    public int candlesLit = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < candleCheckers.Length; i++)
        {
            if (candleCheckers[i].isLit)
            {
                candlesLit++;
            }
        }
        if (candlesLit == 3)
        {
            CheckIfCorrect();
        }
    }
    void CheckIfCorrect()
    {
        for (int i = 0; i < candleCheckers.Length; i++)
        {
            if (candleCheckers[i].correct)
            {
                AllCorrect();
            }
            else
            {
                Incorrect();
            }
        }
    }
    void AllCorrect()
    {

    }
    void Incorrect()
    {

    }
}
