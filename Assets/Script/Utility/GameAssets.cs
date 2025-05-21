using System.Collections;
using System.Collections.Generic;
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
    public GameEvent weaponFiredEvent;
    public GameEvent weponChangedEvent;
}
