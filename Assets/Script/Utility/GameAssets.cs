using System.Collections;
using System.Collections.Generic;
using Game_Input;
using UnityEngine;

public class GameAssets : MonoSingleton<GameAssets>
{
    [Space]
    [Header("Transform ref")]
    public Transform playerTransform;

    [Header("Aduio")]
    public AudioClip weponEmptyClick;

    [Space]
    [Header("Events")]
    public GameEvent gazeEvent;
    public GameEvent weaponUIUpdateEvent;
    public GameEvent weponChangedEvent;

    [Space]
    [Header("Input")]
    public InputReader gameInput;
}
