using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private GamePlayManager gamePlayManager;
    private AudioManager audioManager;

    private void Start()
    {
        gamePlayManager = GameManager.instance.gamePlayManager;
        audioManager = AudioManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectibleHandler(collision);

        //Platform
        if (collision.CompareTag("Ground"))
        {
            collision.transform.parent.GetComponent<ClickAndDrag>().enabled = false;
        }

        if (collision.CompareTag("Door"))
        {
            GameManager.instance.Win();
            collision.transform.parent.GetComponent<ClickAndDrag>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            Destroy(collision.transform.parent.gameObject);
        }

        //Platform
        if (collision.CompareTag("Ground"))
        {
            collision.transform.parent.GetComponent<ClickAndDrag>().enabled = true;
        }

    }

    private void CollectibleHandler(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            Collectible collectible = collision.GetComponent<Collectible>();
            if (collectible == null)
                return;
            audioManager.PlayAudio("collectible");
            if (collectible.GetCollectibleType == CollectibleType.Platform)
            {
                gamePlayManager.AddButtonAmounts(CollectibleType.Platform);
            }

            if (collectible.GetCollectibleType == CollectibleType.RPG)
            {
                gamePlayManager.AddButtonAmounts(CollectibleType.RPG);
            }

            if (collectible.GetCollectibleType == CollectibleType.Ladder)
            {
                gamePlayManager.AddButtonAmounts(CollectibleType.Ladder);
            }

            if (collectible.GetCollectibleType == CollectibleType.Door)
            {
                gamePlayManager.AddButtonAmounts(CollectibleType.Door);
            }

            Destroy(collision.gameObject);
        }
    }
}
