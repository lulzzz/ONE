using Microsoft.Extensions.Logging;
using ONE.DataAccess.Repositories;
using ONE.GrainInterfaces.EventInterpreter;
using ONE.Models.Domain;
using ONE.Models.Initiator.ConfigurationData;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONE.Silo.Grains.EventInterpreter
{
    public class EventInterpreterRouterGrain : GrainBase, IEventInterpreterRouterGrain
    {

        private readonly IPersistentState<List<InitiatorInfo>> _initiatorInfos;
        private IInitiatorRepository _initiatorRepository = null;

        public EventInterpreterRouterGrain([PersistentState("initiatorInfos", "oneDataStore")] IPersistentState<List<InitiatorInfo>> initiatorInfos, IInitiatorRepository initiatorRepository)
        {
            _initiatorInfos = initiatorInfos;
            _initiatorRepository = initiatorRepository;
        }

        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();
            _initiatorInfos.State = _initiatorRepository.GetAllInitiatorInfos();
            await _initiatorInfos.WriteStateAsync();
        }

        public Task OnCompletedAsync()
        {
            Logger.LogInformation("Stream completed");
            return Task.CompletedTask;
        }

        public Task OnErrorAsync(Exception ex)
        {
            Logger.LogError("Stream error");
            return Task.CompletedTask;
        }

        public Task<List<InitiatorInfo>> GetInterpreterInitiatorInfos()
        {
            return Task.FromResult(_initiatorInfos.State);
        }
        public Task<string> GetMatchingEventInterpreterName(int serialNumber)
        {
            string eventInterpreterTypeEnumName = string.Empty;
            List<InitiatorInfo> initiatorInfoList = Task.FromResult(_initiatorInfos.State).Result;

            InitiatorInfo? initiatorInfo = initiatorInfoList.Where(x => x.ConfigurationData is EchoStreamConfigurationData && ((EchoStreamConfigurationData)x.ConfigurationData).SerialNumber == serialNumber).FirstOrDefault();

            if (initiatorInfo != null)
            {
                eventInterpreterTypeEnumName = initiatorInfo.EventInterpreterTypeEnumName;
            }
            return Task.FromResult(eventInterpreterTypeEnumName);
        }
    }
}
