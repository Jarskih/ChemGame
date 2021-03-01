using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    [SerializeField] float _current;

    private void Start()
    {
        _current = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        _current = Mathf.PingPong(Time.time, 0.6f);
        RenderSettings.haloStrength = _current;
    }
}
