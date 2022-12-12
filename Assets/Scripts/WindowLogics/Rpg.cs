using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rpg : MonoBehaviour
{
    public GameObject rocket;
    public Transform rocketPos;

    public void OnClickRocket()
    {
        AudioManager.instance.PlayAudio("rocket");
        var obj = Instantiate(rocket.gameObject);
        obj.transform.position = rocketPos.position;
        Destroy(this.gameObject);
    }
}
