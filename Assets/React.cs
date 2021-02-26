using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class React : MonoBehaviour
{
    public GameObject _objectToSpawn;
    public GameObject _finalObject;
    
    // Start is called before the first frame update
    void Start()
    {
        _finalObject.SetActive(false);
        if (!(_objectToSpawn is null))
        {
            _objectToSpawn.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_objectToSpawn)
            {
                _objectToSpawn.transform.SetParent(null);
                _objectToSpawn.SetActive(true);
            }
            
            gameObject.SetActive(false);
            _finalObject.SetActive(true);
            var controls = GetComponentInParent<Controls>();
            controls.enabled = true;
            other.transform.parent.gameObject.SetActive(false);
            FollowPlayer.SetFollow(controls.transform);
        }
    }
}
