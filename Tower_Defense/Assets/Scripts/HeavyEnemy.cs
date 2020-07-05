using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeavyEnemy : Enemy
{

    public override void TakeDamage(float amount)
    {
        if (this.hp - amount > 0f)
            this.hp -= (amount * 1.5f);
        else
            Destroy(gameObject);

        
        Debug.Log(hp + "teszt");
    }
}
