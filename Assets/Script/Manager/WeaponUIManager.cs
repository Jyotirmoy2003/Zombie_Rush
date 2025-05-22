using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIManager : MonoSingleton<WeaponUIManager>
{
    [Header("Panels")]
    [SerializeField] GameObject pistolPanel;
    [SerializeField] GameObject shotGunPanel;
    [SerializeField] GameObject sprayPanel;

    [Header("Texts")]
    [SerializeField] Text pistolCurrentAmmo;
    [SerializeField] Text pistolTotalAmmo;
    [SerializeField] Text shotGunCurrentAmmo;
    [SerializeField] Text shotGunTotalAmmo;
    void Start()
    {
        pistolPanel.SetActive(false);
        shotGunPanel.SetActive(false);
        sprayPanel.SetActive(false);
    }



    public void ListnToOnUIUpdate(Component sender, object data)
    {
        UpdateWeponUIData();
    }

    public void ListnToWeaponChanged(Component sender, object data)
    {

        pistolPanel.SetActive((int)data == 4);
        shotGunPanel.SetActive((int)data == 5);
        UpdateWeponUIData();

    }

    void UpdateWeponUIData()
    {
        if (SaveScript.weaponID == 4)
        {
            //pistol
            pistolCurrentAmmo.text = SaveScript.currentAmmo[SaveScript.weaponID].ToString();
            pistolTotalAmmo.text = "/ " + SaveScript.ammoAmts[0].ToString();
        }
        else
        {
            //Shotgun
            shotGunCurrentAmmo.text = SaveScript.currentAmmo[SaveScript.weaponID].ToString();
            shotGunTotalAmmo.text = "/ " + SaveScript.ammoAmts[1].ToString();
        }
    }

    public void SetSprayAmount(float value)
    {
        
    }
}
