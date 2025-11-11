using System;

public class Weapon 
{
    private int _damage;
    private int _bullets;
    private int _countOfBullets = 1;

    public Weapon()
    {
        _damage = 5;
        _bullets = 10;
    }

    public void Fire(Player player)
    {
        if (player != null)
        {
            if (_bullets > 0)
            {
                player.TakeDamage(_damage);
                _bullets -= _countOfBullets;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        else
        {
            throw new ArgumentNullException();
        }
    }
}

public class Player 
{
    private int _health;

    public Player()
    {
        _health = 30;
    }

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

public class Bot 
{
    private readonly Weapon _weapon;

    public Bot()
    {
        _weapon = new Weapon();
    }

    public void OnSeePlayer(Player player)
    {
        if (player != null)
        {
            _weapon.Fire(player);
        }
        else
        {
            throw new ArgumentNullException();
        }
    }
}