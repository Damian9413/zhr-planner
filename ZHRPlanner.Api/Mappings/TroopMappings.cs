using ZHRPlanner.Api.Domain.Entities;
using ZHRPlanner.Api.Dtos.Troops;

namespace ZHRPlanner.Api.Mappings;

public static class TroopMappings
{
    public static TroopResponse ToResponse(this Troop troop)
    {
        return new TroopResponse(troop.Id, troop.ShortName, troop.FullName);
    }
}
