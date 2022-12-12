using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public AppUIHandler appUI;
    public GamePlayManager gamePlayManager;
    public LevelManager levelManager;
    public GameObject winPanel;

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        gamePlayManager = this.GetComponent<GamePlayManager>();
        levelManager = this.GetComponent<LevelManager>();
        appUI = GameObject.FindGameObjectWithTag("AppUI").GetComponent<AppUIHandler>();
        Cursor.visible = true;
    }

    public Vector2 GetPlayerPosition()
    {
        return player.transform.position;
    }

    public void Win()
    {
        Debug.Log("Win");
        winPanel.SetActive(true);
    }
}
