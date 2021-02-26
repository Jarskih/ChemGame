using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _force = 1f;
    [SerializeField] private float _rotationForce = 1f;

    private float _timer = 1;
    private float _delay = 1;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _rigidbody.AddForce(transform.right * _force, ForceMode.Acceleration);
        }

        float turn = Input.GetAxis("Horizontal");

        _rigidbody.AddTorque(transform.forward * turn * _rotationForce);
        }
}
