using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class MoonManager : MonoBehaviour
{
    public MoonInteract[] globes;
    public int correctNum;
    public int moonNum;

    public GameObject pinkKey;
    public GameObject Dome;
    public GameObject Light;

    public Animator domeAnimator;
    public Animator lightAnimator;

    private bool puzzleSolved = false;

    private void Start()
    {
        moonNum = globes.Length;
    }
    void Update()
    {
        CountGlobes();
    }
    IEnumerator PlayOpenSequence()
    {
        // Play animations
        domeAnimator.SetTrigger("Open");
        lightAnimator.SetTrigger("Flicker");

        // Wait for animation time (adjust to match animation length)
        yield return new WaitForSeconds(3f);

        pinkKey.SetActive(true);
        Dome.SetActive(false);
        Light.SetActive(false);
        Destroy(this);
    }
    public void CountGlobes()
    {
        correctNum = 0;
        for (int i = 0; i < globes.Length; i++)
        {
            if (globes[i].correct)
            {
                correctNum++;
            }
        }
        Correct();
    }
    void Correct()
    {
        if (correctNum == moonNum)
        {
            for (int i = 0;i < globes.Length;i++)
            {
                globes[i].AllCorrect();
                StartCoroutine(PlayOpenSequence());
            }
        }
    }
}
