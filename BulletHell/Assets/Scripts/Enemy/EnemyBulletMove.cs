using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    Rigidbody2D myRB;
    [SerializeField] float bulletSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = transform.up * bulletSpeed;
    }
}
