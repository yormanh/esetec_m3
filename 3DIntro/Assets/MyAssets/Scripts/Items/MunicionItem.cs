using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunicionItem : MonoBehaviour
{
    [SerializeField] AudioClip recogerAudio;
    [SerializeField] int numeroBalas = 1;
    [SerializeField] string _name;

    private void OnTriggerEnter(Collider other)
    {
        BaseWeapon baseWeapon = null;
        switch (_name.ToLower())
        {
            case "gun":
                baseWeapon = other.GetComponentInChildren<GunWeapon>
                    (includeInactive: true);
                break;

            case "rifle":
                baseWeapon = other.GetComponentInChildren<RifleWeapon>
                    (includeInactive: true);
                break;
        }

        baseWeapon.AddCurrentMunicionInventario(numeroBalas);
        baseWeapon.SetHasWeapon(true);

        AudioSource.PlayClipAtPoint(recogerAudio,
            this.transform.position);
        Destroy(this.gameObject);

    }

}
