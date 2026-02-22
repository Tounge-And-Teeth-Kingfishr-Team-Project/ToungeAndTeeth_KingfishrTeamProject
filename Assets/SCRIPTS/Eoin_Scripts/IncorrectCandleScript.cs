using UnityEngine;

public class IncorrectCandleScript : Interactable
{
    public CandleManager candleManager;
    public Color litColour;
    public Color unlitColour;
    public bool isLit;
    public bool incorrect;

    void Start()
    {
        GetComponent<Renderer>().material.color = unlitColour;
    }

    void Update()
    {
        if (incorrect)
        {
            isLit = false;
            GetComponent<Renderer>().material.color = unlitColour;
            incorrect = false;
        }
    }

    protected override void Interact(GameObject player)
    {
        if (!isLit)
        {
            isLit = true;
            GetComponent<Renderer>().material.color = litColour;
            candleManager.litCount++;
        }

        ShowPrompt(false);
    }
}
