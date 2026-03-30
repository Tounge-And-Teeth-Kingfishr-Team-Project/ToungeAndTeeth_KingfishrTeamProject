using System;
using UnityEngine;

public class CodePuzzlePerSlot : MonoBehaviour
{
    public int currentSymbolIndex;
    public int correctSymbolIndex;
    public bool isCorrect = false;
    private void Update()
    {
        if (currentSymbolIndex == correctSymbolIndex)
        {
            isCorrect = true;
        }
        else
        {
            isCorrect = false;
        }
    }
}
