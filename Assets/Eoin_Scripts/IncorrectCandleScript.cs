using UnityEngine;

public class IncorrectCandleScript : MonoBehaviour
{
    public CandleManager candleManager;
    public Color litColour;
    public Color unlitColour;
    public bool isLit;
    public bool correct;
    public bool incorrect;
    
    void Start()
    {
        //resets the candle at the start
        GetComponent<Renderer>().material.color = unlitColour;
        correct = false;
        incorrect = false;
    }

    // Update is called once per frame
    void Update()
    {
        //puts out the candle if incorrect
        if (incorrect == true)
        {
            isLit = false;
            GetComponent<Renderer>().material.color = unlitColour;
            incorrect = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //lights the candle when the player touches the candle
        if (other.gameObject.CompareTag("Player"))
        {
            isLit = true;
            GetComponent<Renderer>().material.color = litColour;
            //increases the lit count but NOT the correct count
            candleManager.litCount++;
        }


    }
}
