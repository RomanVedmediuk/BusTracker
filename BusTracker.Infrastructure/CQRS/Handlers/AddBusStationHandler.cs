namespace BusTracker.Infrastructure.CQRS.Handlers
{
    using System.Threading.Tasks;
    using BusTracker.Infrastructure.CQRS.Commands;
    using BusTracker.Infrastructure.Data.Contexts;
    using BusTracker.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AddBusStationHandler : ICommandHandler<AddGoogleBusStationCommand>
    {
        private readonly IReadWriteContext context;

        public AddBusStationHandler(IReadWriteContext context)
        {
            this.context = context;
        }

        public async Task Execute(AddGoogleBusStationCommand command)
        {
            var existingBusStation = await this.context.BusStation.FirstOrDefaultAsync(_ => _.StationInternalId == command.GooglePlaceId);

            if (existingBusStation == null)
            {
                var busStation = new BusStation
                {
                    StationInternalId = command.GooglePlaceId,
                    Name = command.Name,
                    Location = command.Location
                };

                await this.context.BusStation.AddAsync(busStation);
            }
        }
    }
}