//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CharacterMove : MonoBehaviour
//{
//    [Header("Movement Settings")]
//    [SerializeField]  float moveSpeed = 5f;

//    [Header("References")]
//    [SerializeField]  GameObject bulletPref;

//     CharacterController controller;
//     Animator animator;

//     Vector2 moveDirection;
//     Vector3 mouseDirection;

//     float idleMoveX;
//     float idleMoveY;
//     float moveX;
//     float moveY;

//     bool canShoot = true;
//     GunType gunType = GunType.Pistol;

//    [Header("Melee Attack")]
//    [SerializeField] Transform meleeAttackPoint;
//    [SerializeField] float meleeAttackRange = 1f;



//    void Start()
//    {
//        controller = GetComponent<CharacterController>();
//        animator = GetComponent<Animator>();
//    }

//    void Update()
//    {
//        HandleMovementInput();
//        HandleAnimation();
//        HandleChangeGun();
//        HandleAttack();



//    }

//     void FixedUpdate()
//    {

//        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
//    }

//     void Animate(float moveX, float moveY, int layer)
//    {
//        switch (layer)
//        {
//            case 0: 
//                animator.SetLayerWeight(2, 1);
//                animator.SetLayerWeight(1, 0);
//            break;

//            case 1:
//                animator.SetLayerWeight(1, 1);
//                animator.SetLayerWeight(2, 0);
//                break;
//        }
//        animator.SetFloat("MoveX", moveX);
//        animator.SetFloat("MoveY", moveY);

//    }


//    Vector3 GetShootingDirection()
//    { 
//        mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        mouseDirection.z = 0f;
//        return (mouseDirection - transform.position).normalized;

//    }
//    void HandleMovementInput()
//    {
//        moveX = Input.GetAxisRaw("Horizontal");
//        moveY = Input.GetAxisRaw("Vertical");
//        moveDirection = new Vector2(moveX, moveY).normalized;
//    }
//    void HandleAnimation()
//    {
//        if (moveDirection != Vector2.zero)
//        {
//            Animate(moveX, moveY, 1);
//            idleMoveX = moveX;
//            idleMoveY = moveY;
//        }
//        else
//        {
//            Animate(idleMoveX, idleMoveY, 0);
//        }
//    }

//    public void Bullet()
//    {
//        if (canShoot)
//        {
//            Vector3 shootingDirection = GetShootingDirection();
//            float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;

//            GameObject bulletInstance = Instantiate(bulletPref, transform.position + shootingDirection, Quaternion.Euler(new Vector3(0, 0, angle)));

//            bulletInstance.GetComponent<Rigidbody2D>().velocity = shootingDirection * 5f;

//            Destroy(bulletInstance, 4f);
//            canShoot = false;
//        }
//    }


//    void HandleAttack() {

//        if (Input.GetMouseButtonDown(0) && canShoot && gunType==GunType.Pistol)
//        {
//            animator.SetFloat("ShootX", GetShootingDirection().x);
//            animator.SetFloat("ShootY", GetShootingDirection().y);
//            animator.SetBool("IsAttack", true);
//        }
//        else if(Input.GetMouseButtonDown(0) && canShoot && gunType == GunType.Knife)
//        {
//            animator.SetFloat("ShootX", GetShootingDirection().x);
//            animator.SetFloat("ShootY", GetShootingDirection().y);
//            MeleeAttack();
//        }
//        else if (Input.GetMouseButtonUp(0))
//        {
//            animator.SetBool("IsAttack", false);

//            canShoot = true;
//        }



//    }


//    void HandleChangeGun()
//    {
//        if (Input.GetKeyDown(KeyCode.Alpha1))
//            gunType = GunType.Pistol;

//        else if (Input.GetKeyDown(KeyCode.Alpha2))
//        {
//            gunType = GunType.Knife;

//        }
//        Debug.Log(gunType);

//    }

//    void MeleeAttack()
//    {
//        animator.SetTrigger("Melee");
//        Collider2D enemy = Physics2D.OverlapCircle(meleeAttackPoint.position, meleeAttackRange);

//        if (enemy != null)
//            Debug.Log(enemy.name);
//        else
//            Debug.Log("YA UDARIL");

//    }

//    private void OnDrawGizmosSelected()
//    {
//        Gizmos.DrawSphere(meleeAttackPoint.position, meleeAttackRange);
//    }

//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;

    CharacterController controller;

    public Vector2 moveDirection { get; set; }
    public Vector3 mouseDirection;

    public float moveX { get; set; }
    public float moveY { get; set; }

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovementInput();
        

    }

    void FixedUpdate()
    {

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public Vector3 GetShootingDirection()
    {
        mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection.z = 0f;
        return (mouseDirection - transform.position).normalized;

    }
    void HandleMovementInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

}