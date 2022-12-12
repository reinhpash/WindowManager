using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] CollectibleType type;
    public CollectibleType GetCollectibleType { get { return type; } }

}



    public enum CollectibleType
{
    Platform,
    Ladder,
    RPG,
    Door
}
