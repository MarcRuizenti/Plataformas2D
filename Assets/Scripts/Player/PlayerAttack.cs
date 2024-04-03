using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool _inputAttack;
    public bool canAttack;

    private void Start()
    {
        canAttack = true;
    }
    void Update()
    {
        _inputAttack = Input.GetButtonDown("Fire1");
        if (_inputAttack && canAttack)
        {
            StartCoroutine(AttackDuration(gameObject.transform.GetChild(2).gameObject));
            canAttack = false;
        }
    }

    private IEnumerator AttackDuration(GameObject _sword)
    {
        _sword.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        _sword.SetActive(false);
        canAttack = true;
    }
}
