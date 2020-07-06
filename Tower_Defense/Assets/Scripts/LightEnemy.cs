using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class LightEnemy : Enemy
{

    
    

    public override void TakeDamage(float amount)
    {

        if (this.hp - amount > 0f)
        {
            this.hp -= (amount * 1.5f);
            healthBar.SetHealth(this.hp);

        }

        else
        PlayerStats.Money += this.worth;
        Debug.Log(PlayerStats.Money += this.worth);
        Destroy(gameObject);

    }

}
