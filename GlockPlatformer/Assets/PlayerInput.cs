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

    // Update is called once per frame
    void Update()
    {
        //Getting inputs 
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        //Getting jump key as a bool 
        _jumpKey = Input.GetButton("Jump") || Input.GetButtonDown("Jump");
    }

}
