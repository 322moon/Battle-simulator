using Itmo.ObjectOrientedProgramming.Lab3.BattleResults;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.GameBoards;

public class GameBoard
{
    private readonly List<Entity> _playerCreatures = new List<Entity>();
    private readonly List<ISpell> _playerSpells = new List<ISpell>();
    private readonly List<Entity> _opponentCreatures = new List<Entity>();
    private readonly List<ISpell> _opponentSpells = new List<ISpell>();

    public IReadOnlyList<Entity> PlayerCreatures => _playerCreatures;

    public IReadOnlyList<ISpell> PlayerSpells => _playerSpells;

    public IReadOnlyList<Entity> OpponentCreatures => _opponentCreatures;

    public IReadOnlyList<ISpell> OpponentSpells => _opponentSpells;

    public void AddCreature(Entity creature)
    {
        if (_playerCreatures.Count + _playerSpells.Count >= 7)
        {
            throw new InvalidOperationException("Cannot add more than 7 cards to the board");
        }

        _playerCreatures.Add(creature);
    }

    public void AddOpponentCreature(Entity creature)
    {
        if (_playerCreatures.Count + _playerSpells.Count >= 7)
        {
            throw new InvalidOperationException("Cannot add more than 7 cards to the opponent board");
        }

        _opponentCreatures.Add(creature);
    }

    public void AddSpell(ISpell spell)
    {
        if (_playerCreatures.Count + _playerSpells.Count >= 7)
        {
            throw new InvalidOperationException("Cannot add more than 7 cards to the board");
        }

        _playerSpells.Add(spell);
    }

    public void AddOpponentSpell(ISpell spell)
    {
        if (_playerCreatures.Count + _playerSpells.Count >= 7)
        {
            throw new InvalidOperationException("Cannot add more than 7 cards to the opponent board");
        }

        _opponentSpells.Add(spell);
    }

    public void UseSpell(ISpell spell, Entity target)
    {
        if (_playerSpells.Contains(spell))
        {
            spell.Apply(target);
            _playerSpells.Remove(spell);
        }
    }

    public void UseOpponentSpell(ISpell spell, Entity target)
    {
        if (_opponentSpells.Contains(spell))
        {
            spell.Apply(target);
            _opponentSpells.Remove(spell);
        }
    }

    public void RemoveDeadCreatures()
    {
        _playerCreatures.RemoveAll(creature => creature.HealthPoints <= 0);
        _opponentCreatures.RemoveAll(creature => creature.HealthPoints <= 0);
    }

    public IReadOnlyList<Entity> GetAttackingCreatures(bool isPlayer)
    {
        List<Entity> creatures = isPlayer ? _playerCreatures : _opponentCreatures;
        return creatures.Where(c => c.Damage > 0 && c.HealthPoints > 0).ToList();
    }

    public IReadOnlyList<Entity> GetDefendingCreatures(bool isPlayer)
    {
        List<Entity> creatures = isPlayer ? _playerCreatures : _opponentCreatures;
        return creatures.Where(c => c.HealthPoints > 0).ToList();
    }

    public BattleResult ProcessBattle()
    {
        int maxRounds = 50;
        int currentRound = 0;
        bool playerTurn = true;

        while (currentRound < maxRounds)
        {
            RemoveDeadCreatures();

            IReadOnlyList<Entity> playerAttackers = GetAttackingCreatures(true);
            IReadOnlyList<Entity> playerDefenders = GetDefendingCreatures(true);
            IReadOnlyList<Entity> opponentAttackers = GetAttackingCreatures(false);
            IReadOnlyList<Entity> opponentDefenders = GetDefendingCreatures(false);

            if (playerAttackers.Any() && !opponentDefenders.Any())
                return BattleResult.PlayerWin;

            if (opponentAttackers.Any() && !playerDefenders.Any())
                return BattleResult.OpponentWin;

            if (!playerAttackers.Any() && !opponentAttackers.Any())
                return BattleResult.Draw;

            if (playerTurn && !playerAttackers.Any())
            {
                playerTurn = !playerTurn;
                currentRound++;
                continue;
            }

            if (!playerTurn && !opponentAttackers.Any())
            {
                playerTurn = !playerTurn;
                currentRound++;
                continue;
            }

            if (playerTurn)
            {
                Entity attacker = playerAttackers.First();
                Entity defender = opponentDefenders.First();
                attacker.Fight(defender);
            }
            else
            {
                Entity attacker = opponentAttackers.First();
                Entity defender = playerDefenders.First();
                attacker.Fight(defender);
            }

            playerTurn = !playerTurn;
            currentRound++;
        }

        return BattleResult.Draw;
    }
}