using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip Collision, Reaction;
    static AudioSource audioScr;
         
    void Start()
    {

        Collision = Resources.Load<AudioClip>("Collision");

        Reaction = Resources.Load<AudioClip>("Reaction");

        audioScr = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Collision":
                audioScr.PlayOneShot(Collision);
                break;

            case "Reaction":
                audioScr.PlayOneShot(Collision);
                break;
        }
    }
}
