using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.instance;
    }
    public void PlaySound()
    {
        audioManager.PlayAudio("step");
    }
}
