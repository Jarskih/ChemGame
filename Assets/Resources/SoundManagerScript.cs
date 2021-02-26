using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip Collision;
    static AudioSource audioScr;
         
    void Start()
    {

        Collision = Resources.Load<AudioClip>("Collision");

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
        }
    }
}
