using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterAnimator : MonoBehaviour
{
    Animator animator;
    CharAttack attack;
    CharacterMove movee;
    float idleMoveX;
    float idleMoveY;

    void Start()
    {
        animator = GetComponent<Animator>();
        attack = GetComponent<CharAttack>();
        movee = GetComponent<CharacterMove>();

    }

    void Update()
    {
        HandleAnimation();
        HandleAttack();

    }

    void Animate(float moveX, float moveY, int layer)
    {
        switch (layer)
        {
            case 0:
                animator.SetLayerWeight(1, 1);
                animator.SetLayerWeight(0, 0);
                break;

            case 1:
                animator.SetLayerWeight(0, 1);
                animator.SetLayerWeight(1, 0);
                break;
        }
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);

    }
    void HandleAnimation()
    {
        if (movee.moveDirection != Vector2.zero)
        {
            Animate(movee.moveX, movee.moveY, 1);
            idleMoveX = movee.moveX;
            idleMoveY = movee.moveY;
        }
        else
        {
            Animate(idleMoveX, idleMoveY, 0);
        }
    }
    void HandleAttack()
    {

        if (Input.GetMouseButtonDown(0) && attack.canShoot && attack.gunType == GunType.Pistol && attack.HandleChangeGun().Ammo > 0)
        {
            animator.SetFloat("ShootX", movee.GetShootingDirection().x);
            animator.SetFloat("ShootY", movee.GetShootingDirection().y);
            animator.SetBool("IsAttack", true);
        }
        else if (Input.GetMouseButtonDown(0) && attack.canShoot && attack.gunType == GunType.Knife)
        {
            animator.SetFloat("ShootX", movee.GetShootingDirection().x);
            animator.SetFloat("ShootY", movee.GetShootingDirection().y);
            animator.SetTrigger("Melee");
            attack.MeleeAttack();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("IsAttack", false);
            attack.canShoot = true;
        }

    }

}
