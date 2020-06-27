using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class LightEnemy : Enemy
{

    
    public override void TakeDamage(float amount)
    {
        
        if (this.hp - amount > 0f)
            this.hp -= (amount * 1.5f);
        else
            Destroy(gameObject);

        this.HealthBar.fillAmount = hp / 100f;
        Debug.Log(hp + "++++++++++++++++++++++++++++++++++++++++++++");

    }

}
