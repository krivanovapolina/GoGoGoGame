using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    CharacterController controller;
    Vector2 moveDirection;
    Vector3 mouseDirection;
    float moveX;
    float moveY;
    Animator animator;
    private float speedBullet = 5f;
    private float lastAttack = -999f;
    private float cooldown = 8f;

    float idleMoveX;
    float idleMoveY;

    public GameObject bulletPref;
    //public GameObject shootPoint;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2 (moveX, moveY).normalized;
        if(moveX !=0 || moveY != 0)
        {
            Animate(moveX, moveY, 1);
            idleMoveX = moveX;
            idleMoveY = moveY;
        }
        else
        {
            Animate(idleMoveX, idleMoveY, 0);
        }
        if (Input.GetMouseButtonDown(0))
            Attack();
        else
            animator.SetBool("IsAttack", false);
    }

    private void FixedUpdate()
    {
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void Animate(float moveX, float moveY, int layer)
    {
        switch (layer)
        {
            case 0: 
                animator.SetLayerWeight(0, 1);
                animator.SetLayerWeight(1, 0);
            break;

            case 1:
                animator.SetLayerWeight(1, 1);
                animator.SetLayerWeight(0, 0);
                break;
        }
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);
    }

    private void Attack()
    {
        if (Time.time > lastAttack + cooldown)
        {
            animator.SetBool("IsAttack", true);
            animator.SetFloat("MoveX", idleMoveX);
            animator.SetFloat("MoveX", idleMoveY);

            mouseDirection = Input.mousePosition;
            Debug.Log(mouseDirection);
            mouseDirection.z = 0f;
            mouseDirection = Camera.main.ScreenToWorldPoint(mouseDirection);
            Debug.Log(mouseDirection);
            mouseDirection = mouseDirection - transform.position;

            GameObject bulletInstance = Instantiate(bulletPref, transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().velocity = mouseDirection * speedBullet;

            Destroy(bulletInstance, 4);
            lastAttack = Time.time;
        }
    }
}
