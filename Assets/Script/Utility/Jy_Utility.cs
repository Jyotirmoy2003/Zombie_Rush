using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jy_Mono_Util{
public class Jy_Utility : MonoBehaviour
{
    public void NullFun()
    {

    }
}


public enum weaponSelect{
    Knife,
    Cleaver,
    Bat,
    Axe,
    Pistol,
    ShotGun,
    SprayCan,
    Bottle,
}
public delegate void NoArgumentFun();
}

[System.Serializable]
public struct InventoryItem
{
    public Button button;
    public Sprite sprite;
    public string Title;
    public string description;
}