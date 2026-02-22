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

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Show UI prompt if in range and candle is not lit
        if (distance <= interactRadius && !isLit)
        {
            if (uiPrompt != null)
            {
                uiPrompt.SetActive(true);
                Text promptText = uiPrompt.GetComponent<Text>();
                if (promptText != null)
                    promptText.text = "Press E to light candle";
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                LightCandle();
            }
        }
        else
        {
            if (uiPrompt != null)
                uiPrompt.SetActive(false);
        }

        // Update color if candle is correct
        if (correct)
        {
            GetComponent<Renderer>().material.color = correctColor;
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