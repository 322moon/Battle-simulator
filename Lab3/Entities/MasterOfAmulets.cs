using Itmo.ObjectOrientedProgramming.Lab3.Modificators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class MasterOfAmulets : Entity
{
    public MasterOfAmulets() : base(5, 2)
    {
        AddModifier(ModificatorType.Defense);
        AddModifier(ModificatorType.Attack);
    }
}