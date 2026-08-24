using Itmo.ObjectOrientedProgramming.Lab3.GameBoards;
using Itmo.ObjectOrientedProgramming.Lab3.ICards;
using Itmo.ObjectOrientedProgramming.Lab3.Modificators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public abstract class Entity : ICard
{
    public int Damage { get; protected set; }

    public int HealthPoints { get; protected set; }

    private readonly List<ModificatorType> _modifiers;

    public IReadOnlyList<ModificatorType> Modifiers => _modifiers;

    protected Entity(int damage, int healthPoints)
    {
        Damage = damage;
        HealthPoints = healthPoints;
        _modifiers = new List<ModificatorType>();
    }

    public virtual void Fight(Entity defender)
    {
        if (Damage > 0)
        {
            defender.TakeDamage(Damage);
            while (Modifiers.Contains(ModificatorType.Attack) && defender.HealthPoints > 0)
            {
                defender.TakeDamage(Damage);
                RemoveModifier(ModificatorType.Attack);
            }
        }
    }

    public void ChangeHealthPoints(int amount)
    {
        if (amount < 0 && HealthPoints <= amount)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), $"{GetType().Name} died.");
        }

        HealthPoints += amount;
    }

    public void ChangeDamage(int amount)
    {
        Damage += amount;
    }

    public virtual void Play(GameBoard board)
    {
        board.AddCreature(this);
    }

    public void AddModifier(ModificatorType modifier)
    {
        _modifiers.Add(modifier);
    }

    public void RemoveModifier(ModificatorType modifier)
    {
        _modifiers.Remove(modifier);
    }

    public void SwapStats()
    {
        (Damage, HealthPoints) = (HealthPoints, Damage);
    }

    protected virtual void TakeDamage(int damage)
    {
        if (Modifiers.Contains(ModificatorType.Defense))
        {
            HealthPoints -= 0;
            RemoveModifier(ModificatorType.Defense);
        }
        else
        {
            HealthPoints -= damage;
        }
    }
}