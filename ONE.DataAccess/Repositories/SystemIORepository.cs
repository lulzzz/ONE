using ONE.DataAccess.Models;
using ONE.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ONE.DataAccess.Repositories
{
    public class SystemIORepository : ISystemIORepository
    {
        private readonly ONEContext _oneContext;

        public SystemIORepository(ONEContext oneDBContext)
        {
            _oneContext = oneDBContext;
        }

        public List<SystemIOInfo> GetAllSystemIOs()
        {
            List<SystemIOInfo> systemIOInfos = (from sio in _oneContext.SystemIos
                                                where sio.IsActive
                                                select new SystemIOInfo
                                                {
                                                    SystemIOGUID = sio.SystemIoguid,
                                                    SystemIOType = (ONE.Models.Enumerations.SystemIOType)sio.SystemIotypeCode,
                                                    Name = sio.Name,
                                                    SystemIOConfigurationDataXML = sio.SystemIoconfigurationDataXml
                                                }).ToList();
            return systemIOInfos;
        }
    }
}
