using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarScript : MonoBehaviour
{

    public GameObject personaje;

    private float lastAttack;

    void Update()
    {
        Vector3 direction = personaje.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(-4.0f, 4.0f, 1.0f);
        else transform.localScale = new Vector3(4.0f, 4.0f, 1.0f);

        float distance = Mathf.Abs(personaje.transform.position.x - transform.position.x);

        if(distance < 2.0f && Time.time > lastAttack + 1.0f)
        {
            Attack();
            lastAttack = Time.time;
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
    }
}