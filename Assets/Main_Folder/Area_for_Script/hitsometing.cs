using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class hitsometing : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    int Damage = 20;
    // Start is called before the first frame update
    public GameObject ExplosionVFX;
    private void Start()
    {
        // Allow prefabs not in a Resources folder
        if (PhotonNetwork.PrefabPool is DefaultPool pool)
        {
            if (ExplosionVFX != null) pool.ResourceCache.Add(ExplosionVFX.name, ExplosionVFX);
        }
        
    }
    public void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.layer == 11)
        {
            playerstats enemyStats;
            enemyStats = otherCollider.GetComponentInParent<playerstats>();
            enemyStats.TakeDamage(Damage);
            // Destroy(gameObject);

            if(GetComponent<PhotonView>().IsMine == true)
		    {
			    PhotonNetwork.Destroy (gameObject);
		    }


            CreateExplosion();

                // if(GetComponent<PhotonView>().IsMine == true)
		        // {
			    //     PhotonNetwork.Destroy (cloneA);
		        // }


        }
        if (otherCollider.gameObject.layer == 8)
        {
            // Destroy(gameObject);
            if(GetComponent<PhotonView>().IsMine == true)
		    {
			    PhotonNetwork.Destroy (gameObject);
		    }
            CreateExplosion();
            // if(GetComponent<PhotonView>().IsMine == true)
		    // {
			//         PhotonNetwork.Destroy (cloneA);
		    //     }
        }
        else
        {
            // Destroy (gameObject,3.5f);
            CreateExplosion();
                // if(GetComponent<PhotonView>().IsMine == true)
		        // {
			    //     PhotonNetwork.Destroy (cloneA);
		        // }

        }
       

    }
    public void CreateExplosion()
    {
        GameObject cloneA  = PhotonNetwork.Instantiate(ExplosionVFX.name,gameObject.transform.position,gameObject.transform.rotation);
        Destroy(cloneA,1.5f);
    }
}
