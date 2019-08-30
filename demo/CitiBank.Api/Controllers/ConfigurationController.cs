using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xendor.CommandModel.EventSourcing;
using Xendor.CommandModel.EventSourcing.SnapShotting;
using Xendor.EventBus;

namespace CitiBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IEventStorage _eventStorage;
        private readonly ISnapshotStorage _snapshotStorage;
        private readonly IEventBus _eventBus;
        public ConfigurationController(IEventStorage eventStorage, ISnapshotStorage snapshotStorage,  IEventBus eventBus)
        {
            _eventStorage = eventStorage ?? throw new ArgumentNullException(nameof(eventStorage));
            _snapshotStorage = snapshotStorage ?? throw new ArgumentNullException(nameof(snapshotStorage));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }


        // POST api/services
        [HttpPost]
        public Task Post()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(a => a.GetName().Name == "CitiBank.Domain");
            _eventStorage.Setup(assembly);
            _snapshotStorage.Setup(assembly);
            return Task.CompletedTask;
        }
    }
}