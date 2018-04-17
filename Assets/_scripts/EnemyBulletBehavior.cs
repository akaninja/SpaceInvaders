using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour {
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] Rigidbody2D p;
    Rigidbody2D enemyB;



	void Start () {
        enemyB = GetComponentInChildren<Rigidbody2D>();
        enemyB.velocity = new Vector3(0, -bulletSpeed, 0);
	}
	

	void Update () {
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
