using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int _damage;
    private int _bullets;

    public void Fire(Player player)
    {
        if (_bullets > 0)
        {
            player.TakeDamage(_damage);
            _bullets -= 1;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}

public class Player : MonoBehaviour
{
    private int _health;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            if (_health > damage)
            {
                _health -= damage;
            }
            else
            {
                _health = 0;
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}

public class Bot : MonoBehaviour
{
    private Weapon _weapon;

    public void OnSeePlayer(Player player)
    {
        _weapon.Fire(player);
    }
}