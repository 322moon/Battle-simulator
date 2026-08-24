using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.GameBoards;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class SpellCastingService
{
    public bool TryCastSpell(GameBoard casterBoard, ISpell spell, Entity target, bool isPlayerCaster)
    {
        IReadOnlyList<ISpell> availableSpells = isPlayerCaster ? casterBoard.PlayerSpells : casterBoard.OpponentSpells;

        if (!availableSpells.Contains(spell))
        {
            return false;
        }

        spell.Apply(target);

        if (isPlayerCaster)
        {
            casterBoard.UseSpell(spell, target);
        }
        else
        {
            casterBoard.UseOpponentSpell(spell, target);
        }

        return true;
    }
}