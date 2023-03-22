using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && cooldownTimer > attackCooldown && playerMovement.CanAttack())
        {
            Attack();
        }   
        else
        {
            cooldownTimer += Time.deltaTime;
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }
}
