using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Holder holder;
    public WeaponScript currentWeapon;
    public List<GameObject> weaponsInventory;

    private void Start()
    {
        if (holder == Holder.enemy)
        {
            StartCoroutine("EnemyAttack");
        }
    }
    private void Update()
    {
        if (holder == Holder.player)
        {
            for (int i = 0; i < weaponsInventory.Count; i++)
            {
                if (Input.GetKeyDown("" + i))
                {
                    SwitchWeapon(i - 1);
                }
            }
            if (Input.GetKey(KeyCode.R) && holder == Holder.player)
            {
                currentWeapon.Attack();
            }
        }
    }

    private void SwitchWeapon(int index)
    {
    }

    private void DropWeapon(int index)
    {

    }

    IEnumerator EnemyAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            currentWeapon.Attack();
        }
    }

    public enum Holder
    {
        player, enemy
    }
}
