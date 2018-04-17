using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
  
    [SerializeField] Rigidbody2D _r;
    [SerializeField] float speed = 15f;
    bool movingRight = false;
    bool movingLeft = false;
    [SerializeField] GameObject _bulletPrefab;
    float offset = 0.5f;
    Collider col;
    Vector3 size;
    float max_x;
    float min_x;
    float padding = 1f;


	// Use this for initialization
	void Start () {
        float distanceFromCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceFromCamera));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceFromCamera));
        max_x = rightMost.x - padding;
        min_x = leftMost.x + padding;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movingLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movingRight = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            movingLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            movingRight = false;
        }

        if(movingLeft == true)
        {
            MoveLeft();
        }
        if(movingRight == true)
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        float newX = Mathf.Clamp(transform.position.x, min_x, max_x);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

    }

    void MoveLeft()
    {
        //_r.transform.position = new Vector3(transform.position.x - _speed, transform.position.y, transform.position.z);
        _r.transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void MoveRight()
    {
        //_r.transform.position = new Vector3(transform.position.x + _speed, transform.position.y, transform.position.z);
        _r.transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void Shoot()
    {
        GameObject.Instantiate(_bulletPrefab, new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
