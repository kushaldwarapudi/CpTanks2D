using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Text Health;
    public int Maxhealth;
    public int currenthealth;
    public int Damage=20;
    public float Speed;
    public float Rotspeed;
    public Rigidbody2D rb;
    public GameObject Bullet;
    public Transform FirePos;
    public GameObject Explosion;
    public bool IsGameOver;
    public GameObject GameOver;
    
    
   
    public bool mvfwd;
    
    public bool Rtleft;
    public bool Rtrght;
    public bool Fire;
    public bool mvbck;
    
    public bool sht;
    public bool stpsht;
    public float Firerate = 1f;
    float Firecount = 0f;
    public AudioSource ad;


    // Start is called before the first frame update
    void Start()
    {
        Health.text = Maxhealth.ToString();
        Maxhealth = 100; 
        currenthealth = Maxhealth;
        rb = GetComponent<Rigidbody2D>();
        ad = GetComponent<AudioSource>();
        IsGameOver = false;
        GameOver.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Fire)
        {
            if (Firecount <= 0)
            {
                Shoot();
                Firecount = 0.5f / Firerate;

            }
        }
        if (mvfwd)
        {
            transform.Translate(new Vector2(0, -1f * Speed * Time.deltaTime));
        }
        if (mvbck)
        {
            transform.Translate(new Vector2(0, 1f * Speed * Time.deltaTime));
        }
        if (Rtrght)
        {
            transform.Rotate(new Vector3(0, 0, -10f * Rotspeed * Time.deltaTime));
        }
        if (Rtleft)
        {
            transform.Rotate(new Vector3(0, 0, 10f * Rotspeed * Time.deltaTime));
        }

        if (currenthealth <= 0)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            ad.enabled = true;
            ad.Play();
            Destroy(gameObject);
            IsGameOver = true;
            GameOver.SetActive(true);
            
            
           
        }
        Health.text = currenthealth.ToString();
    }
    
    public void forward()
    {
        mvfwd = true;
    }
    public void backward()
    {
        mvbck = true;
    }
    public void left()
    {
        Rtleft = true;
    }
    public void right()
    {
        Rtrght = true;
    }
    public void rlforward()
    {
        mvfwd = false;
    }
    public void rlbackward()
    {
        mvbck = false;
    }
    public void rlrght()
    {
        Rtrght = false;
    }
    public void rllft()
    {
        Rtleft = false;
    }
    public void Shoot()
    {
        Fire = true;
        Instantiate(Bullet, FirePos.position, FirePos.rotation);
       

    }
    public void stopshoot()
    {
        Fire = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            currenthealth -= Damage;
        }
    }
    
   
}
