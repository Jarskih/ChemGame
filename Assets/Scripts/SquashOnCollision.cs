using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SquashOnCollision : MonoBehaviour
{
    private float timer = 0;
    private float delay = 0.5f;
    private float _minStrenght = 0.01f;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(timer < delay)
        {
            return;
        }

        if (other.impulse.magnitude < _minStrenght)
        {
            return;
        }
        
        timer = 0;
    
        transform.localScale = new Vector3(1, 1, 1);
        SoundManagerScript.PlaySound("Collision");

        ContactPoint contact = other.contacts[0];
        Vector3 myCollisionNormal = other.contacts[0].normal;
        myCollisionNormal = new Vector3(Mathf.Abs(myCollisionNormal.x), Mathf.Abs(myCollisionNormal.y), 1);
      //  Debug.Log("normal: " + myCollisionNormal);
        var value = new Vector3(Mathf.Clamp(myCollisionNormal.x, 0.8f, 1.2f), Mathf.Clamp(myCollisionNormal.y, 0.8f, 1.2f), 1);
        
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(value, 0.1f))
            .Append(transform.DOScale(new Vector3(1, 1, 1), 0.2f));

    
    }
}
