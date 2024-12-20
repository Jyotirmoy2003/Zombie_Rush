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


public enum E_weaponSelect{
    Knife,
    Cleaver,
    Bat,
    Axe,
    Pistol,
    ShotGun,
    SprayCan,
    Bottle,
    Bottle_with_Cloth
}

public enum E_TypeOf_Weapon{
    Knife,
    Cleaver,
    Bat,
    Axe,
    Pistol,
    ShotGun,
    SprayCan,
    Bottle
}

public enum E_TypeOf_Item{
        flashlight,
        nightvision,
        lighter,
        rags,
        healthPack,
        pills,
        waterBottle,
        apple,
        flashlightBattery,
        nightvisionBattery,
        houseKey,
        cabinKey,
        jerryCan
}

public enum E_Typeof_Ammo{
    gunAmmo,
    shotgunAmmo
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

[System.Serializable]
public struct S_Info
{
    public Sprite sprite;
    public string title;
    public string description;
}

