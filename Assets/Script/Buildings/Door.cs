using System.Collections;
using System.Collections.Generic;
using Jy_Mono_Util;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(FeedBackManager))]
public class Door : MonoBehaviour,IInteractable
{
    //any building id 50-60
    [SerializeField] int ID=51;
    [SerializeField] GameEvent gazeEvent;
    [SerializeField] string headerText,infoText;
    [SerializeField] AudioClip audioClip;
    public E_Typeof_Door chooseDoorType;
   public bool isOpen=false;
   public bool isLocked=false;
   [SerializeField]private bool isPlayingFeedback=false;
   [SerializeField] FeedBackManager doorOpenFeedback,doorCloseFeedback;
   private Outline outline;
   private AudioSource doorAudio;

    public string Header { get ; set ; }
    public string Info { get ; set ; }

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
        if(isPlayingFeedback || isLocked) return;
        if(isOpen)
        {
            doorCloseFeedback.PlayFeedback();
            doorCloseFeedback.CompletePlayingFeedback+=FullyClosed;
            isPlayingFeedback = true;
        }else {
            doorOpenFeedback.PlayFeedback();
            doorOpenFeedback.CompletePlayingFeedback+=FullyOpened;
            isPlayingFeedback = true;
        }

        doorAudio.Play();
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
        Header=headerText;
        Info=infoText;
        if(isLocked)
        {
            Info="Locked! Need "+chooseDoorType+" key";
        }
        
        doorAudio = GetComponent<AudioSource>();
        doorAudio.clip=audioClip;

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
