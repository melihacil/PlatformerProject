using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private Rigidbody2D m_RigidBody;
    [SerializeField] private float m_Speed;
    [SerializeField] private Vector2 m_GroundCheckSize = new Vector2(0.5f,0.5f);
    [SerializeField] private Transform m_GroundCheckTransform;
    [SerializeField] private LayerMask m_GroundLayer;

    [SerializeField] private float m_jumpForce;
    [SerializeField] private float m_FallGravity;
   
    private float m_NormalGravity;


    private PlayerInput m_PlayerInput;
    //private Vector2 moveSpeed;


    [SerializeField] private bool m_IsGrounded;
   

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_NormalGravity = m_RigidBody.gravityScale;
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
        if (m_RigidBody.velocity.y < 0)
            m_RigidBody.gravityScale = m_FallGravity;
        else
            m_RigidBody.gravityScale = m_NormalGravity;
        m_IsGrounded = Physics2D.OverlapBox(m_GroundCheckTransform.position, m_GroundCheckSize, 0, m_GroundLayer);
        if (!m_IsGrounded)
        {
            //Debug.Log("Not Grounded");
        }
        
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
        if (m_IsGrounded && m_PlayerInput._jumpKey)
        {
            m_RigidBody.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
        }
    }
    //Going to calculate needed force to adding speed 
    private void MovementFunction()
    {



        m_RigidBody.AddForce(Vector2.right * m_Speed * m_PlayerInput._horizontalInput);



    }



}
