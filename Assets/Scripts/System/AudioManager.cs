using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip clickSound;
    public AudioClip rocketSound;
    public AudioClip explosionSound;
    public AudioClip jumpSound;
    public AudioClip stepSound;
    public AudioClip collectibleSound;

    private void Awake()
    {
        instance = this;
    }

    public void PlayAudio(string soundName)
    {
        if (soundName == "click")
        {
            AudioSource.PlayClipAtPoint(clickSound, Vector3.zero);
        }
        else if (soundName == "rocket")
        {
            AudioSource.PlayClipAtPoint(rocketSound, Vector3.zero);
        }
        else if (soundName == "explosion")
        {
            AudioSource.PlayClipAtPoint(explosionSound, Vector3.zero);
        }
        else if (soundName == "jump")
        {
            AudioSource.PlayClipAtPoint(jumpSound, Vector3.zero);
        }
        else if (soundName == "step")
        {
            AudioSource.PlayClipAtPoint(stepSound, Vector3.zero);
        }
        else if (soundName == "collectible")
        {
            AudioSource.PlayClipAtPoint(collectibleSound, Vector3.zero);
        }
        else
        {
            AudioSource.PlayClipAtPoint(clickSound, Vector3.zero);
        }

    }
}
