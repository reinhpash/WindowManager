using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Platform : MonoBehaviour
{
    public TextMeshPro counterText;
    float startTime;
    float endTime;
    public float windowTime = 5;
    void Start()
    {
        startTime = Time.time;
        endTime = startTime + windowTime;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCounter();
    }

    private void HandleCounter()
    {
        counterText.SetText(Mathf.RoundToInt((endTime - Time.time)).ToString());
        if (Time.time >= endTime)
        {
            Destroy(this.gameObject);
        }
    }
}
