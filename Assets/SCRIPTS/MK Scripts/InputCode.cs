using UnityEngine;
using UnityEngine.UI;

public class InputCode : MonoBehaviour
{
    public bool interactable = false;
    public bool interacting = false;
    public GameObject player;
    public GameObject inputField;
    public Text password;
    private string input;
    public string theCode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interacting = true;
            }
            if (interacting)
            {
                Type();
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    interacting = false;
                    StopType();
                }
            }
        }
    }
    void Type()
    {
        player.SetActive(false);
        inputField.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void StopType()
    {
        player.SetActive(true);
        inputField.SetActive(false);
        Cursor.visible = false;
    }
    public void ReadStringInput(string s)
    {
        input = password.text;
        Debug.Log(input);
        if (input == theCode)
        {
            Correct();
        }
        else
        {
            Debug.Log("Incorrect!");
        }
        interacting = false;
        StopType();
    }
    void Correct()
    {
        Debug.Log("Correct!");
        StopType();
;    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            interactable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            interactable = false;
        }
    }
}
