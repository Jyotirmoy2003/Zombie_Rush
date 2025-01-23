using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IInteractable 
{
   public string Header {get;set;}
   public string Info {get;set;}
   public void Interact();
   public int Hover();
   public int UnHover();
   public int GetID();
}
