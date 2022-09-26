using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerInput m_PlayerInput;

    void Start()
    {
        m_PlayerInput = PlayerInput.Instance;

        if (m_PlayerInput != null)
            Debug.Log("wow");
        else
            Debug.Log("Null");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
