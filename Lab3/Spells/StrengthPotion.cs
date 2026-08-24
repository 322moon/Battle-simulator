using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.GameBoards;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class StrengthPotion : ISpell
{
    public void Play(GameBoard board)
    {
        board.AddSpell(this);
    }

    public void Apply(Entity target)
    {
        target.ChangeDamage(5);
    }
}