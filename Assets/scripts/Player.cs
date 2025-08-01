using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerInput;

    void Update()
    {
        if (Input.GetKeyDown("a")) 
        {
            PlayerInput = 0;
        }
        else if (Input.GetKeyDown("d")) 
        {
            PlayerInput = 1;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            PlayerInput = 2;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            PlayerInput = 4;
        }
    }
}
