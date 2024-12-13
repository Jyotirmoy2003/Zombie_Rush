using System.Collections;
using System.Collections.Generic;
using Game_Input;
using UnityEngine;
using UnityEngine.UI;


public class PickupsScript : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] InputReader gameInput;
    [SerializeField] float picupDisplayDistacne=8f;
    [SerializeField] LayerMask excludeLayers;
    [SerializeField] GameEvent interactEvent;


   
    private RaycastHit hit;
    private int ObjId=0;
    private IInteractable currentInteractingObj;


    void Start()
    {
        
    }
    #region INPUT Bind
    private void OnEnable()
    {
        gameInput.OnInteractEvent+=OnInteract;
    }
    
    private void OnDisable()
    {
        gameInput.OnInteractEvent-=OnInteract;
    }


    #endregion

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

       
    }

    void UnHoverLastSelectedObj()
    {
        if(currentInteractingObj!=null)
        {
            currentInteractingObj.UnHover();
            currentInteractingObj=null;  
        }
    }


    void HovernewObject(IInteractable newObj)
    {
        if(currentInteractingObj!=null) UnHoverLastSelectedObj();
        
        currentInteractingObj=newObj;
        ObjId=currentInteractingObj.Hover();

        
    }

    void OnInteract()
    {
        if(currentInteractingObj==null) return;

        currentInteractingObj.Interact();
        //SaveScript.weponAmts[ObjId]++;
        //Event raise
        interactEvent.Raise(this,currentInteractingObj);

        AudioManager.instance.PlaySound("Pickup");
    }
}
