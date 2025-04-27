using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameInput;



namespace Game_Input
{
    

[CreateAssetMenu(fileName ="New Input Reader",menuName ="GAME/Input/Input Reader")]
public class InputReader : ScriptableObject,IGameActions
{
    public event Action<bool> OnJumpEvent,OnRunEvent,onFirePress;
    public event Action OnFlashlightEvent,OnNightVisionEvent,OnInventoryEvent,OnInteractEvent;
    public event Action<Vector2> OnMoveEvent; 
    public event Action<Double> OnZoomEvent;
    private GameInput inputActions;



    private void OnEnable()
    {
        if(inputActions==null)
        {
            inputActions=new GameInput();
            inputActions.Game.SetCallbacks(this);
        }
        inputActions.Game.Enable();
    }

   
    private void OnDisable()
    {
        inputActions.Game.Disable();
    }






    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnFlashlight(InputAction.CallbackContext context)
    {
        if(context.performed) OnFlashlightEvent?.Invoke();
    }

    public void OnNightVision(InputAction.CallbackContext context)
    {
        if(context.performed) OnNightVisionEvent?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed) OnJumpEvent?.Invoke(true);
        else if(context.canceled) OnJumpEvent?.Invoke(false);
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.performed) OnRunEvent?.Invoke(true);
        else if(context.canceled) OnRunEvent?.Invoke(false);
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        OnZoomEvent?.Invoke(context.ReadValue<Double>());
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if(context.performed) OnInventoryEvent?.Invoke();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed) OnInteractEvent?.Invoke();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed) onFirePress?.Invoke(true);
        else if(context.canceled) onFirePress?.Invoke(false);
    }
    
    
    
    
    }
}