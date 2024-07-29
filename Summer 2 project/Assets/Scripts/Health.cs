using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
     #region Variables
     public int maxHealth;
     public int currentHealth;
     #endregion

    // Start is called before the first frame update
    public void ChangeHealth(int damage)
    {
        currentHealth = currentHealth + damage;
        Debug.Log($"{gameObject.name} took {damage} damage!");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
   private void Die()
    {
        switch (gameObject.tag)
        {
             case("Enemy"):
             Debug.Log("Enemy has died");
             Destroy(gameObject);
              break;

        }
    }
}
