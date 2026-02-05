using UnityEngine;
using UnityEngine.UI;

public class Blue_Key_Icon : MonoBehaviour
{
    public Image blueKeyKeyIcon;
    public KeyManager keyManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keyManager.blueKey == true)
        {
            blueKeyKeyIcon.enabled = true;
        }

        if (keyManager.blueKey == false)
        {
            blueKeyKeyIcon.enabled = false;
        }
    }
}
