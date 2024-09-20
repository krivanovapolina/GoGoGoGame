using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    CharacterMove CharacterMove;

    [Header("Bullet")]
    [SerializeField] float speedBullet = 7f;

    void Start()
    {
        CharacterMove = FindObjectOfType<CharacterMove>();
        Vector3 shootingDirection = CharacterMove.GetShootingDirection();
        float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        gameObject.GetComponent<Rigidbody2D>().velocity = shootingDirection * speedBullet;
        Destroy(gameObject, 4f);
    }

    
    void Update()
    {
        
    }
}
