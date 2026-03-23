using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Hover_Script : MonoBehaviour
{
    public Image lightBeam;
    public Transform torch1;
    public Transform torch2;
    public Transform torch3;
    public LayerMask uiButton;
    void Start()
    {
        lightBeam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            lightBeam.enabled = true;
            torch1.transform.position = new Vector3(250, 325, 0);
            torch2.transform.position = new Vector3(250, 200, 0);
            torch3.transform.position = new Vector3(250, 75, 0);
        }
        else
        {
            lightBeam.enabled = false;
            torch1.transform.position = new Vector3(220, 325, 0);
            torch2.transform.position = new Vector3(220, 200, 0);
            torch3.transform.position = new Vector3(220, 75, 0);
        }
    }


}
