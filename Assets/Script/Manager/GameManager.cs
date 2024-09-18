using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameEvent InitEvent;
    [SerializeField] float InitTimmer=5f;
    void Start()
    {
        Invoke(nameof(Init),InitTimmer);
    }

    void Init()
    {
        InitEvent.Raise(this,true);
    }
}
