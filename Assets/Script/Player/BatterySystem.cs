using System.Collections;
using System.Collections.Generic;
using Jy_Mono_Util;
using UnityEngine;
using UnityEngine.UI;

public class BatterySystem : MonoBehaviour
{
    [Header("Reference Battery")]
    [SerializeField]protected Image batterChunk;
    [SerializeField]protected float batterConsumeRate=0.1f;
    [SerializeField]protected float totalBatteryPower=1f;
    [SerializeField] protected GameEvent BatteryConsumedEvent;
    protected bool IsBatteryUsable=true;
    protected NoArgumentFun UpdateDel=new Jy_Utility().NullFun;



    // Update is called once per frame
    void Update()=>UpdateDel();

    protected void UpdateBattery()
    {
        if(totalBatteryPower>0)
        {
            totalBatteryPower-=batterConsumeRate*Time.deltaTime;

        }else if(IsBatteryUsable){
            IsBatteryUsable=false;
            BatteryConsumedEvent.Raise(this,true);
        }
        batterChunk.fillAmount=totalBatteryPower;
    }



    
   
}
