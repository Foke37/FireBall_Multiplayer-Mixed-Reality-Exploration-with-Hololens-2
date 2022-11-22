using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CallFire : MonoBehaviour
{
    int Create = 0;
    
    void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.gameObject.layer == 9)
        {
            Debug.Log("Call me on Fire!");
            HandTracking Fireball;
            Fireball = otherCollider.GetComponentInParent<HandTracking>();
            Fireball.MakeFire();
            Create = 1;

        }
    }
    void OnTriggerExit(Collider otherCollider)
    {
        if(otherCollider.gameObject.layer == 9)
        {
            if(Create == 1)
            {
                HandTracking Fireball;
                Fireball = otherCollider.GetComponentInParent<HandTracking>();
                Fireball.ShootFire();
                Create = 0;
            }
        }
    }


}
