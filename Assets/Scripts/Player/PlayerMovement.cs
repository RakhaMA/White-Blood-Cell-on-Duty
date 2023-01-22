using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isJumping;
    private bool isGrounded;
    private bool isMoving;
    private float? jumpButtonPressedTime;
    private Transform groundChecker;
    private Transform originalParent;
    private float attackTimer;
    private Transform firepoint;
    // private Health health;

    public float lastGroundedTime;
    public float maxJumpForce;
    public float moveSpeed;
    public float jumpButtonGracePeriod;
    public LayerMask groundLayer;
    // public float time;
    public float attackDelay;
    public GameObject rangedAttackProjectile;
    
    private bool isCheatAvailable= true;

    public bool IsMoving { get => isMoving; set => isMoving = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundChecker = transform.Find("GroundChecker");
        originalParent = transform.parent;
        attackTimer = attackDelay;
        firepoint = transform.Find("Firepoint");
        // health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        // time = Time.time;
        if (Physics2D.OverlapCircle(groundChecker.position, 0.2f, groundLayer)) {
            lastGroundedTime = Time.time;
        }

        attackTimer = attackTimer + Time.deltaTime >= attackDelay ? attackTimer = attackDelay : attackTimer += Time.deltaTime;

        if (attackTimer >= attackDelay) {
            if (Input.GetButtonDown("Fire1")) {

                AttackMelee();
            }

            if (Input.GetButtonDown("Fire2")) {
                AttackRanged();
            }

        }

        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput == 0)
        {
            IsMoving = false;
        }
        else
        {
            IsMoving = true;
            if (horizontalInput > 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod) {

            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJumping = false;

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod) {
                // SoundManager.Instance.JumpSFX();
                rb.velocity = new Vector2(rb.velocity.x, maxJumpForce);
                isJumping = true;
                animator.SetBool("isJumping", true);
                jumpButtonPressedTime = null;
                lastGroundedTime = 0;
            }
        }
        else {
            isGrounded = false;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
        }

        if (IsMoving) animator.SetBool("isMoving", true);
        else animator.SetBool("isMoving", false);

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.K) && isCheatAvailable) {
            isCheatAvailable = false;
            KillAllViruses();
        }

    }

    public void SetParent(Transform newParent) {
        transform.parent = newParent;
    }

    public void ResetParent() {
        transform.parent = originalParent;
    }

    private void AttackMelee() {
        attackTimer = 0f;
        animator.SetTrigger("AttackMelee");
    }

    public void KillAllViruses() {
        BasicVirus[] viruses = FindObjectsOfType<BasicVirus>();
        foreach (BasicVirus v in viruses) {
            if (v.TryGetComponent<Health>(out Health health)) {
                if (health.currentHealth > 0) {
                    health.SetHealthToZero();
                }
            }
        }
    }

    private void AttackRanged() {
        attackTimer = 0f;
        animator.SetTrigger("AttackRanged");
        // if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) {
        //     GameObject spawnedProjectile = Instantiate(rangedAttackProjectile, firepoint.position, Quaternion.identity);
        //     spawnedProjectile.GetComponent<Projectile>().SetDirection(new Vector3(transform.localScale.x, 0, 0));
        // } 
    }

    public void SpawnProjectile() {
        GameObject spawnedProjectile = Instantiate(rangedAttackProjectile, firepoint.position, Quaternion.identity);
        spawnedProjectile.GetComponent<Projectile>().SetDirection(new Vector3(transform.localScale.x, 0, 0));
        spawnedProjectile.GetComponent<Projectile>().SetScale(new Vector3(transform.localScale.x, 0, 0));
        spawnedProjectile.GetComponent<Projectile>().SetIgnoredGameobject(gameObject);
    }
}
