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
        if (player == null)
            throw new ArgumentNullException();

        if (_bullets <= 0)
                throw new InvalidOperationException();

        player.TakeDamage(_damage);
        _bullets -= _countOfBullets;
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
        if (damage <= 0)
            throw new ArgumentOutOfRangeException();

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

public class Bot 
{
    private readonly Weapon _weapon;

    public Bot()
    {
        _weapon = new Weapon();
    }

    public void OnSeePlayer(Player player)
    {
        if (player == null)
            throw new ArgumentNullException();

        _weapon.Fire(player);    
    }
}