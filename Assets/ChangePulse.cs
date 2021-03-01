using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePulse : MonoBehaviour
{
    public Animator[] _animators;
    private static int _index;
    private static Animator[] _objects;
    
    // Start is called before the first frame update
    void Start()
    {
        _objects = _animators;
        foreach (var animator in _objects)
        {
            animator.enabled = false;
        }
        
        _objects[0].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Next()
    {
        _objects[_index].enabled = false;
        _index++;

        if (_index < _objects.Length)
        {
            _objects[_index].enabled = true;
        }
    }
}
