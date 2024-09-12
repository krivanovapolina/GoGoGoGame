using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    CharacterController controller;
    Vector2 moveDirection;
    float moveX;
    float moveY;
    Animator animator;

    float idleMoveX;
    float idleMoveY;
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
}
