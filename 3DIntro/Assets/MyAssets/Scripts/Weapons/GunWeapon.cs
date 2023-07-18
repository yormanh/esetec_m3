using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : BaseWeapon
{
    [SerializeField] GameObject balaPrefab;
    [SerializeField] Transform puntoDisparo;

    [SerializeField] float fuerzaDisparo = 50f;
    [SerializeField] float tiempoSiguenteDisparo = 0.0f;

    public override void Atacar()
    {
        if (Time.time > tiempoSiguenteDisparo && 
            currentMunicion > 0)
        {
            GameObject nuevaBala = Instantiate(balaPrefab, 
                puntoDisparo.position, puntoDisparo.rotation);

            nuevaBala.GetComponent<Rigidbody>().
                AddForce(puntoDisparo.forward * fuerzaDisparo,
                ForceMode.Impulse);

            currentMunicion--;
            tiempoSiguenteDisparo = Time.time + tiempoEntreDisparos;
        }
        {
            Debug.Log(this.name + " No tiene munición");
        }
    }

}
