using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public AudioClip fireSound;
    public AudioClip deathSound;

    public float projectileSpeed = 10;
    public float health = 150f;
    public GameObject enemyLaser;
    public float shotsPerSeconds = 0.5f;

    public int scoreValue = 150;

    private ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

	void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(collider);

        Projectile missile = collider.gameObject.GetComponent<Projectile>(); //grabbing the collider of the gameObject whose component i'm getting
        if(missile)
        {
            health -= missile.getDamage();
            missile.Hit();
            if(health <= 0)
            {
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue); 
                Die();
    


            }

        }

    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound,transform.position);
        
    }

    void Update()
    {
        float probability = shotsPerSeconds * Time.deltaTime;
        if(Random.value < probability)
        {
            Shoot();
            AudioSource.PlayClipAtPoint(fireSound, transform.position);

        }
    }

    public void Shoot()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -.5f,0);
        GameObject laser = Instantiate(enemyLaser,startPosition ,Quaternion.identity) as GameObject;
        laser.rigidbody2D.velocity = new Vector2(0, -projectileSpeed * Time.deltaTime);

    }

   
}
