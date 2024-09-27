using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    CharacterMove characterMove;
    Vector3 shootingDirection;
    CharAttack charAttack;

    void Start()
    {
        characterMove = FindObjectOfType<CharacterMove>();
        charAttack = FindObjectOfType<CharAttack>();

        shootingDirection = characterMove.GetShootingDirection();
        float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        gameObject.GetComponent<Rigidbody2D>().velocity = shootingDirection * charAttack.HandleChangeGun().AttackSpeed;

        Destroy(gameObject, 4f);
    }
   
}