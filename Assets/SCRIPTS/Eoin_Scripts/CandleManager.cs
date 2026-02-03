using UnityEngine;

public class CandleManager : MonoBehaviour
{
    public float correctCount;
    public float incorrectCount;
    public float litCount;
    public CandleScript candleScript1;
    public CandleScript candleScript2;
    public CandleScript candleScript3;
    public IncorrectCandleScript incorrectCandleScript1;
    public IncorrectCandleScript incorrectCandleScript2;
    public IncorrectCandleScript incorrectCandleScript3;
    void Start()
    {
        //setting all the variables to default values
        litCount = 0f;
        correctCount = 0f;
        incorrectCount = 0f;
    }
    //checks if three candles are lit
    void Update()
    {
        //If all the correct candles are lit, set their correct booleans to true
        if (litCount == 3f && correctCount == 3f)
       {
            candleScript1.correct = true;
            candleScript2.correct = true;
            candleScript3.correct = true;
       }
        //If three candles are lit but not all correct, it resets the puzzle
        if (litCount == 3f && correctCount != 3f)
        {
            candleScript1.incorrect = true;
            candleScript2.incorrect = true;
            candleScript3.incorrect = true;
            incorrectCandleScript1.incorrect = true;
            incorrectCandleScript2.incorrect = true;
            incorrectCandleScript3.incorrect = true;
            litCount = 0f;
            correctCount = 0f;
        }

    }
}
