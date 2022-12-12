using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppUIHandler : MonoBehaviour
{
    public TextMeshProUGUI platformButtonAmount;
    public TextMeshProUGUI ladderButtonAmount;
    public TextMeshProUGUI rpgButtonAmount;


    public void SetPlatformButtonText(int amount)
    {
        platformButtonAmount.SetText(amount.ToString());
    }

    public void SetLadderButtonText(int amount)
    {
        ladderButtonAmount.SetText(amount.ToString());
    }

    public void SetRpgButtonText(int amount)
    {
        rpgButtonAmount.SetText(amount.ToString());
    }
}
