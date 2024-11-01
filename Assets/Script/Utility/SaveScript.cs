using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
   public static bool IsInventoryOpen=false;
   public static int weaponID=0;
   public static int ItemID=0;
   public static bool[] weaponPickedup=new bool[8];
   public static bool[] ItemPickedUp=new bool[13];

   void Start()
   {
    weaponPickedup[0]=true;
    weaponPickedup[2]=true;
    weaponPickedup[6]=true;
    weaponPickedup[7]=true;

    ItemPickedUp[0]=true;
    ItemPickedUp[1]=true;
    ItemPickedUp[2]=true;
    ItemPickedUp[3]=true;
   }
}
