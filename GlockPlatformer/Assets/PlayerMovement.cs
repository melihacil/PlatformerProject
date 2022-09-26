using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private Rigidbody2D m_RigidBody;
    [SerializeField] private float m_Speed;
    private PlayerInput m_PlayerInput;
    //private Vector2 moveSpeed;

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }
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




    private void FixedUpdate()
    {
        MovementFunction();
    }




    //Going to calculate needed force to adding speed 
    private void MovementFunction()
    {



        m_RigidBody.AddForce(Vector2.right * m_Speed * m_PlayerInput._horizontalInput);



    }



}
