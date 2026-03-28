using UnityEngine;

public class CodePuzzle : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    [Header("Requirements")]
    public bool canUnlock = false;
    public bool unlocking = false;
    [Header("Stats")]
    public int activeItemIndex = 0;
    public int numberOfSlots = 3;
    public int numberOfSymbols = 3;
    public CodePuzzlePerSlot[] slots;
    private void Update()
    {
        Unlock();
        if (canUnlock && unlocking)
        {
            ChangeSymbol();
            Cycle();
        }
    }
    void Unlock()
    {
        if (canUnlock)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                unlocking = !unlocking;
                player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
                player.GetComponent<FlashlightController>().enabled = !player.GetComponent<FlashlightController>().enabled;
            }
        }
    }
    void ChangeSymbol()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (slots[activeItemIndex].currentSymbolIndex == numberOfSymbols - 1)
            {
                slots[activeItemIndex].currentSymbolIndex = 0;                        //if the active item is at the top of the symbols list, go to the bottom of the list
            }
            else
            {
                slots[activeItemIndex].currentSymbolIndex++;                          //otherwise, just go to the next symbol;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (slots[activeItemIndex].currentSymbolIndex == 0)
            {
                slots[activeItemIndex].currentSymbolIndex = numberOfSymbols - 1;      //if the active item is at the bottom of the symbols list, go to the top of the list
            }
            else
            {
                slots[activeItemIndex].currentSymbolIndex--;                          //otherwise, just go to the previous symbol
            }
        }
    }
    void Cycle()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (activeItemIndex == numberOfSlots - 1)
            {
                activeItemIndex = 0;                        //if the active item is at the top of the symbols list, go to the bottom of the list
            }
            else
            {
                activeItemIndex++;                          //otherwise, just go to the next symbol;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (activeItemIndex == 0)
            {
                activeItemIndex = numberOfSlots - 1;      //if the active item is at the bottom of the symbols list, go to the top of the list
            }
            else
            {
                activeItemIndex--;                          //otherwise, just go to the previous symbol
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            canUnlock = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            canUnlock = false;
        }
    }
}
