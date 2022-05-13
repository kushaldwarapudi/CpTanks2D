using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public GameObject Bullet;
    public float speed = 2f;
    
    public Transform ShotPos;
    Rigidbody2D rb;
    Vector2 Direction;
    float  distance;
    public int MaxHealth;
    public int CurrentHealth;
    public int Damage=35;
    public float Firerate = 1f;
    float Firecount = 0f;
    public GameObject Explosion;
    public AudioSource Ead;
    


    // Start is called before the first frame update
    void Start()
    {
       
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        Ead = GetComponent<AudioSource>();
       
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
           
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 Targetpo = player.position;
        Direction = (Vector2)transform.position - Targetpo;
        
        if (distance < 10f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (Firecount <= 0)
            {
                Fire();
                Firecount = 0.5f / Firerate;
                
            }
        }
        else
        {
            
        }

        Lookatplayer();
        
       
        Firecount -= Time.deltaTime;
    }
    public void Lookatplayer()
    {
        this.transform.up = Direction;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            CurrentHealth = CurrentHealth - Damage;
            if (CurrentHealth <= 0)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Ead.Play();
               
                ScoreManager.Kills = ScoreManager.Kills + 1;
            }
        }
        
    }
    
      
    public void Fire()
    {
        Instantiate(Bullet, ShotPos.position, ShotPos.rotation);
    }
    
   
}
