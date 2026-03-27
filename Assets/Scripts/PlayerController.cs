using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float immuneTime = 3f;

    public float JumpForce;

    private bool isGrounded = false;
    private bool isAlreadyJump = false;
    private CapsuleCollider2D hitbox;
    private Rigidbody2D rigid;
    [HideInInspector]
    public Animator animator;
    private SpriteRenderer sprite;


    void Awake()
    {
        hitbox = GetComponent<CapsuleCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }

        PlayerInput();
        Invisible();
        TimeHandler();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.contacts[0].normal.y > 0.7f)
        {
            isAlreadyJump = false;
            isGrounded = true;
            animator.SetBool("isGrounded", isGrounded);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isGrounded", isGrounded);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            if (GameManager.Instance.isGameOver) return;

            TakeDamage(50);
            rigid.linearVelocity = Vector3.zero;
            isAlreadyJump = false;

            if (GameManager.Instance.Energy > 0)
            {
                transform.position = new Vector3(-7, 1, 0);
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(10);
        }
    }


    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isAlreadyJump)
        {
            if (!isGrounded) { isAlreadyJump = true; animator.SetTrigger("DoubleJump"); }

            rigid.linearVelocity = Vector2.zero;
            rigid.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded)
        {
            hitbox.size = new Vector2(hitbox.size.x, 0.7f);
            hitbox.offset = new Vector2(0, -0.4f);
            animator.SetBool("isSlide", true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            hitbox.size = new Vector2(hitbox.size.x, 1.5f);
            hitbox.offset = Vector2.zero;
            animator.SetBool("isSlide", false);
        }
    }

    void Invisible()
    {
        if (GameManager.Instance.Energy <= 0)
        {
            SetColor(1);
            return;
        }

        if (immuneTime < 0)
        {
            SetColor(1);
            return;
        }

        float alpha = Mathf.Cos(immuneTime * 10f) * 0.5f + 0.5f;
        SetColor(alpha);
    }

    void SetColor(float alpha)
    {
        Color color = sprite.color;
        color.a = alpha;
        sprite.color = color;
    }

    void TimeHandler()
    {
        immuneTime -= Time.deltaTime;

    }
    void TakeDamage(int damage)
    {
        if (immuneTime > 0) return;

        GameManager.Instance.Energy -= damage;
        immuneTime = 3f;
    }
}
