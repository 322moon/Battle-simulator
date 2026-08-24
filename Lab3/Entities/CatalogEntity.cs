using Itmo.ObjectOrientedProgramming.Lab3.Helpers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class CatalogEntity
{
    private List<Func<Entity>> AllEntities { get; }

    public CatalogEntity()
    {
        AllEntities = new List<Func<Entity>>();

        InitializeDefaultCreatures();
    }

    public Entity GetRandomEntity()
    {
        Func<Entity> factory = AllEntities[SimpleRandom.Next(AllEntities.Count)];
        return factory();
    }

    private void InitializeDefaultCreatures()
    {
        AllEntities.Add(() => new ViciousFighter());
        AllEntities.Add(() => new BattleAnalyst());
        AllEntities.Add(() => new MasterOfAmulets());
        AllEntities.Add(() => new MimicChest());
        AllEntities.Add(() => new ImmortalHorror());
    }
}