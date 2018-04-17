using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] GameObject enemyPrefab;
    public float width = 11f;
    public float height = 7f;
    private bool movingLeft = false;
    private bool movingRight = true;
    public float enemySpeed = 1f;
    float max_x;
    float min_x;
    float padding = 0.01f;

	void Start () {
        float distanceFromCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceFromCamera));
        Vector3 rightLimit = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceFromCamera));
        max_x = rightLimit.x - padding;
        min_x = leftLimit.x + padding;

        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (movingRight)
        {
            MoveRight();
        }
        if (movingLeft)
        {
            MoveLeft();
        }
        if (movingRight && transform.position.x + width/2 > max_x - padding)
        {
            movingLeft = true;
            movingRight = false;
            MoveDown();
        }
        if(movingLeft == true && transform.position.x - width / 2 < min_x + padding)
        {
            movingRight = true;
            movingLeft = false;
            MoveDown();
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    void MoveRight()
    {
        transform.position += Vector3.right * enemySpeed * Time.deltaTime;
    }

    void MoveLeft()
    {
        transform.position += Vector3.left * enemySpeed * Time.deltaTime;
    }

    void MoveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f);
    }
}
