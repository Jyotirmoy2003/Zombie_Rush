using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jy_Mono_Util;
using Game_Input;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] InputReader gameInputReader;
    [SerializeField] E_weaponSelect chosenWeapon;
    [SerializeField] GameObject[] weapons;
    [SerializeField] GameObject Lighter;
    [SerializeField] Animator animator;

    [SerializeField] AudioClip[] weaponAudios;
    private AudioSource audioSource;

    [Space]
    [Header("MuzzleFlash")]
    [SerializeField] ParticleSystem muzzleFlashPistol;
    [SerializeField] ParticleSystem muzzleFlashShotgun;

    [Header("Arms")]
    [SerializeField] Transform armGameObject;
    void Start()
    {
        audioSource=GetComponent<AudioSource>();

        SaveScript.weaponID=(int)chosenWeapon;

        if(!animator) animator=GetComponent<Animator>();

        ChangeWeapon();

        SubscribeToInput(true);
    }

    
    private void OnDestroy()
    {
        SubscribeToInput(false);
    }

    void SubscribeToInput(bool val)
    {
        if(val)
        {
            gameInputReader.onFirePress+=Fire;
        }else
        {
            gameInputReader.onFirePress-=Fire;
        }
    }

    void Fire(bool press)
    {
        
        if(press)AttackWithWeapon();
    }

    public void ChangeWeapon()
    {
        foreach (GameObject item in weapons)
        {
            item.SetActive(false);
        }

        weapons[SaveScript.weaponID].SetActive(true);
        animator.SetBool("WeaponChange", true);
        animator.SetInteger("WeaponID", SaveScript.weaponID);
        Invoke(nameof(ResetAnimationBool), 0.3f);
        chosenWeapon = (E_weaponSelect)SaveScript.weaponID;

        MoveFPSArm();
        //Fire event when wepon changed
        GameAssets.Instance.weponChangedEvent.Raise(this, SaveScript.weaponID);
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
            case E_weaponSelect.Knife:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case E_weaponSelect.Cleaver:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case E_weaponSelect.Bat:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case E_weaponSelect.Axe:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case E_weaponSelect.Pistol:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case E_weaponSelect.ShotGun:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.46f);
                break;
            case E_weaponSelect.SprayCan:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                Lighter.SetActive(true);
                break;
            case E_weaponSelect.Bottle:
                armGameObject.localPosition=new Vector3(0.02f,-0.193f,0.66f);
                break;
            case E_weaponSelect.Bottle_with_Cloth:
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

        // if(Input.GetMouseButtonDown(0))
        // {
        //     AttackWithWeapon();
        // }

    }

    void AttackWithWeapon()
    {

        if(SaveScript.currentAmmo[SaveScript.weaponID]>0)
        {

            animator.SetTrigger("Attack");

            //decrease ammo for pistol and shotgun only
            if (SaveScript.weaponID == 4 || SaveScript.weaponID == 5)
            {
                SaveScript.currentAmmo[SaveScript.weaponID]--;
                muzzleFlashPistol.Play();
                muzzleFlashShotgun.Play();
                GameAssets.Instance.weaponFiredEvent.Raise(this, true);
            }
            //Audio   
            if(!weaponAudios[SaveScript.weaponID]) return; //if no audio is assigned just skip
            audioSource.clip=weaponAudios[SaveScript.weaponID];
            audioSource.Play();

        }else{
            if(SaveScript.weaponID == 4 || SaveScript.weaponID == 5 )
            {
                audioSource.clip = GameAssets.Instance.weponEmptyClick;
                audioSource.Play();
            }
        }
    }

    

}
