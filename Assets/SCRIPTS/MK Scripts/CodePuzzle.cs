using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CodePuzzle : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    public bool isPlayerActive = true;
    [Header("Requirements")]
    public bool canUnlock = false;
    public bool unlocking = false;
    [Header("Stats")]
    public int activeItemIndex = 0;
    public int numberOfSlots = 3;
    public int numberOfSymbols = 3;
    public int listCorrect = 0;
    public CodePuzzlePerSlot[] slots;
    public GameObject puzzleCamera;
    public GameObject boxLid;
    public GameObject UIindicator;
    public GameObject[] UIindicatorList;
    public GameObject blueKey;
    private void Start()
    {
        UIindicator.SetActive(false);
    }
    private void Update()
    {
        if (unlocking)
        {
            ChangeSymbol();
            Cycle();
            if (Input.GetKeyDown(KeyCode.E))
            {
                Unlock();
            }
        }
    }
    public void Unlock()
    {
        player.SetActive(!isPlayerActive);
        puzzleCamera.SetActive(isPlayerActive);
        UIindicator.SetActive(isPlayerActive);
        isPlayerActive = !isPlayerActive;
        unlocking = !unlocking;
        player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
        player.GetComponent<FlashlightController>().enabled = !player.GetComponent<FlashlightController>().enabled;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isCorrect)
            {
                listCorrect++;
            }
        }
        CorrectCheck();
    }
    void ChangeSymbol()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            slots[activeItemIndex].gameObject.transform.Rotate(360 / numberOfSymbols, 0f, 0f);
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
            slots[activeItemIndex].gameObject.transform.Rotate(-360 / numberOfSymbols, 0f, 0f);
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

        UIindicator.transform.parent = UIindicatorList[activeItemIndex].transform;
        UIindicator.transform.localPosition = new Vector3(0f, 0.0212f, -0.0344f);
    }
    void CorrectCheck()
    {
        if (listCorrect == numberOfSlots)
        {
            boxLid.gameObject.GetComponent<Animator>().SetTrigger("Open");
            Debug.Log("CorrectCheck!");
            gameObject.layer = 0;
            blueKey.SetActive(true);
        }
        else
        {
            listCorrect = 0;
        }
    }/*
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
    */
}
