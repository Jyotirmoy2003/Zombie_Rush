using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickupsScript : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] float picupDisplayDistacne=8f;
    [SerializeField] LayerMask excludeLayers;
    [SerializeField] S_WepomInfo[] weaponInfoList;


    [Header("UI Element ref")]
    [SerializeField] GameObject pickupPanel;
    [SerializeField] Image mainIcon_IMG;
    [SerializeField] Text main_Title_Text,pickup_Desc_Text;

    private RaycastHit hit;
    private int ObjId=0;
    private IInteractable currentInteractingObj;


    void Start()
    {
        pickupPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.SphereCast(transform.position,0.5f,transform.forward,out hit,picupDisplayDistacne,~excludeLayers))
        {

            if(hit.collider.TryGetComponent<IInteractable>(out currentInteractingObj ))
            {
                HovernewObject(currentInteractingObj);

            }else{
                UnHoverLastSelectedObj();
            }
        }else{
            UnHoverLastSelectedObj();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }
    }

    void UnHoverLastSelectedObj()
    {
        if(currentInteractingObj!=null)
        {
            currentInteractingObj.UnHover();
            currentInteractingObj=null;
            pickupPanel.SetActive(false);   
        }
    }


    void HovernewObject(IInteractable newObj)
    {
        if(currentInteractingObj!=null) UnHoverLastSelectedObj();
        
        currentInteractingObj=newObj;
        ObjId=currentInteractingObj.Hover();

        //Show UI panel data
        pickup_Desc_Text.text=weaponInfoList[ObjId].description;
        main_Title_Text.text=weaponInfoList[ObjId].title;
        mainIcon_IMG.sprite=weaponInfoList[ObjId].sprite;
        pickupPanel.SetActive(true);
    }

    void OnInteract()
    {
        if(currentInteractingObj==null) return;

        currentInteractingObj.Interact();
        SaveScript.weponAmts[ObjId]++;

        AudioManager.instance.PlaySound("Pickup");
    }
}
