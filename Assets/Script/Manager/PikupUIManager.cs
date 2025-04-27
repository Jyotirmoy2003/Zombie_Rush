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
    [SerializeField] S_Info[] ammoList;


    void Start()
    {
        pickupPanel.SetActive(false);
    }





    public void ListenToGazeStatus(Component sender,object data)
    {
        if(sender is WeaponType)
        {
            WeaponType tempHoldingWeponType=(WeaponType)sender;
            ShowHidePickupUIWeapon((bool)data,tempHoldingWeponType.GetID());
        }else if(sender is ItemType)
        {
            ItemType tempHoldingItemType=(ItemType)sender;
            ShowHidePickupUIItem((bool)data,tempHoldingItemType.GetID());
        }else if(sender is AmmoType)
        {
            AmmoType tempHoldingAmmotype=(AmmoType)sender;
            ShowHidePickupUIAmmo((bool)data,tempHoldingAmmotype.GetID());
        }else if(sender is IInteractable)
        {
            IInteractable interactable= sender.GetComponent<IInteractable>();
            ShowUIText((bool)data,interactable.Header,interactable.Info);
        }
    }

    void ShowHidePickupUIWeapon(bool show,int id)
    {
        if(show)
        {
            //Show UI panel data
            pickup_Desc_Text.text=weaponInfoList[id].description;
            main_Title_Text.text=weaponInfoList[id].title;
            mainIcon_IMG.sprite=weaponInfoList[id].sprite;
            pickupPanel.SetActive(true);
            
        }else{
            pickupPanel.SetActive(false);
        }
    }
    void ShowHidePickupUIItem(bool show,int id)
    {
        if(show)
        {
            //Show UI panel data
            pickup_Desc_Text.text=itemInfoList[id].description;
            main_Title_Text.text=itemInfoList[id].title;
            mainIcon_IMG.sprite=itemInfoList[id].sprite;
            mainIcon_IMG.enabled=true;
            pickupPanel.SetActive(true);
         
        }else{
            pickupPanel.SetActive(false);
        }
    }

    void ShowUIText(bool show=false,string header="",string info="")
    {
        if(show)
        {
            //Show UI panel data
            pickup_Desc_Text.text=info;
            main_Title_Text.text=header;
            mainIcon_IMG.enabled=false;
            pickupPanel.SetActive(true);
         
        }else{
            pickupPanel.SetActive(false);
        }
    }

    void ShowHidePickupUIAmmo(bool show,int id)
    {
        if(show)
        {
            //Show UI panel data
            pickup_Desc_Text.text=ammoList[id].description;
            main_Title_Text.text=ammoList[id].title;
            mainIcon_IMG.sprite=ammoList[id].sprite;
            mainIcon_IMG.enabled=true;
            pickupPanel.SetActive(true);
         
        }else{
            pickupPanel.SetActive(false);
        }
    }

}
