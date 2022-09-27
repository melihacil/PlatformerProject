using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private Rigidbody2D m_RigidBody;
    [SerializeField] private float m_Speed;


    [Header ("Jump Related")]
    [SerializeField] private float m_jumpForce;
    //Gravity
    [SerializeField] private float m_FallGravity;
    private float m_NormalGravity;
    [SerializeField] private Vector2 m_GroundCheckSize = new Vector2(0.5f, 0.5f);
    [SerializeField] private Transform m_GroundCheckTransform;
    [SerializeField] private LayerMask m_GroundLayer;



    private PlayerInput m_PlayerInput;
    //private Vector2 moveSpeed;


    [SerializeField] private bool m_IsGrounded;
   


    //To implement
    //
    /*
     * Coyote time
     * Jump Cut and other things for jumping
     * Improve adding force (maxspeed , addspeedval)
     * Improving ground check system so the player can jump a bit more higher(Getting input and jumping after pressed key)
     * Double jump
     * Maybe wall climb, hang or wall jumping
     * A basic n++ like game with spikes death pits and other traps that will kill you
     * MAYBE enemies and gun system but most likely non�on�nn�nononoo
     * SOISOISOISOISOISOISOISOISOI
    */

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
