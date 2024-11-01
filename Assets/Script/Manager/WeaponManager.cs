using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jy_Mono_Util;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] weaponSelect chosenWeapon;
    [SerializeField] GameObject[] weapons;
    [SerializeField] GameObject Lighter;
    [SerializeField] Animator animator;

    [SerializeField] AudioClip[] weaponAudios;
    private AudioSource audioSource;

    [Header("Arms")]
    [SerializeField] Transform armGameObject;
    void Start()
    {
        audioSource=GetComponent<AudioSource>();

        SaveScript.weaponID=(int)chosenWeapon;

        if(!animator) animator=GetComponent<Animator>();

        ChangeWeapon();
    }

    public void ChangeWeapon()
    {
        foreach(GameObject item in weapons)
        {
            item.SetActive(false);
        }

        weapons[SaveScript.weaponID].SetActive(true);
        animator.SetBool("WeaponChange",true);
        animator.SetInteger("WeaponID",SaveScript.weaponID);
        Invoke(nameof(ResetAnimationBool),0.3f);
        chosenWeapon=(weaponSelect)SaveScript.weaponID;

        MoveFPSArm();
    }

    void ResetAnimationBool()
    {
        animator.SetBool("WeaponChange",false);
    }

    void MoveFPSArm()
    {
        Lighter.SetActive(false);
        switch(chosenWeapon)
        {
            case weaponSelect.Knife:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case weaponSelect.Cleaver:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case weaponSelect.Bat:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case weaponSelect.Axe:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case weaponSelect.Pistol:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case weaponSelect.ShotGun:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.46f);
                break;
            case weaponSelect.SprayCan:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                Lighter.SetActive(true);
                break;
            case weaponSelect.Bottle:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case weaponSelect.Bottle_with_Cloth:
                Lighter.SetActive(true);
                break;
        }
    }

    
    private void Update()
    {
        if(SaveScript.IsInventoryOpen) return;
        if(Input.GetKeyDown(KeyCode.C) && SaveScript.weaponID<weapons.Length-1)
        {
            SaveScript.weaponID++;
            ChangeWeapon();
        }else if(Input.GetKeyDown(KeyCode.X) && SaveScript.weaponID>0){
            SaveScript.weaponID--;
            ChangeWeapon();
        }

        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            
            if(!weaponAudios[SaveScript.weaponID]) return; //if no audio is assigned just skip
            audioSource.clip=weaponAudios[SaveScript.weaponID];
            audioSource.Play();
        }

    }

}
