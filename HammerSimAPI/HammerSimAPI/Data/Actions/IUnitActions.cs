using HammerSimAPI.Models.Units;

namespace HammerSimAPI.Data.Actions
{
    public interface IUnitActions
    {
        Task AddUnit(Unit unit);
    }
}