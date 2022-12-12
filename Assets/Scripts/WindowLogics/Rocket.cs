using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody2D rb;
    public float rocketSpeed = 5;
    public GameObject explosionEffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(rocketSpeed * Time.deltaTime,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);

        if (collision.gameObject.tag == "Player")
            return;

        var effect = Instantiate(explosionEffect);
        AudioManager.instance.PlayAudio("explosion");
        effect.transform.position = collision.contacts[0].point;
        Destroy(effect, .5f);
        Destroy(collision.gameObject);
    }
}
