using UnityEngine;
using UnityEngine.UI;

public class CandleScript : Interactable
{
    [Header("Candle Colors")]
    public Color litColor = Color.yellow;
    public Color unlitColor = Color.black;
    public Color correctColor = Color.green;

    [Header("Candle State")]
    public bool isLit = false;
    public bool correct = false;
    public bool incorrect = false; // Added to fix CandleManager errors

    [Header("Candle Manager")]
    public CandleManager candleManager;

    private GameObject player;

    void Start()
    {
        // Set initial color
        GetComponent<Renderer>().material.color = unlitColor;

        // Hide UI prompt at start
        if (uiPrompt != null)
            uiPrompt.SetActive(false);

        // Find player
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.LogError("Player not found! Make sure the tag is set.");
    }

    protected override void Interact(GameObject player)
    {
        if (!isLit)
        {
            isLit = true;
            GetComponent<Renderer>().material.color = litColor;
            Debug.Log("Candle lit!");
        }

        ShowPrompt(false);
    }

    public void ExtinguishCandle()
    {
        if (isLit == true)
        {   isLit = false;
            GetComponent<Renderer>().material.color = unlitColor;
            Debug.Log("Candle extinguished!");
        }

    }
    private void LightCandle()
    {
        if (!isLit)
        {
            isLit = true;
            GetComponent<Renderer>().material.color = litColor;

            // Update manager counts
            if (candleManager != null)
            {
                candleManager.litCount++;
                if (correct) candleManager.correctCount++;
                if (incorrect) candleManager.incorrectCount++; // if you track incorrect separately
            }

            Debug.Log("Candle lit with E!");
        }

        if (uiPrompt != null)
            uiPrompt.SetActive(false);
    }
}