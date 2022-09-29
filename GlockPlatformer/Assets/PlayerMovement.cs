using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    private PlayerInput m_PlayerInput;

    [SerializeField] private Rigidbody2D m_RigidBody;

    [Header("Movement Related")]

    [SerializeField] 
    private float m_Speed;


    [Header("Gravity Related")]

    [SerializeField] 
    private float m_FallGravity;
    private float m_NormalGravity;

    [Header ("Jump Related")]

    [SerializeField]
    private float m_jumpForce;

    [SerializeField]
    private float m_JumpCutMultiplier;

    private bool m_hasJumped;

    [Header("Ground Check")]
    [SerializeField] 
    private Vector2 m_GroundCheckSize = new Vector2(0.5f, 0.5f);
    [SerializeField] 
    private Transform m_GroundCheckTransform;
    [SerializeField] 
    private LayerMask m_GroundLayer;
    [SerializeField] 
    private bool m_IsGrounded;

    [Header("Coyote Time")]

    [SerializeField] 
    private float _coyoteTimeMax;
    [SerializeField] 
    private float m_CoyoteTime;



    private bool _isLookingRight = true;
    private bool _playerForward;
    //To implement
    //
    /*
     * Coyote time                              -- Implemented possibly final 
     * Jump Cut and other things for jumping    -- Implemented can be improved
     * Improve adding force (maxspeed , addspeedval,acceleration, deceleration)    
     * Improving ground check system so the player can jump a bit more higher(Getting input and jumping after pressed key)
     * -- Implemented -- Can be improved
     * Double jump --Scrapped
     * Maybe wall climb, hang or wall jumping --Probably
     * A basic n++ like game with spikes death pits and other traps that will kill you
     * Traps will definitely going to be added
     * A timer which is also a health bar so player is forced to move
     * MAYBE enemies and gun system but most likely nonýonýnnýnononoo
     * SOISOISOISOISOISOISOISOISOI
    */

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_NormalGravity = m_RigidBody.gravityScale;
        _playerForward = _isLookingRight;
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
        //Adding jump cut

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



    //Turning players forward
    private void PlayerForward()
    {
        if (_isLookingRight != _playerForward)
        {
            _playerForward = _isLookingRight;
            transform.forward *= -1;
        }    
    }


    private void JumpCut()
    {
        if (m_RigidBody.velocity.y > 0)
        {
            m_RigidBody.AddForce(Vector2.down * m_RigidBody.velocity.y * m_JumpCutMultiplier, ForceMode2D.Impulse);

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
        if (m_PlayerInput._horizontalInput > 0)
            _isLookingRight = true;
        else if (m_PlayerInput._horizontalInput  < 0)
            _isLookingRight = false;

        m_RigidBody.AddForce(Vector2.right * m_Speed * m_PlayerInput._horizontalInput);
    }



}
