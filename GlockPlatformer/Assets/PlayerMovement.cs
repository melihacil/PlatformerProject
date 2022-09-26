using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private Rigidbody2D m_RigidBody;
    [SerializeField] private float m_Speed;
    [SerializeField] private float m_GroundCheckSize;
    [SerializeField] private Transform m_GroundCheckTransform;
    [SerializeField] private LayerMask m_GroundLayer;
   
    private PlayerInput m_PlayerInput;
    //private Vector2 moveSpeed;


    private bool m_IsGrounded;

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

    private void Update()
    {
        m_IsGrounded = Physics2D.OverlapArea(m_GroundCheckTransform.position, )
    }

    //Physic related stuff
    //Movement jumping and other 
    private void FixedUpdate()
    {
        JumpFunction();
        MovementFunction();
    }



    private void JumpFunction()
    {

    }
    //Going to calculate needed force to adding speed 
    private void MovementFunction()
    {



        m_RigidBody.AddForce(Vector2.right * m_Speed * m_PlayerInput._horizontalInput);



    }



}
