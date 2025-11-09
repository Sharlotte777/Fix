using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int _damage;
    private int _bullets;

    public void Fire(Player player)
    {
        if (_bullets > 0)
        {
            player.GetDamage(_damage);
            _bullets -= 1;
        }
    }
}

public class Player : MonoBehaviour
{
    private int _health;

    public void GetDamage(int damage)
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
}

public class Bot : MonoBehaviour
{
    private Weapon _weapon;

    public void OnSeePlayer(Player player)
    {
        _weapon.Fire(player);
    }
}