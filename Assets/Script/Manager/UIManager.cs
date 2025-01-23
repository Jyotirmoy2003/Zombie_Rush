using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] GameObject cursorButtonImageGameObject;
    void Start()
    {
        cursorButtonImageGameObject.SetActive(false);
    }

    public void ListenToGazeStatus(Component sender,object  data)
    {
        if(sender is IInteractable)
        {
            cursorButtonImageGameObject.SetActive((bool)data);
        }
    }

    
}
