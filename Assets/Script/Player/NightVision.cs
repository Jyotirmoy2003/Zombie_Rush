using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Jy_Mono_Util;
using UnityEngine.TextCore;
using Game_Input;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.Utility;

public class NightVision : BatterySystem
{
    [Header("Reference Night Vision")]
    [SerializeField] Image zoomBar;
    [SerializeField] Camera cam;
    [SerializeField] GameObject nightVisionOverlay;
    [SerializeField] LookMode lookMode;
  
   
  
   
    

    void NightVisionUpdate()
    {
        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if(cam.fieldOfView>10)
            {
                cam.fieldOfView-=5;
                zoomBar.fillAmount=cam.fieldOfView/100f;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            if(cam.fieldOfView<60)
            {
                cam.fieldOfView+=5;
                zoomBar.fillAmount=cam.fieldOfView/100f;
            }
        }
        UpdateBattery();
    }

    public void AcitvateNightVision(bool IsActive)
    {
        if(IsActive && IsBatteryUsable)
        {
            cam.fieldOfView=60;
            zoomBar.fillAmount=0.6f;
            UpdateDel=NightVisionUpdate;
            nightVisionOverlay.SetActive(true);
        }else{
            cam.fieldOfView=60;
            zoomBar.fillAmount=0.6f;
            UpdateDel=new Jy_Utility().NullFun;
            nightVisionOverlay.SetActive(false);
        }
    }

    #region  EVENT
    public void ListenToBatteryConsumed(Component sender,object data)
    {
       
        if((bool)data && !IsBatteryUsable)
        {
            AcitvateNightVision(false);
           
        }
    }


    
    #endregion
   
    
}

