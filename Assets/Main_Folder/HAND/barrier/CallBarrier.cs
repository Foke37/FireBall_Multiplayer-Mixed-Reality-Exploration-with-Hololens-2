using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class CallBarrier : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    
    public AudioSource soundWall;
    public void start()
    {
        soundWall = GetComponent<AudioSource>();
    }
    // public GameObject barrier;

    // void Start() //Create and stick finger
    // {
    //     if (PhotonNetwork.PrefabPool is DefaultPool pool)
    //     {
    //         if (barrier != null) pool.ResourceCache.Add(barrier.name, barrier);
    //     }
    // }
 
    void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.gameObject.layer == 10)
        {   
            soundWall.Play();
            HandTracking Hand;
            Hand = otherCollider.GetComponentInParent<HandTracking>();
            Hand.CreatedBarrier();
            
        //     // Debug.Log("Barrier open");
        //     // CreateBarrier();
        //     if(barrier.name != null)
        //     {
        //         bool isActive = barrier.activeSelf;
        //         barrier.SetActive(!isActive);
        //     }
        }
    }
    // void OnTriggerExit(Collider otherCollider)
    // {    
    //     if(otherCollider.gameObject.layer == 10)
    //     {
              
    //         HandTracking Hand;
    //         Hand = otherCollider.GetComponentInParent<HandTracking>();
    //         Hand.CreatBarrier();
    //     } 
    // } 
    //         // Debug.Log("Barrier close");
    //         // CreateBarrier();
    //         // if(barrier.name != null)
    //         // {
    //         //     bool isActive = barrier.activeSelf;
    //         //     barrier.SetActive(!isActive);
    //         // }
        
    // }
//     private void CreateBarrier()
//     {
//         GameObject BarSheild = PhotonNetwork.Instantiate(barrier.name,gameObject.transform.position,Quaternion.identity);
//     }
}