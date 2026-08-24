using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.GameBoards;
using Itmo.ObjectOrientedProgramming.Lab3.Helpers;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.GameManagers;

public class GameManager
{
    private readonly CatalogEntity _entityCatalog;
    private readonly SpellsCatalog _spellsCatalog;
    private readonly SpellCastingService _spellCastingService;

    public GameManager()
    {
        _entityCatalog = new CatalogEntity();
        _spellsCatalog = new SpellsCatalog();
        _spellCastingService = new SpellCastingService();
    }

    public GameManagerBuilder CreateBoard()
    {
        return new GameManagerBuilder(_entityCatalog, _spellsCatalog);
    }

    public GameBoard CreatePlayerBoard()
    {
        return new GameBoard();
    }

    public void AddRandomCardToBoard(GameBoard board, bool isPlayer = true)
    {
        if (SimpleRandom.Next(2) == 0)
        {
            AddRandomCreatureToBoard(board, isPlayer);
        }
        else
        {
            AddRandomSpellToBoard(board, isPlayer);
        }
    }

    public void AddRandomCreatureToBoard(GameBoard board, bool isPlayer = true)
    {
        Entity creature = _entityCatalog.GetRandomEntity();
        creature.Play(board);
    }

    public void AddRandomSpellToBoard(GameBoard board, bool isPlayer = true)
    {
        ISpell spell = _spellsCatalog.GetRandomSpell();
        spell.Play(board);
    }

    public bool CastSpell(GameBoard casterBoard, ISpell spell, Entity target, bool isPlayerCaster = true)
    {
        return _spellCastingService.TryCastSpell(casterBoard, spell, target, isPlayerCaster);
    }

    public BattleResults.BattleResult StartBattle(GameBoard playerBoard, GameBoard opponentBoard)
    {
        return playerBoard.ProcessBattle();
    }
}