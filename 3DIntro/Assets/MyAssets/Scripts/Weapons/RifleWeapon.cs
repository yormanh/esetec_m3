using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este es tan parecido al GunWeapon que lo que hago es heredar del mismo
public class RifleWeapon : GunWeapon
{
    public override void PressTrigger()
    {
        //base.PressTrigger();
        InvokeRepeating("DispararBala", 0, tiempoEntreDisparos);
    }


    public override void ReleaseTrigger()
    {
        //base.ReleaseTrigger();
        CancelInvoke("DispararBala");
    }

    private void OnDisable()
    {
        //Esto cancela todos los invokes que hubieran
        CancelInvoke(); 
    }
}
