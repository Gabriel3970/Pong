using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
     
    public AudioSource asSounds;
    public AudioClip paddleSound;
    
    public void PlayPaddleSound()
    {
        asSounds.PlayOneShot(paddleSound);
    }
}
