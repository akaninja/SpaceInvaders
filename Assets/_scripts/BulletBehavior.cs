using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    [SerializeField] float bulletSpeed = 7f;
    Rigidbody2D b;
	// Use this for initialization
	void Start () {
        b = GetComponentInChildren<Rigidbody2D>();
        b.velocity = new Vector3(0, bulletSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = new Vector3(transform.position.x, transform.position.y + _bulletSpeed, transform.position.z);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
