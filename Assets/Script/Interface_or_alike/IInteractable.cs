using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IInteractable 
{
   public void Interact();
   public int Hover();
   public int UnHover();
   public int GetID();
}
