using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerstats : MonoBehaviour
{
    // Start is called before the first frame update
    int MaxHealth;
    int currentHealth;
    public int score;
    public TextMeshPro scoreUI;
    public AudioSource soundHit;
    // public GameObject healthbar;

    void Start()
    {
        MaxHealth = 100;
        currentHealth = MaxHealth;
        soundHit = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = score.ToString();
        
        if(Input.GetKeyDown(KeyCode.B))
        {   
            soundHit.Play();
            currentHealth = currentHealth - 20;
            score = currentHealth;
            Debug.Log("Current Health = " + currentHealth);
        }
        if(currentHealth <= 0)
        {
            // healthbar.value = currentHealth;
            
            scoreUI.text = "YOU WIN!";
            Debug.Log("You win");
            // Destroy(gameObject,0.5f);
        }
        // // healthbar.value = currentHealth;
    }
    public void TakeDamage(int DamageDealt)
    {
        soundHit.Play();
        currentHealth = currentHealth - DamageDealt;
        score = currentHealth;
        // healthbar.value = currentHealth;
    }

    public void TakeHP()
    {
        
        currentHealth = 100;
        score = 100;
    }
}
