using System.Collections;
using System.Collections.Generic;
using Jy_Mono_Util;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    //any building id 50-60
    [SerializeField] int ID=51;
    [SerializeField] GameEvent gazeEvent;
    public E_Typeof_Door chooseDoorType;
   public bool isOpen=false;
   public bool isLocked=false;
   private bool isPlayingFeedback=false;
   [SerializeField] FeedBackManager doorOpenFeedback,doorCloseFeedback;
   private Outline outline;

    public int GetID()
    {
        return ID;
    }

    public int Hover()
    {
        if(outline)outline.enabled=true;
        gazeEvent.Raise(this,true);
        return ID;
    }

    public void Interact()
    {
        if(isPlayingFeedback) return;
        if(isOpen)
        {
            doorCloseFeedback.PlayFeedback();
            doorCloseFeedback.CompletePlayingFeedback+=FullyClosed;
        }else{
            doorOpenFeedback.PlayFeedback();
            doorOpenFeedback.CompletePlayingFeedback+=FullyOpened;
        }
    }

    public int UnHover()
    {
        if(outline)outline.enabled=false;
        gazeEvent.Raise(this,false);
        return ID;
    }

    void Start()
    {
        if(!outline) outline=GetComponent<Outline>();
        outline.enabled=false;
    }

    void FullyOpened()
    {
        isOpen=true;
        doorOpenFeedback.CompletePlayingFeedback-=FullyOpened;
        isPlayingFeedback=false;
    }

    void FullyClosed()
    {
        isOpen=false;
        doorCloseFeedback.CompletePlayingFeedback-=FullyClosed;
        isPlayingFeedback=false;
    }

}
