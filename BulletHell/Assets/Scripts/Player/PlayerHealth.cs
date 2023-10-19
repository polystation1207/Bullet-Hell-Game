using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] TextMeshProUGUI myText;
    int maxHealth = 100;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            myText.text = "Health: " + health;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            myText.text = "Health: " + health;
        }

        if (collision.gameObject.tag == "Health Pack" && health < maxHealth)
        {
            health += 10;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            myText.text = "Health: " + health;
            Destroy(collision.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        myText.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
