namespace TheShacklingOfSimon;

public interface IDamageable : IEntity
{
    float Health { get; }
    float MaxHealth { get; }

    void TakeDamage(float amt);
    void Heal(float amt);
    void Die();
}