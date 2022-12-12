using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public GameObject PlatformWindow;
    public GameObject RpgWindow;
    public GameObject LadderWindow;
    public GameObject DoorWindow;

    private GameManager gameManager;
    private AppUIHandler appUIHandler;

    public Vector2 WindowOffset = new Vector2(3,3);

    public GameObject PlatformIco;
    public int platformAmount = 2;
    private int currentPlatformAmount;
    public GameObject RpgIco;
    public int rpgAmount = 2;
    private int currentRpgAmount;
    public GameObject LadderIco;
    public int ladderAmount = 2;
    private int currentLadderAmount;
    public GameObject DoorIco;



    private void Start() => Initialize();

    public void Initialize()
    {
        DoorIco.SetActive(false);
        SetReferences();
        SetProperties();
        SetTexts();
    }

    private void SetReferences()
    {
        gameManager = GameManager.instance;
        appUIHandler = gameManager.appUI;
    }

    private void SetTexts()
    {
        appUIHandler.SetPlatformButtonText(currentPlatformAmount);
        appUIHandler.SetRpgButtonText(currentRpgAmount);
        appUIHandler.SetLadderButtonText(currentLadderAmount);
    }

    private void SetProperties()
    {
        currentPlatformAmount = platformAmount;
        currentRpgAmount = rpgAmount;
        currentLadderAmount = ladderAmount;

        HandleButtonAmounts();
    }

    public void InstanceWindow(int type)
    {
        if (type == 1)
        {
            var platform = GameObject.Instantiate(PlatformWindow);
            platform.transform.position = Vector2.zero;
            currentPlatformAmount--;
        }
        else if (type == 2)
        {
            var rpg = GameObject.Instantiate(RpgWindow);
            rpg.transform.position = Vector2.zero;
            currentRpgAmount--;
        }
        else if (type == 3)
        {
            var ladder = GameObject.Instantiate(LadderWindow);
            ladder.transform.position = Vector2.zero;
            currentLadderAmount--;
        }
        else if (type == 4)
        {
            var door = GameObject.Instantiate(DoorWindow);
            door.transform.position = Vector2.zero;
            DoorIco.SetActive(false);
        }
        else
        {
            Debug.Log("Hatalý Button");
        }

        HandleButtonAmounts();

    }

    void HandleButtonAmounts()
    {
        appUIHandler.SetPlatformButtonText(currentPlatformAmount);
        appUIHandler.SetRpgButtonText(currentRpgAmount);
        appUIHandler.SetLadderButtonText(currentLadderAmount);

        if (currentPlatformAmount <= 0)
        {
            PlatformIco.SetActive(false);
        }
        else if(currentPlatformAmount > 0)
        {
            PlatformIco.SetActive(true);
        }

        if (currentRpgAmount <= 0)
        {
            RpgIco.SetActive(false);
        }
        else if (currentRpgAmount > 0)
        {
            RpgIco.SetActive(true);
        }

        if (currentLadderAmount <= 0)
        {
            LadderIco.SetActive(false);
        }
        else if (currentLadderAmount > 0)
        {
            LadderIco.SetActive(true);
        }
    }

    public void AddButtonAmounts(CollectibleType type)
    {
        if (type == CollectibleType.Platform)
        {
            currentPlatformAmount++;
        }

        if (type == CollectibleType.RPG)
        {
            currentRpgAmount++;
        }

        if (type == CollectibleType.Ladder)
        {
            currentLadderAmount++;
        }

        if (type == CollectibleType.Door)
        {
            DoorIco.SetActive(true);
        }

        HandleButtonAmounts();
    }
}
