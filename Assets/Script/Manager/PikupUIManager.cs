using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PikupUIManager : MonoBehaviour
{
    [Header("UI Element ref")]
    [SerializeField] GameObject pickupPanel;
    [SerializeField] Image mainIcon_IMG;
    [SerializeField] Text main_Title_Text,pickup_Desc_Text;

    [Header("Settings")]
    [SerializeField] S_Info[] weaponInfoList;
    [SerializeField] S_Info[] itemInfoList;


    void Start()
    {
        pickupPanel.SetActive(false);
    }





    public void ListenToGazeStatus(Component sender,object data)
    {
        if(sender is WeaponType)
        {
            WeaponType tempHoldingWeponType=(WeaponType)sender;
            ShowHidePickupUI(true,(bool)data,tempHoldingWeponType.GetID());
        }else if(sender is ItemType)
        {
            ItemType tempHoldingItemType=(ItemType)sender;
            ShowHidePickupUI(false,(bool)data,tempHoldingItemType.GetID());
        }
    }

    void ShowHidePickupUI(bool isWeapon,bool show,int id)
    {
        if(show)
        {
            //Show UI panel data
            if(isWeapon)
            {
                pickup_Desc_Text.text=weaponInfoList[id].description;
                main_Title_Text.text=weaponInfoList[id].title;
                mainIcon_IMG.sprite=weaponInfoList[id].sprite;
                pickupPanel.SetActive(true);
            }else{
                pickup_Desc_Text.text=itemInfoList[id].description;
                main_Title_Text.text=itemInfoList[id].title;
                mainIcon_IMG.sprite=itemInfoList[id].sprite;
                pickupPanel.SetActive(true);
            }
        }else{
            pickupPanel.SetActive(false);
        }
    }

}
