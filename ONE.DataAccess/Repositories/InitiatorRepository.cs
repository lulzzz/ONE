using ONE.Common.Utility;
using ONE.DataAccess.Models;
using ONE.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ONE.DataAccess.Repositories
{
    public class InitiatorRepository : IInitiatorRepository
    {
        private readonly ONEContext _oneContext;

        public InitiatorRepository(ONEContext oneDBContext)
        {
            _oneContext = oneDBContext;
        }


        /// <summary>
        /// Get Initiator list for the respective location section
        /// </summary>        
        /// <returns></returns>
        public List<InitiatorInfo> GetAllInitiatorInfos()
        {
            List<InitiatorInfo> initiatorInfos = (from i in _oneContext.Initiators
                                                  join it in _oneContext.InitiatorTypes on i.InitiatorTypeCode equals it.InitiatorTypeCode
                                                  join pt in _oneContext.ProtocolTypes on it.ProtocolTypecode equals pt.ProtocolTypeCode
                                                  join eit in _oneContext.EventInterpreterTypes on it.EventInterpreterTypeCode equals eit.EventInterpreterTypeCode
                                                  join at in _oneContext.ApplicationTypes on i.ApplicationTypeCode equals at.ApplicationTypeCode
                                                  join ef in _oneContext.EventFlows on i.EventFlowGuid equals ef.EventFlowGuid
                                                  join st in _oneContext.StatusTypes on i.StatusTypeCode equals st.StatusTypeCode
                                                  join cls in _oneContext.CustomerLocationSections on i.CustomerLocationSectionGuid equals cls.CustomerLocationSectionGuid
                                                  join cl in _oneContext.CustomerLocations on cls.CustomerLocationGuid equals cl.CustomerLocationGuid
                                                  where i.StatusTypeCode == (int)ONE.Models.Enumerations.StatusType.Active
                                                  select new InitiatorInfo
                                                  {
                                                      InitiatorGuid = i.InitiatorGuid,
                                                      InitiatorTypeCode = it.InitiatorTypeCode,
                                                      InitiatorTypeName = it.Name,
                                                      InitiatorTypeEnumName = it.EnumName,
                                                      CheckInWindowMinutes = it.CheckInWindowMinutes,
                                                      ApplicationTypeCode = at.ApplicationTypeCode,
                                                      ApplicationType = at.Name,
                                                      ProtocolTypeCode = it.ProtocolTypecode,
                                                      ProtocolTypeEnumName = pt.EnumName,
                                                      EventInterpreterTypeEnumName = eit.EnumName,
                                                      EventFlowGuid = ef.EventFlowGuid,
                                                      EventFlow = ef.Name,
                                                      Status = ((ONE.Models.Enumerations.StatusType)i.StatusTypeCode).ToString(),
                                                      InitiatorConfigurationDataXML = i.InitiatorConfigurationDataXml,
                                                      CustomerLocationSectionGuid = i.CustomerLocationSectionGuid,
                                                      CustomerLocationSectionName = cls.Name,
                                                      IsDoubleLocked = i.IsDoubleLocked,
                                                  }).OrderBy(s => s.InitiatorTypeEnumName).ToList();


            foreach (InitiatorInfo InitiatorInfo in initiatorInfos)
            {
                Type configurationDataType = TypeHelper.GetFirstTypeFoundInAllAssemblies($"{InitiatorInfo.InitiatorTypeEnumName}ConfigurationData");
                //See if we were able to retrieve it
                if (configurationDataType == null)
                {
                    configurationDataType = TypeHelper.GetFirstTypeFoundInAllAssemblies($"{InitiatorInfo.ProtocolTypeEnumName}ConfigurationData");
                }
                if (configurationDataType != null)
                {
                    InitiatorInfo.ConfigurationData = SerializationExtensions.LoadFromXmlString(configurationDataType, InitiatorInfo.InitiatorConfigurationDataXML);
                }
            }

            return initiatorInfos;
        }
    }
}
