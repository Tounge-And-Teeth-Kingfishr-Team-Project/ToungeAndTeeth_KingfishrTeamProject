using UnityEngine;
using UnityEngine.UI;

public class ExteriorObjetiveScript : MonoBehaviour
{
    public bool exploreOn;
    public bool enterMansionOn;
    public GameObject exploreText;
    public GameObject enterMansionText;
    void Start()
    {
        exploreText.SetActive(false);
        enterMansionText.SetActive(false);
    }

    
    void Update()
    {
        if (exploreOn == true) 
        {
            exploreText.SetActive(true);
        }
        else
        {
            exploreText.SetActive(false);
        }

        if (enterMansionOn == true)
        {
            enterMansionText.SetActive(true);
            exploreText.SetActive(false);
        }
        else
        {
            enterMansionText.SetActive(false);
        }
    }
}
