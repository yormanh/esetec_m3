using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : BaseWeapon
{
    [Header("Settings")]
    [SerializeField] GameObject balaPrefab;
    [SerializeField] Transform puntoDisparo;

    [SerializeField] float fuerzaDisparo = 50f;
    [SerializeField] float tiempoSiguenteDisparo = 0.0f;

    [Header("Sonidos")]
    [SerializeField] AudioClip disparoAudio;
    [SerializeField] AudioClip sinMunicionAudio;


    public override void Atacar()
    {
        if (Time.time > tiempoSiguenteDisparo && 
            currentMunicion > 0)
        {
            AudioSource.PlayClipAtPoint(disparoAudio,
                this.transform.position);

            GameObject nuevaBala = Instantiate(balaPrefab, 
                puntoDisparo.position, puntoDisparo.rotation);

            nuevaBala.GetComponent<Rigidbody>().
                AddForce(puntoDisparo.forward * fuerzaDisparo,
                ForceMode.Impulse);

            currentMunicion--;
            tiempoSiguenteDisparo = Time.time + tiempoEntreDisparos;
        }
        else if (currentMunicion <= 0) {
            Debug.Log(this.name + " No tiene munición");
            AudioSource.PlayClipAtPoint(sinMunicionAudio,
                this.transform.position);
        }
    }

}
