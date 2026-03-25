using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPreFab;

    public Transform startPos;

    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            GameObject bullet = Instantiate(bulletPreFab, startPos.position, startPos.rotation);
            Destroy(bullet, 1);
        }
        
    }


}
