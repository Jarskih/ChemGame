using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SquashOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        transform.DOScale(new Vector3(0.5f, 0f,5f), 0.1f);
    }
}
