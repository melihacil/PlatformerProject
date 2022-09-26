using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance { get; private set; }

    public float _horizontalInput {  get; private set; }
    public float _verticalInput { get; private set; }

    public bool _jumpKey {  get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");


        _jumpKey = Input.GetButton("Jump") || Input.GetButtonDown("Jump");
    }

}
