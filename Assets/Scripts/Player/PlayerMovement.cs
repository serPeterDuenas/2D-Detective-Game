using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;


    // Movement fields
    private Rigidbody2D rb;
    private float inputHorizontal;
    private float inputVertical;
    private Vector2 moveDirection;
    private bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused == false ^ InteractiveObj.isInDialogue == true)
        {
            // Takes raw input for hori and vert movements, stores into fields;
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");



            // checks to see move direction and whether sprite is already facing in that direction, then flips
            if (inputHorizontal > 0 && facingLeft)
            {
                Flip();
            }
            if (inputHorizontal < 0 && !facingLeft)
            {
                Flip();
            }
        }
        else
        {
            return;
        }
      
    }

    private void StopMovement()
    {
        transform.position = new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z);
        rb.velocity = moveDirection * 0;
    }

    // Movement for the player
    private void FixedUpdate()
    {

        // Checks to see if player is not in dialogue, allows player movement
        if (!InteractiveObj.isInDialogue)
        {
            moveDirection = new Vector2(inputHorizontal, inputVertical);

            rb.velocity = moveDirection.normalized * moveSpeed;
        }
        // If player in dialogue, set velocity to 0
        else
        {
            rb.velocity = moveDirection * 0;
        }
    }


    // Flips the local x scale so the sprite looks in new direction
    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingLeft = !facingLeft;
    }
}
