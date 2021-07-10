using UnityEngine;

public class Bear : MonoBehaviour
{
    Animator bearController;
    Rigidbody2D bearRB;
    bool canWalk = false;
    bool walkRight;
    bool isJumping = false;
    public float walkSpeed = 1f;
    public float jumpSpeed = 10f;
    private void Start()
    {
        bearController = GetComponent<Animator>();
        bearRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canWalk && walkRight && !isJumping)
        {
            bearRB.velocity = transform.right * walkSpeed;
        } else if (canWalk && !walkRight && !isJumping)
        {
            bearRB.velocity = -transform.right * walkSpeed;
        }
    }

    public void LeftWalk(bool value)
    {
        bearController.SetBool("walk", value);
        transform.localScale = new Vector2(-1f, transform.localScale.y);
        walkRight = false;
        canWalk = value;
    }

    public void RightWalk(bool value)
    {
        bearController.SetBool("walk", value);
        transform.localScale = new Vector2(1f, transform.localScale.y);
        walkRight = true;
        canWalk = value;
    }

    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            bearController.SetTrigger("jump");
            bearRB.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

}