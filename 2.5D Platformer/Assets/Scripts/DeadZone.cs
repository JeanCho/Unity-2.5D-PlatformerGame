using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{

    [SerializeField]
    private GameObject _respawnPosition;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.LoseLife();

            }
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;

                other.transform.position = _respawnPosition.transform.position;
                cc.enabled = true;

            }
        }
    }
}
