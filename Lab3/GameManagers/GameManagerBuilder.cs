using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.GameBoards;
using Itmo.ObjectOrientedProgramming.Lab3.Helpers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.GameManagers;

public class GameManagerBuilder
{
    private readonly CatalogEntity _entityCatalog;
    private readonly SpellsCatalog _spellsCatalog;

    private GameBoard Board { get; }

    public GameManagerBuilder(CatalogEntity entityCatalog, SpellsCatalog spellsCatalog)
    {
        _entityCatalog = entityCatalog;
        _spellsCatalog = spellsCatalog;
        Board = new GameBoard();
    }

    public GameManagerBuilder AddRandomCard()
    {
        if (SimpleRandom.Next(2) == 0)
        {
            return AddRandomCreature();
        }
        else
        {
            return AddRandomSpell();
        }
    }

    public GameManagerBuilder AddRandomCreature()
    {
        Entity creature = _entityCatalog.GetRandomEntity();
        creature.Play(Board);
        return this;
    }

    public GameManagerBuilder AddRandomSpell()
    {
        ISpell spell = _spellsCatalog.GetRandomSpell();
        spell.Play(Board);
        return this;
    }

    public GameManagerBuilder AddCreature(Entity creature)
    {
        creature.Play(Board);
        return this;
    }

    public GameManagerBuilder AddSpell(ISpell spell)
    {
        spell.Play(Board);
        return this;
    }

    public GameManagerBuilder ForPlayer()
    {
        return this;
    }

    public GameManagerBuilder ForOpponent()
    {
        return this;
    }

    public GameBoard Build()
    {
        return Board;
    }
}