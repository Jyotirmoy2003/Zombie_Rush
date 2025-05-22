using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SprayScriipt : MonoBehaviour
{
    [SerializeField] float sparyAmount = 1f;
    [SerializeField] float sparyDrainAmount = 0.1f;

    private bool isFire = false;

    void Start()
    {

    }

    void Oestroy()
    {
        SubscribeToInput(false);
    }


    void SubscribeToInput(bool val)
    {
        if (val)
        {
            GameAssets.Instance.gameInput.onFirePress += Fire;
        }
        else
        {
            GameAssets.Instance.gameInput.onFirePress -= Fire;
        }
    }

    void Fire(bool press)
    {
        isFire = press;
    }


    void Update()
    {
        if (isFire && sparyAmount>0)
        {
            sparyAmount -= sparyDrainAmount * Time.deltaTime;
            WeaponUIManager.Instance.SetSprayAmount(sparyAmount);
        }
    }

}
