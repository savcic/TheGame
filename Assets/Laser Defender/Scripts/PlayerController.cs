using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AudioClip fireSound;
 
    public float health = 200f;

    public float speed = 15f;
    public float padding = 1;

    public GameObject laser;
    public GameObject enemyLaser;

    public float projectileSpeed = 10 ;
    public float projectileRepeatRate = 0.2f;

    private AudioSource playerAudioSource;


    private float xMin, xMax;

    // Use this for initialization

    void Start()
    {

        

        Camera camera = Camera.main; 
        float distance = transform.position.z - camera.transform.position.z;

        xMin = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding; //relative position of the point on the viewport (0,0 bottom-left corner, top-right corner 1,1)
        Debug.Log(xMin);
        xMax = camera.ViewportToWorldPoint(new Vector3(1,1,distance)).x - padding;
        // luam camera noastra principala  
        // si aplicam functia ViewPortToWorldPoint asupra ei pt ca ea are viewport coordinates ca sa o transformam in world point coordinate
        // daca ma uit la lume cum ar fi din punct d vedere de viewport adica sa inceapa d la 0,0 .<- la 1,1 ->*  
        // si eu iti precizez care parte anume din ecran cand ma uit la lume ca si cum ar fi de viewport
        // dar precizez ca pe axa, x-ul camerei ar fi ce ma intereseaza



        Debug.Log(xMax);
    }



    void Shoot()
    {
        GameObject beam = Instantiate(laser, transform.position ,Quaternion.identity) as GameObject;
        beam.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        beam.rigidbody2D.velocity = new Vector3(0,projectileSpeed,0);
        AudioSource.PlayClipAtPoint(fireSound,transform.position);
    }

    void playerControl()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x -speed * Time.deltaTime ,xMin,xMax),transform.position.y,transform.position.z); //while a is pressed gameobject's transform.position = a new vector with speed (x) + it's own position
        } 
        else {
            if(Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x + speed * Time.deltaTime,xMin,xMax),transform.position.y,transform.position.z);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Shoot", 0.0001f, projectileRepeatRate);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Shoot");
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile enemyMissile = collider.gameObject.GetComponent<Projectile>(); //grabbing the collider of the gameObject whose component i'm getting
        if(enemyMissile)
        {
            health -= enemyMissile.getDamage();
            enemyMissile.Hit();
            if(health <= 0)
            {
                Die();
            }
            
        }
        
    }

    void what()
    {

    }

    void Die()
    {
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("Win Screen");
        Destroy(gameObject);
    }
        

}

