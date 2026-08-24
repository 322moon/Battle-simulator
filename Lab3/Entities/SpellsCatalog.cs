using Itmo.ObjectOrientedProgramming.Lab3.Helpers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class SpellsCatalog
{
    private List<ISpell> AllSpells { get; }

    public SpellsCatalog()
    {
        AllSpells = new List<ISpell>();

        InitializeDefaultSpells();
    }

    public ISpell GetRandomSpell()
    {
        return AllSpells[SimpleRandom.Next(AllSpells.Count)];
    }

    private void InitializeDefaultSpells()
    {
        AllSpells.Add(new ProtectionAmulet());
        AllSpells.Add(new MagicMirror());
        AllSpells.Add(new StaminaPotion());
        AllSpells.Add(new StaminaPotion());
    }
}