using UnityEngine;
using UnityEngine.UI;

public class Yellow_Key_Icon : MonoBehaviour
{
    public Image yellowKeyIcon;
    public KeyManager keyManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keyManager.yellowKey == true)
        {
            yellowKeyIcon.enabled = true;
        }

        if (keyManager.yellowKey == false)
        {
            yellowKeyIcon.enabled = false;
        }
    }
}
