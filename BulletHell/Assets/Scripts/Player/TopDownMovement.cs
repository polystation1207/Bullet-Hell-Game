using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] bool dodgeRoll = true;
    bool isDodging = false;
    [SerializeField] float runSpeed = 5.0f;
    [SerializeField] float dodgeSpeed = 4f;
    [SerializeField] float dodgeDelay = 1f;
    float dodgeTimer = 0;
    float dodgeDelayTimer = 0;
    [SerializeField] float dodgeDuration = 0.5f;

    Vector2 moveInput;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(x, y) * runSpeed * Time.deltaTime * 60;

        Run();
        FlipSprite();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(dodgeRoll == true && dodgeDelayTimer > dodgeDelay)
            {
                isDodging = true;
                //rb.velocity = new Vector2(x, y) * runSpeed * dodgeSpeed;
            }
        }
        if (isDodging)
        { 
            dodgeTimer += Time.deltaTime;
            if(dodgeTimer > dodgeDuration)
            {
                dodgeDelayTimer = 0;
                isDodging = false;
                dodgeTimer = 0;
            }
        }
        else
        {
            dodgeDelayTimer += Time.deltaTime;
        }

    }
    /*void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }*/
    void Run()
    {
        //Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rb.velocity.y);
        //rb.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }
    public bool IsDodging()
    {
        return isDodging;
    }
}
