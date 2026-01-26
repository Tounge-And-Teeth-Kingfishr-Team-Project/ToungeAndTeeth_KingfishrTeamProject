using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CandleScript : MonoBehaviour
{
    //public CandleManager candleManager;
    public Color litColour;
    public Color unlitColour;
    public Color correctColour;
    public bool isLit;
    public bool correct;
    public bool incorrect;
    public CandleManager candleManager;
    public float durationTime;
    public bool cooldown;
    public float cooldownTime;
    void Start()
    {
        //resets the candle at the start
        GetComponent<Renderer>().material.color = unlitColour;
        correct = false;
        incorrect = false;
    }

    
    void Update()
    {
        //changes colour to the solved colour
        if (correct == true)
        {
            GetComponent<Renderer>().material.color = correctColour;
        }
        //puts out the candle if incorrect
        if (incorrect == true)
        {
            isLit = false;
            //StartCoroutine(DelayAction());
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
            //increases the lit count and correct count in the candle manager
            candleManager.litCount++;
            candleManager.correctCount++;
        }
        
    }

    //public IEnumerator DelayAction()
    //{

        
    //    yield return new WaitForSeconds(durationTime);
        



        
    //    yield return new WaitForSeconds(cooldownTime);
        
    //}
}
