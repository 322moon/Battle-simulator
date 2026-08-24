using Itmo.ObjectOrientedProgramming.Lab3.Modificators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class ViciousFighter : Entity
{
    public ViciousFighter() : base(1, 6) { }

    protected override void TakeDamage(int damage)
    {
        if (!Modifiers.Contains(ModificatorType.Defense))
        {
            HealthPoints -= damage;
            if (HealthPoints > 0)
            {
                Damage *= 2;
            }
        }

        RemoveModifier(ModificatorType.Defense);
    }
}