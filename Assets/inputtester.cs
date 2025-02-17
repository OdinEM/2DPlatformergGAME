using UnityEngine;

public class InputTester : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("Some key was pressed!");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Key Pressed!");
        }
    }
}
