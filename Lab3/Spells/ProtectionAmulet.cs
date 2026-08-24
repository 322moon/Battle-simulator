using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.GameBoards;
using Itmo.ObjectOrientedProgramming.Lab3.Modificators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class ProtectionAmulet : ISpell
{
    public void Play(GameBoard board)
    {
        board.AddSpell(this);
    }

    public void Apply(Entity target)
    {
        target.AddModifier(ModificatorType.Defense);
    }
}