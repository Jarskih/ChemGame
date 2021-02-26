using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private const float G = 667.4f;

    public static List<Attractor> Attractors;
    public bool IsNegativeCharge;

    public bool UseGravityBorder = false;

    [SerializeField] private bool ReactOnTouch = false;

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (UseGravityBorder)
        {
            return;
        }

        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this)
            {
                if (attractor.IsNegativeCharge && !IsNegativeCharge)
                {
                    Attract(attractor, true);
                    SoundManagerScript.PlaySound("Reaction");
                }
                else
                {
                    Attract(attractor, false);
                }
            }
        }
    }

    private void OnEnable()
    {
        if (Attractors == null)
        {
            Attractors = new List<Attractor>();
        }

        Attractors.Add(this);
    }

    private void OnDisable()
    {
        Attractors.Remove(this);
    }
    
    private void Attract(Attractor objToAttract, bool towards)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        if (rbToAttract == null)
        {
            return;
        }


        Vector3 direction = new Vector3();
        if (towards)
        {
            direction = rb.position - rbToAttract.position;
        }
        else
        {
            direction = rbToAttract.position - rb.position;
        }
        
        float distance = direction.magnitude;

        if (distance <= 0.1f)
        {
            return;
        }

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;
        
        rbToAttract.AddForce(force);
    }

    private void OnTriggerStay(Collider other)
    {
        if (UseGravityBorder)
        {
            var attractor = other.GetComponent<Attractor>();
            if (attractor != null)
            {
                if (attractor.IsNegativeCharge && !IsNegativeCharge)
                {
                    Attract(attractor, true);
                    SoundManagerScript.PlaySound("Reaction");
                }
                else
                {
                    Attract(attractor, false);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (ReactOnTouch)
        {
            Debug.Log("reaction");
        }
    }
}
