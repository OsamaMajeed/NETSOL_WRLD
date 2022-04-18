using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelecopterController : MonoBehaviour
{
    public Transform centerOfMass;
    public float speed = 20;

    private Rigidbody _rigidbody;
    private Vector3 control;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            control.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Z-Axis")); //resister input values before updating physics.
        else
            control = Vector3.zero;
    }
    private void FixedUpdate()
    {    
        _rigidbody.AddForce(Vector3.up * 5);                                             // makes the choper fall slowly
        if (control.magnitude > 0)
        {
            _rigidbody.AddForce(transform.up * control.z * speed, ForceMode.Force);      // for moving up and down with Q and E key respectively
            _rigidbody.AddForce(transform.forward * control.y * speed, ForceMode.Force); // for moving forward and backward with W and S key respectively
            _rigidbody.AddForce(transform.right * control.x * speed, ForceMode.Force);   // for moving right and left with A and D key respectively

            transform.Rotate(transform.up, control.x);                                   // rotate while moving left or right.
        }
        else
        {
            _rigidbody.AddForce(-_rigidbody.velocity, ForceMode.Force);                  // for breaking when no key is pressed.
        }
    }
}
