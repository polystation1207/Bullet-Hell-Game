using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float shootSpeed = 10;
    [SerializeField] float bulletLifetime = 2;
    [SerializeField] float timer = 1;
    [SerializeField] bool mouseShoot = true;
    float x = 2;
    float y = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mouseShoot)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 shootDir = mousePosition - transform.position;
            shootDir.z = 0;
            shootDir.Normalize();
            x = shootDir.x;
            y = shootDir.y;
        }
        float tempX = Input.GetAxisRaw("Horizontal");
        float tempY = Input.GetAxisRaw("Vertical");
        if (tempX != 0 || tempY != 0)
        {
            x = tempX;
            y = tempX;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            // I have pressed the fire button
            timer = 1;
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * shootSpeed;
            Destroy(bullet, bulletLifetime);
        }
    }
}
