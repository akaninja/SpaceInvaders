using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    [SerializeField] GameObject EnemyBullet;
    [SerializeField] float offset = 0.5f;
    [SerializeField] Rigidbody2D e;
    public bool mayShoot = false;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (mayShoot)
        {
            Shoot();
        }
	}

    void Shoot()
    {
        GameObject enemyLaser = Instantiate(EnemyBullet, new Vector3 (transform.position.x, transform.position.y + offset), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
