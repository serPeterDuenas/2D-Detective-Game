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
        // if there is no dialogue playing, then get input
        if (!DialogueManager.instance.dialogueIsPlaying)
        {
            inputHorizontal = Input.GetAxisRaw("Horizontal");
            inputVertical = Input.GetAxisRaw("Vertical");

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
            return;
    }

 

    // Movement for the player
    private void FixedUpdate()
    {
        moveDirection = new Vector2(inputHorizontal, inputVertical);
        rb.velocity = moveDirection.normalized * moveSpeed;



        // stops player from moving if in dialogue
        if(DialogueManager.instance.dialogueIsPlaying)
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
