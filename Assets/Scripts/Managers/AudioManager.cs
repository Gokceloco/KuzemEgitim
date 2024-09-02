using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource jumpAS;
    public AudioSource positiveAS;
    public AudioSource ambientAS;
    public AudioSource hornAS;

    private void Start()
    {
        PlayAmbientSound();
    }
    public void PlayJumpSound()
    {
        jumpAS.Play();
    }
    public void PlayPositiveSound()
    {
        positiveAS.Play();
    }
    public void PlayAmbientSound()
    {
        ambientAS.Play();
    }

    internal void PlayHornSound()
    {
        hornAS.Play();
    }
}
