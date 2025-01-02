using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Config")]
    [SerializeField] private float speed;
    [Header("Dash")]
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashTime= 0.3f;
    [SerializeField] private float transparency= 0.3f;
    private Animator animator;
    public Joystick joystick; 
    public Vector2 MoveDirection => moveDirection;
    private SpriteRenderer spriteRenderer;
    private PlayerActions actions;
    private Rigidbody2D rb2D;
    Vector3 joystickDirection;
    public Vector2 moveDirection;
    private float currentSpeed;
    private bool usingDash;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        actions = new PlayerActions();
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        currentSpeed = speed;
        actions.Movement.Dash.performed += context => Dash();
    }
    private void Dash()
    {
        if(usingDash)
        {
            return;
        } 
        animator.SetBool("IsDashing", true);
        if (moveDirection.magnitude < 0.1f)
        {

            
            moveDirection = transform.right; 
        }

        usingDash = true;
        StartCoroutine(IEDash());
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private IEnumerator IEDash()
    {
        currentSpeed = dashSpeed;
        ModifySpriteRenderer(transparency);
        yield return new WaitForSeconds(dashTime);
        currentSpeed = speed;
        ModifySpriteRenderer(1f);//no transparicy
        usingDash = false;
        animator.SetBool("IsDashing", false);
    }
    
    private void MovePlayer()
    {
        rb2D.MovePosition(rb2D.position+moveDirection*(currentSpeed*Time.fixedDeltaTime));
    }
    private void ModifySpriteRenderer(float alpha)
    {
        Color color = spriteRenderer.color;
        color = new Color(color.r,color.g,color.b,alpha);
        spriteRenderer.color = color;
    }
    // Update is called once per frame
    void Update()
    {
        joystickDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0f);
        CaptureInput();
        RotatePlayer();
        if (moveDirection.magnitude > 0.1f)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void CaptureInput()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (joystickDirection != Vector3.zero)
        moveDirection = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
    }
    private void OnEnable()
    {
        actions.Enable();
    }
    private void OnDisable()
    {
        actions.Disable();
    }
    private void RotatePlayer()
    {
        if(moveDirection.x>=0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(moveDirection.x<0f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
