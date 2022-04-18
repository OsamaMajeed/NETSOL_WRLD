using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotator : MonoBehaviour
{
    public float angularVelocity = 10;

    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = float.PositiveInfinity;
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.angularVelocity = new Vector3(0, angularVelocity, 0); 
    }
}
