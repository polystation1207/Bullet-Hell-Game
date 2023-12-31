using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBruteShoot : MonoBehaviour
{
    [SerializeField] float shootDelay = 0.5f;
    [SerializeField] float shootRange = 7f;
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject target;
    [SerializeField] float bulletLifetime = 2;
    float timer = 0;
    [SerializeField] bool predictiveShoot = true;
    [SerializeField] float predictiveLead = 1;
    [SerializeField] AudioClip shellShootSound;
    Animator myAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Destroy(collision.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 playerPosition = target.transform.position;
        Vector3 shootDirection = playerPosition - transform.position;
        if (shootDirection.magnitude < shootRange && timer >= shootDelay)
        {
            if (predictiveShoot)
            {
                Vector3 playerVel = target.GetComponent<Rigidbody2D>().velocity;
                shootDirection += playerVel * predictiveLead;
            }
            timer = 0;
            myAnimator.SetTrigger("isShooting");
            shootDirection.Normalize();
            Camera.main.GetComponent<AudioSource>().PlayOneShot(shellShootSound);
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.transform.up = shootDirection;
            Destroy(bullet, bulletLifetime);
        }
    }
}
