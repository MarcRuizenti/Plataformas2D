using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool _inputAttack;
    public bool canAttack;
    private Animator animator;
    private PlayerMovement playerMovement;
    private void Start()
    {
        canAttack = true;
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        _inputAttack = Input.GetButtonDown("Fire1");
        if (_inputAttack && canAttack && playerMovement.Gronded)
        {
            canAttack = false;
            animator.SetTrigger("Attack");
            playerMovement.enabled = false;
        }
    }
    public void ActiveAttack() 
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void DesactiveAttack()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        canAttack = true;
        playerMovement.enabled = true;
    }

}
