using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Sprite crouchingSprite;
    public Sprite standingSprite;
    public Sprite jumpingSprite;

    public CharacterController2D controller;

    public SpriteRenderer playerSprite;

    public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    private bool isGrounded;

    [SerializeField] private float jumpForce = 8f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;

            if (playerSprite != null && crouchingSprite != null)
            {
                playerSprite.sprite = crouchingSprite;
            }
        }
        else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;

            if (playerSprite != null && standingSprite != null)
            {
                playerSprite.sprite = standingSprite;
            }
        }

	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            if (playerSprite != null && jumpingSprite != null)
            {
                playerSprite.sprite = standingSprite;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

            if (playerSprite != null && jumpingSprite != null)
            {
                playerSprite.sprite = jumpingSprite;
            }
        }
    }
}
