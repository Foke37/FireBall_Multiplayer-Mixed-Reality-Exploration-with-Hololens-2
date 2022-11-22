// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

using Photon.Pun;
using Photon.Realtime;


public class HandTracking : MonoBehaviourPunCallbacks, IInRoomCallbacks
{

    public GameObject trigle_main;
    public GameObject trigle_minor;
    public GameObject projectile;
  
    public GameObject indexKnuckleObject;

    // public GameObject ringKnuckleObject;
    public GameObject Barrier;
    public GameObject shootingpoint;
    public float projectilespeed = 0;
    public AudioSource soundfire;
    

    MixedRealityPose pose;
    int check = 0;
    
    

    void Start() //Create and stick finger
    {
        soundfire = GetComponent<AudioSource>();
        

        indexKnuckleObject = Instantiate(indexKnuckleObject, this.transform);

        trigle_main = Instantiate(trigle_main, this.transform);
        trigle_minor = Instantiate(trigle_minor, this.transform);
        shootingpoint = Instantiate(shootingpoint, this.transform);

        // Allow prefabs not in a Resources folder
        if (PhotonNetwork.PrefabPool is DefaultPool pool)
        {
            if (projectile != null) pool.ResourceCache.Add(projectile.name, projectile);

            if (Barrier != null) pool.ResourceCache.Add(Barrier.name, Barrier);
        }

        
        
    }

 


    public void ShootFire()
    {
        delectFire();   
        Debug.Log("Pew pew");
        soundfire.Play();
        GameObject fireball = PhotonNetwork.Instantiate(projectile.name,shootingpoint.transform.position,Quaternion.identity);
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.velocity = shootingpoint.transform.forward * projectilespeed;
        Destroy (fireball,3.5f);
    }
    public void CreatedBarrier()
    {   
        // GameObject BR = PhotonNetwork.Instantiate(Barrier.name,indexKnuckleObject.transform.position,Quaternion.identity);
        
        GameObject BR = PhotonNetwork.Instantiate(Barrier.name,indexKnuckleObject.transform.position,indexKnuckleObject.transform.rotation);
        Destroy (BR,5f);
    }
    // public void OpenBarrierGod(GameObject GODBarrier)
    // {
    //     GODBarrier.transform.position = indexKnuckleObject.transform.position;
    //     GODBarrier.transform.position = indexKnuckleObject.transform.rotation;
    // }
    // public void CloseBarrierGod(GameObject GODBarrier)
    // {
    //     GODBarrier.transform.Translate(0,3,0);
    // }



    // public void Makebarrier()
    // {
    //     kcehc = 1;
    // }
    // public void Closebarrier()
    // {
    //     kcehc = 0;
    // }

    public void MakeFire()//it look like works
    {
        check = 1;

    }
    public void delectFire()//it look like works
    {
        check = 0;
        
    }

    void Update()
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        
        indexKnuckleObject.GetComponent<Renderer>().enabled = false;
        trigle_main.GetComponent<Renderer>().enabled = false;
        trigle_minor.GetComponent<Renderer>().enabled = false;
        shootingpoint.GetComponent<Renderer>().enabled = false;
        
       
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleKnuckle, Handedness.Right, out pose))
        {
            indexKnuckleObject.GetComponent<Renderer>().enabled = true;
            indexKnuckleObject.transform.position = pose.Position;     
            indexKnuckleObject.transform.rotation = pose.Rotation;     
        }
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out pose))
        {
            trigle_main.GetComponent<Renderer>().enabled = true;
            trigle_main.transform.position = pose.Position;     
            trigle_main.transform.rotation = pose.Rotation;     
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
        {
            trigle_minor.GetComponent<Renderer>().enabled = true;
            trigle_minor.transform.position = pose.Position;
            trigle_minor.transform.rotation = pose.Rotation;     
        }

        if (check == 1)
        {
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
            {
                // Debug.Log("Fire on!");
                shootingpoint.GetComponent<Renderer>().enabled = true;
                shootingpoint.transform.position = pose.Position;
                shootingpoint.transform.rotation = pose.Rotation;
            }
        }
        if (check == 0)
        {
            if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
            {
                // Debug.Log("Fire off!");
                // Destroy(shootingpoint,0.01f);
                shootingpoint.GetComponent<Renderer>().enabled = false;
            }
        }

        
        if(Input.GetKeyDown(KeyCode.V))
        {
            CreatedBarrier();
        }


        
//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//KUY
        // if (kcehc == 1)
        // {
            
        //     if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingKnuckle, Handedness.Right, out pose))
        //     {
        //         // Debug.Log("Fire on!");
        //         ringKnuckleObject.GetComponent<Renderer>().enabled = true;
        //         ringKnuckleObject.transform.position = pose.Position;
        //         ringKnuckleObject.transform.rotation = pose.Rotation;
        //     }
        // }
          
        // if (kcehc == 0)
        // {
        //     if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingKnuckle, Handedness.Right, out pose))
        //     {
        //         // Debug.Log("Fire on!");
        //         ringKnuckleObject.GetComponent<Renderer>().enabled = false;
        //     }
        // }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //shoot middle, onoff index thumb
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // indexKnuckleObject.GetComponent<Renderer>().enabled = false;
        // trigle_main.GetComponent<Renderer>().enabled = false;
        // trigle_minor.GetComponent<Renderer>().enabled = false;
        // shootingpoint.GetComponent<Renderer>().enabled = false;
        // // shootingpoint.GetComponent<Renderer>().enabled = false;
        // // ringObject.GetComponent<Renderer>().enabled = false;
        // // pinkyObject.GetComponent<Renderer>().enabled = false;

        // if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexKnuckle, Handedness.Right, out pose))
        // {
        //     indexKnuckleObject.GetComponent<Renderer>().enabled = true;
        //     indexKnuckleObject.transform.position = pose.Position;     
        //     indexKnuckleObject.transform.rotation = pose.Rotation;     
        // }
        // if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
        // {
        //     trigle_main.GetComponent<Renderer>().enabled = true;
        //     trigle_main.transform.position = pose.Position;     
        //     trigle_main.transform.rotation = pose.Rotation;     
        // }

        // if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        // {
        //     trigle_minor.GetComponent<Renderer>().enabled = true;
        //     trigle_minor.transform.position = pose.Position;
        //     trigle_minor.transform.rotation = pose.Rotation;     
        // }

        // if (check == 1)
        // {
        //     if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out pose))
        //     {
        //         // Debug.Log("Fire on!");
        //         shootingpoint.GetComponent<Renderer>().enabled = true;
        //         shootingpoint.transform.position = pose.Position;
        //         shootingpoint.transform.rotation = pose.Rotation;
        //     }
        // }
        // if (check == 0)
        // {
        //     if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out pose))
        //     {
        //         // Debug.Log("Fire off!");
        //         // Destroy(shootingpoint,0.01f);
        //         shootingpoint.GetComponent<Renderer>().enabled = false;
        //     }
        // }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}



