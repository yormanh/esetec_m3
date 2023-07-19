using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerMovement : MonoBehaviour
{
    [SerializeField] float velocidad = 10f;
    Transform _player;
    CharacterController _characterController;

    void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //obtenemos la posicion del player
        Vector3 playerPosition = _player.position;
        playerPosition.y = this.transform.position.y;

        //esto mira al player
        this.transform.LookAt(playerPosition);

        //Movimiento, ya tiene colocado el Time.deltaTime
        _characterController.SimpleMove(this.transform.forward * velocidad);
    }
}
