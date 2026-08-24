using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ICards;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public interface ISpell : ICard
{
    void Apply(Entity target);
}