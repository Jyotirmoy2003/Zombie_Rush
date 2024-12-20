using System.Collections;
using System.Collections.Generic;
using Game_Input;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] InputReader gameInput;
    [SerializeField] LookMode lookMode;
    [SerializeField] GameObject InventoryUI,InventoryWeaponUI,InventoryItemUI,Item_useButtonGameObject;

    [Header("Ref Weapon")]
    [SerializeField] Image bigIcon;
    [SerializeField] Text title,description,weaponAmtText;
    [SerializeField] WeaponManager weaponManager;
    [SerializeField] InventoryItem[] inventoryWeapons;
    [SerializeField] GameObject useButton,combineButton,combinePanel,combineUseButton;
    [SerializeField] Image[] combineItem_Images;

    [Header("Ref Item")]
    [SerializeField] Image bigIcon_item;
    [SerializeField] Text title_item,description_item,itemAmtText;
    [SerializeField] InventoryItem[] inventoryItems;
    

    private int currentSelectedWeapon=0,currentSelectedItem=0;

    void Start()
    {
        Setup();

    }

    void Setup()
    {
        InventoryWeaponUI.SetActive(true);
        InventoryItemUI.SetActive(false);
        InventoryUI.SetActive(false);
        ChoosWeapon(0);
        combinePanel.SetActive(false);
        combineButton.SetActive(false);
    }
    void OnInventoryPressed()
    {
        if(SaveScript.IsInventoryOpen)
        {
            lookMode.SwitchInventory(false);
            InventoryUI.SetActive(false);
          
           
        }else{
            
            lookMode.SwitchInventory(true);
            InventoryUI.SetActive(true);
            OnInventoryInit();
           
        }
        SaveScript.IsInventoryOpen=!SaveScript.IsInventoryOpen;
    }

    void OnInventoryInit()
    {
        ChoosWeapon(SaveScript.weaponID);
        ChoosItem(SaveScript.ItemID);
        for(int i=0;i<inventoryWeapons.Length;i++)
        {
            inventoryWeapons[i].button.interactable=SaveScript.weaponPickedup[i];
        }

        for(int i=0;i<inventoryItems.Length;i++)
        {
            inventoryItems[i].button.interactable=SaveScript.ItemPickedUp[i];
        }

        //set up combine button
        combinePanel.SetActive(currentSelectedWeapon>=6);
        combineButton.SetActive(currentSelectedWeapon>=6);
    }

    public void ListenToInit(Component sender,object data)
    {
        if((bool)data)
        {
            SubcribeToInput(true);
        }
    }

    void SubcribeToInput(bool isSubcribe)
    {
        if(isSubcribe)
        {
            gameInput.OnInventoryEvent+=OnInventoryPressed;
        }else{
            gameInput.OnInventoryEvent-=OnInventoryPressed;
        }
    }









    public void ChoosWeapon(int weponIndex)
    {
        //UI
        bigIcon.sprite=inventoryWeapons[weponIndex].sprite;
        title.text=inventoryWeapons[weponIndex].Title;
        description.text=inventoryWeapons[weponIndex].description;
        weaponAmtText.text="Amts: "+SaveScript.itemAmts[weponIndex].ToString();
        //LOGIC
        AudioManager.instance.PlaySound("Click");
        currentSelectedWeapon=weponIndex;
        combinePanel.SetActive(false);
        combineButton.SetActive(currentSelectedWeapon>5);
    }
    public void ChoosItem(int itemIndex)
    {
        //UI
        bigIcon_item.sprite=inventoryItems[itemIndex].sprite;
        title_item.text=inventoryItems[itemIndex].Title;
        description_item.text=inventoryItems[itemIndex].description;
        itemAmtText.text="Amts: "+SaveScript.itemAmts[itemIndex].ToString();
        //LOGIC
        AudioManager.instance.PlaySound("Click");
        currentSelectedItem=itemIndex;
        //set up use button
        Item_useButtonGameObject.SetActive(itemIndex>=4);
    }




    #region  UI_BUTTONS
    public void InventorySwitch(bool isWeapon)
    {
        
        InventoryWeaponUI.SetActive(isWeapon);
        InventoryItemUI.SetActive(!isWeapon);
        combinePanel.SetActive(false);
        
    }
    public void CombineAssignWeapon()
    {
       
        if(currentSelectedWeapon==6)
        {
            AssignWeapon();
        }else if(currentSelectedWeapon==7)
        {
            SaveScript.weaponID=currentSelectedWeapon+=1;
            AssignWeapon();
           
        }

        AudioManager.instance.PlaySound("Select");
       
    }

    //when use button pressed from weapon menu
    public void AssignWeapon()
    {
        SaveScript.weaponID=currentSelectedWeapon;
        AudioManager.instance.PlaySound("Select");
        weaponManager.ChangeWeapon();
    }

    
    //use button->Item menu
    public void AssignItem()
    {
        SaveScript.ItemID=currentSelectedItem;
        AudioManager.instance.PlaySound("Select");
       
    }
    #endregion



    public void CombineAction()
    {
        combinePanel.SetActive(true);
        
        combineItem_Images[0].color=(SaveScript.ItemPickedUp[2])?new Color(1f,1f,1f,1f):new Color(1f,1f,1f,0.06f);
        combineItem_Images[1].color=(SaveScript.ItemPickedUp[3])?new Color(1f,1f,1f,1f):new Color(1f,1f,1f,0.06f);

        if(currentSelectedWeapon==7)
        {
            combineUseButton.SetActive(SaveScript.ItemPickedUp[2] && SaveScript.ItemPickedUp[3]);
            combineItem_Images[0].gameObject.SetActive(true);
            combineItem_Images[1].gameObject.SetActive(true);
        }else if(currentSelectedWeapon==6)
        {
            combineUseButton.SetActive(SaveScript.ItemPickedUp[2]);
            combineItem_Images[0].gameObject.SetActive(true);
            combineItem_Images[1].gameObject.SetActive(false);
        }
        
    }


}
