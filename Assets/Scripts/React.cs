using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class React : MonoBehaviour
{
    public GameObject _objectToSpawn;
    public GameObject _finalObject;
    public string _tag;
    public bool movePlayer;
    public bool endgame;
    
    // Start is called before the first frame update
    void Start()
    {
        _finalObject.SetActive(false);
        if (_objectToSpawn != null)
        {
            _objectToSpawn.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tag))
        {
            SpawnObject();
            SwapToNewObject();
            HideReactant(other.gameObject);
            SoundManagerScript.PlaySound("Reaction");
            UIHandler.ShowHint();
            
            if (!endgame)
            {
                if (!movePlayer)
                {
                    var controls = ChangeControls();
                    FollowPlayer.SetFollow(controls.transform);
                }
            }
        }
    }

    private void HideReactant(GameObject other)
    {
        if (other.transform.parent != null)
        {
            other.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            other.gameObject.SetActive(false);
        }
    }

    private Controls ChangeControls()
    {
        var controls = GetComponentInParent<Controls>();
        if (controls)
        {
            controls.enabled = true;
        }

        return controls;
    }

    private void SwapToNewObject()
    {
        gameObject.SetActive(false);
        _finalObject.SetActive(true);
    }

    private void SpawnObject()
    {
        if (_objectToSpawn)
        {
            _objectToSpawn.transform.SetParent(null);
            _objectToSpawn.SetActive(true);
        }
    }
}
