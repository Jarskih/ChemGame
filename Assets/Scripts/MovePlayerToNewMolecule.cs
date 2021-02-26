using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToNewMolecule : MonoBehaviour
{
    public GameObject player;
    private Controls _controls;
    private void OnEnable()
    {
        _controls = GetComponentInParent<Controls>();
        _controls.enabled = false;
        player.GetComponent<Controls>().enabled = true;
        FollowPlayer.SetFollow(player.transform);
    }
}
