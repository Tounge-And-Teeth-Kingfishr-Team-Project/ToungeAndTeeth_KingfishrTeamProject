using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkToFireplaceMan : MonoBehaviour
{
    private GoToNextTrigger goToNextTrigger;
    public TextMeshProUGUI textComponent;
    public bool canTalk = false;
    public bool isTalking = false;
    public string[] lines;
    public float textSpeed = 0.05f;
    private int index = -1;
    void Start()
    {
        goToNextTrigger = GetComponent<GoToNextTrigger>();
        textComponent.enabled = false;
        textComponent.text = string.Empty;
    }
    void Update()
    {
        if (canTalk)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isTalking)
                {
                    lines = goToNextTrigger.dialogues[goToNextTrigger.currentTrigger].dialogue;
                    StartDialogue();
                }
            }
        }
        if (canTalk && isTalking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }
    public void StartDialogue()
    {
        if (index == -1)
        {
            textComponent.enabled = true;
            Debug.Log("true");
            gameObject.SetActive(true);
            index = 0;
            StartCoroutine(TypeLine());
            isTalking = true;
        }
        Debug.Log(index);
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            index = -1;
            textComponent.enabled = false;
            textComponent.text = string.Empty;
            isTalking = false;
        }
    }
}
