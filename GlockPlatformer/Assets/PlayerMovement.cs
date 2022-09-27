using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private Rigidbody2D m_RigidBody;
    [SerializeField] private float m_Speed;


    [Header ("Jump Related")]
    [SerializeField] private float m_jumpForce;
    //Gravity
    [SerializeField] private float m_FallGravity;
    [SerializeField] private float m_JumpCutMultiplier;

    [SerializeField] private Vector2 m_GroundCheckSize = new Vector2(0.5f, 0.5f);
    [SerializeField] private Transform m_GroundCheckTransform;
    [SerializeField] private LayerMask m_GroundLayer;
    //Coyote time
    [SerializeField] private float _coyoteTimeMax;
    [SerializeField] private float m_CoyoteTime;
    private bool m_hasJumped;
    private PlayerInput m_PlayerInput;
    private float m_NormalGravity;
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
     * MAYBE enemies and gun system but most likely nonýonýnnýnononoo
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
        m_CoyoteTime -= Time.deltaTime;
        if (m_IsGrounded)
        {
            //Debug.Log("Not Grounded");
            m_CoyoteTime = _coyoteTimeMax;
            m_hasJumped = false;
        }
    }

    //Physic related stuff
    //Movement jumping and other 
    private void FixedUpdate()
    {
        JumpFunction();
        MovementFunction();

        if (!m_PlayerInput._jumpKey && m_hasJumped)
        {
            JumpCut();
        }


    }


    private void JumpCut()
    {
        if (m_RigidBody.velocity.y > 0)
        {
            m_RigidBody.AddForce(Vector2.down * m_RigidBody.velocity.y* m_JumpCutMultiplier, ForceMode2D.Impulse);

        }
    }


    private void JumpFunction()
    {
        if (m_CoyoteTime > 0f && m_PlayerInput._jumpKey && !m_hasJumped)
        {
            m_RigidBody.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
            m_hasJumped = true;
        }
    }
    //Going to calculate needed force to adding speed 
    private void MovementFunction()
    {



        m_RigidBody.AddForce(Vector2.right * m_Speed * m_PlayerInput._horizontalInput);



    }



}
