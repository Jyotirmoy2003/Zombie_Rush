using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Jy_Mono_Util;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(FeedBackManager))]
public class ItemType : MonoBehaviour,IInteractable
{
    public E_TypeOf_Item chooseItem;
    [SerializeField] GameEvent gazeEvent;
    private Outline outline;
    private Transform playerTranform;
    private FeedBackManager feedBackManager;
    void Start()
    {
        SetupOutline();
        feedBackManager=GetComponent<FeedBackManager>();
        playerTranform=FindObjectOfType<FirstPersonController>().transform;
    }


    #region INTERFACE
    public int Hover()
    {
        if(outline)outline.enabled=true;
        gazeEvent.Raise(this,true);
        return (int)chooseItem;
    }

    public void Interact()
    {
        if(feedBackManager)feedBackManager.PlayFeedback();
        MoveToPlayer(playerTranform.position);
        Destroy(this.gameObject,0.5f);
    }

    public int UnHover()
    {
        if(outline)outline.enabled=false;
        gazeEvent.Raise(this,false);
        return (int)chooseItem;
    }
    public int GetID()
    {
        return (int) chooseItem;
    }
    #endregion

    void SetupOutline()
    {
        outline=GetComponent<Outline>();
        outline.OutlineMode=Outline.Mode.OutlineVisible;
        outline.OutlineWidth=10f;
        outline.enabled=false;
    }

    void MoveToPlayer(Vector3 destination)
    {
        transform.DOMove(destination,0.5f); //move to the position provided in the vector in 1 second.
    }
}
