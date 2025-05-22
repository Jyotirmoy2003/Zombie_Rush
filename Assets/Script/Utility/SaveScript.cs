using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Jy_Mono_Util;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
   public static bool IsInventoryOpen = false;
   public static int weaponID = 0;
   public static int ItemID = 0;
   public static bool[] weaponPickedup = new bool[8];
   public static bool[] ItemPickedUp = new bool[13];
   public static int[] weponAmts = new int[8];
   public static int[] itemAmts = new int[8];
   public static int[] ammoAmts = new int[2];
   public static int[] currentAmmo = new int[9];

   void Start()
   {
      weaponPickedup[0] = true;
      weponAmts[0] = 1;

      ItemPickedUp[0] = true;
      ItemPickedUp[1] = true;
      itemAmts[0] = 1;
      itemAmts[1] = 1;

      InitValue();
   }

   void InitValue()
   {
      for (int i = 0; i < currentAmmo.Length; i++)
      {
         currentAmmo[i] = 2;
      }

      currentAmmo[4] = 12;
   }





   //Listen to event when player interact with something 
   public void ListenToWeponPickup(Component sender, object data)
   {
      if (data is IInteractable)
      {
         if (data is WeaponType)
         {
            WeaponType tempHoldingWepontype = (WeaponType)data;
            if (tempHoldingWepontype)
            {
               AddWeapon(tempHoldingWepontype.GetID());
            }

         }
         else if (data is ItemType)
         {

            ItemType tempHoldingItemType = (ItemType)data;
            if (tempHoldingItemType)
            {
               AddItem(tempHoldingItemType.GetID());
            }
         }
         else if (data is AmmoType)
         {
            AmmoType tempHoldingAmmoType = (AmmoType)data;
            if (tempHoldingAmmoType)
            {
               AddAmmo(tempHoldingAmmoType.chooseAmmo);
               
               //update ammo ui
               GameAssets.Instance.weaponUIUpdateEvent.Raise(this, true);
            }
         }

      }
   }





   #region  ADD&REMOVE OPERATIONS


   void AddWeapon(int id)
   {
      weponAmts[id]++;
      weaponPickedup[id] = true;
   }

   void RemoveWepon(int id)
   {
      weponAmts[id]--;

      weaponPickedup[id] = (weponAmts[id] > 0) ? true : false;
   }


   void AddItem(int id)
   {
      itemAmts[id]++;
      ItemPickedUp[id] = true;
   }

   void RemoveItem(int id)
   {
      itemAmts[id]--;

      ItemPickedUp[id] = (itemAmts[id] > 0) ? true : false;
   }

   void AddAmmo(E_Typeof_Ammo e_Typeof_Ammo)
   {
      switch (e_Typeof_Ammo)
      {
         case E_Typeof_Ammo.gunAmmo:
            ammoAmts[0] += 30;
            break;
         case E_Typeof_Ammo.shotgunAmmo:
            ammoAmts[1] += 10;
            break;
      }
   }
   #endregion
}
