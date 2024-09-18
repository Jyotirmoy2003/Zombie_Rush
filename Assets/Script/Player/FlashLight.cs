using System.Collections;
using System.Collections.Generic;
using Game_Input;
using Jy_Mono_Util;
using UnityEngine;

public class FlashLight : BatterySystem
{
    [SerializeField] GameObject flashLightUI;
    [SerializeField] Light spotLight;
   

   public void FlashLightActivateStatus(bool val)
   {
       
          flashLightUI.SetActive(val);
          spotLight.enabled=val;
          if(val)
          {
               UpdateDel=UpdateBattery;
          }else{
               UpdateDel=new Jy_Utility().NullFun;
          }

        
   }
 #region  EVENT
    public void ListenToBatteryConsumed(Component sender,object data)
    {
       
        if((bool)data && !IsBatteryUsable)
        {
            FlashLightActivateStatus(false);
            //SubcribeInput(false);
        }
    }


  
    #endregion


  

    
}
