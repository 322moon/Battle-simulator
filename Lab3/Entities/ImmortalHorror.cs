using Itmo.ObjectOrientedProgramming.Lab3.Modificators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class ImmortalHorror : Entity
{
    private bool _hasReborn;

    public ImmortalHorror() : base(4, 4)
    {
        _hasReborn = false;
    }

    protected override void TakeDamage(int damage)
    {
        if (Modifiers.Contains(ModificatorType.Defense))
        {
            HealthPoints -= 0;
            RemoveModifier(ModificatorType.Defense);
        }
        else
        {
            if (HealthPoints <= damage && !_hasReborn)
            {
                HealthPoints = 1;
                _hasReborn = true;
            }
            else
            {
                HealthPoints -= damage;
            }
        }
    }
}