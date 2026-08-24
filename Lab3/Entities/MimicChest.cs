namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class MimicChest : Entity
{
    public MimicChest() : base(1, 1) { }

    public override void Fight(Entity defender)
    {
        if (defender.HealthPoints > HealthPoints)
        {
            HealthPoints = defender.HealthPoints;
        }

        if (defender.Damage > Damage)
        {
            Damage = defender.Damage;
        }

        base.Fight(defender);
    }
}