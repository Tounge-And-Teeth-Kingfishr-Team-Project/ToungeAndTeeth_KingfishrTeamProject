using UnityEngine;

public class GlobeManager : MonoBehaviour
{
    public GlobeScript globe1;
    public GlobeScript globe2;
    public GlobeScript globe3;
    public GlobeScript globe4;
    public GlobeScript globe5;

    // Update is called once per frame
    void Update()
    {
        //checks if all the globes are in the correct position
        if (globe1.rotatePoint == 0 && globe2.rotatePoint == 1 && globe3.rotatePoint == 2 && globe4.rotatePoint == 3 && globe5.rotatePoint == 4)
        {
            //when they are, the correct booleans are set to true
            globe1.correct = true;
            globe2.correct = true;
            globe3.correct = true;
            globe4.correct = true;
            globe5.correct = true;
        }
    }
}
