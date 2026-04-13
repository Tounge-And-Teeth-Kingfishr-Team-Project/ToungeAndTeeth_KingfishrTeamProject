using UnityEngine;
using System.Collections;

public class EntryDialogue : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(KeepTextOn(4f));
    }

    IEnumerator KeepTextOn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
