using UnityEngine;
using UnityEngine.UI;

public class Shovel_Icon : MonoBehaviour
{
    public Image shovelIcon;
    public KeyManager keyManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keyManager.shovel == true)
        {
            shovelIcon.enabled = true;
        }

        if (keyManager.shovel == false)
        {
            shovelIcon.enabled = false;
        }
    }
}
