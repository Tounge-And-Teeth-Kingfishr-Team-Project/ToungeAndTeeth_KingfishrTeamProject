using UnityEngine;
using UnityEngine.UI;

public class Pink_Key_Icon : MonoBehaviour
{
    public Image pinkKeyKeyIcon;
    public KeyManager keyManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keyManager.pinkKey == true)
        {
            pinkKeyKeyIcon.enabled = true;
        }

        if (keyManager.pinkKey == false)
        {
            pinkKeyKeyIcon.enabled = false;
        }
    }
}
