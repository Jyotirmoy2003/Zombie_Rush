using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Game_Input;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LookMode : MonoBehaviour
{
    [SerializeField] NightVision nightVision;
    [SerializeField] FlashLight flashLight;
    [SerializeField] InputReader inputReader;
    [Header("Post Processing Vol")]
    [SerializeField] PostProcessVolume vol;

    [SerializeField] PostProcessProfile nightVisionProfile,normalVison,inventoryProfile;
    private bool IsNightVisionActive=false,isFalshLightActive=false;
  
  
    

    void Start()
    {
        vol.profile=normalVison;
        
    }

    public void SwitchNightVision(bool val)
    {
        if(val)
        {
            vol.profile=nightVisionProfile;
        }else{
            vol.profile=normalVison;
        }
    }

    public void SwitchInventory(bool val)
    {
        if(val)
        {
            //deactivate Night vision if active
            nightVision.AcitvateNightVision(false);
            SwitchNightVision(false);

            flashLight.FlashLightActivateStatus(false);
            isFalshLightActive=false;

            vol.profile=inventoryProfile;
            Cursor.lockState=CursorLockMode.None;
            Cursor.visible=true;
        }else{
            vol.profile=normalVison;
            Cursor.lockState=CursorLockMode.Locked;
            Cursor.visible=false;
        }
    }

 #region  INPUT
    void SubcribeInput(bool IsSubcribe)
    {
        if(IsSubcribe)
        {
            inputReader.OnNightVisionEvent+=NightVisionButton;
            inputReader.OnFlashlightEvent+=FlashLightButton;
        }else{
            inputReader.OnNightVisionEvent-=NightVisionButton;
            inputReader.OnFlashlightEvent-=FlashLightButton;
        }
    }

    void NightVisionButton()
    {
        if(SaveScript.IsInventoryOpen) return;
        
        nightVision.AcitvateNightVision(!IsNightVisionActive);
        SwitchNightVision(!IsNightVisionActive);
        IsNightVisionActive=!IsNightVisionActive;
       
    }

     void FlashLightButton()
    {
        if(SaveScript.IsInventoryOpen) return;

       flashLight.FlashLightActivateStatus(!isFalshLightActive);
       isFalshLightActive=!isFalshLightActive;
    }
    #endregion

    public void ListenToInit(Component sender,object data)
    {
        if((bool)data)
        {
            SubcribeInput(true);
        }
    }
    
}
