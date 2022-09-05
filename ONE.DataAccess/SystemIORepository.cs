using Newtonsoft.Json;
using ONE.Models.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ONE.DataAccess
{
    public class SystemIORepository
    {
        public List<SystemIOInfo> GetSystemIOInfos()
        {
            using (StreamReader streamReader = new StreamReader("SystemIOData.json"))
            {
                string json = streamReader.ReadToEnd();
                List<SystemIOInfo> systemIOInfos = JsonConvert.DeserializeObject<List<SystemIOInfo>>(json);
                return systemIOInfos;

            }
        }

        public Guid GetSystemIOGuid(Guid systemIOGuid)
        {
            List<SystemIOInfo> systemIOInfos = GetSystemIOInfos();
            SystemIOInfo systemIOInfo = systemIOInfos.Where(x => x.SystemIOGuid == systemIOGuid).FirstOrDefault();
            if (systemIOInfo != null)
            {
                return systemIOInfo.SystemIOGuid;
            }
            return Guid.Empty;
        }

        public SystemIOInfo GetSystemIOInfo(Guid systemIOGuid)
        {
            List<SystemIOInfo> systemIOInfos = GetSystemIOInfos();
            SystemIOInfo systemIOInfo = systemIOInfos.Where(x => x.SystemIOGuid == systemIOGuid).FirstOrDefault();
            return systemIOInfo;
        }
    }
}
