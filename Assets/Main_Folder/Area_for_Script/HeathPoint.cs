using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HeathPoint : MonoBehaviour
{
    int Heath = 100;
    public AudioSource sound;
    public void start()
    {
        sound = GetComponent<AudioSource>();
    }
    public void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.layer == 11)
        {
            sound.Play();
            playerstats enemyHP;
            enemyHP = otherCollider.GetComponentInParent<playerstats>();
            enemyHP.TakeHP();
        }
    }
}
