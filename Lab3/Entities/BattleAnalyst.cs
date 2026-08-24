namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class BattleAnalyst : Entity
{
    public BattleAnalyst() : base(2, 4) { }

    public override void Fight(Entity defender)
    {
        Damage *= 2;
        base.Fight(defender);
    }
}