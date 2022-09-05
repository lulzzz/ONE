using Newtonsoft.Json;
using ONE.Models.Domain;
using System.Collections.Generic;
using System.IO;

namespace ONE.DataAccess
{
    public class InitiatorRepository
    {
        public List<InitiatorInfo> GetInterpreterInitiatorInfo()
        {
            using (StreamReader streamReader = new StreamReader("InitiatorInfoData.json"))
            {
                string json = streamReader.ReadToEnd();
                List<InitiatorInfo> initiatorInfos = JsonConvert.DeserializeObject<List<InitiatorInfo>>(json);
                return initiatorInfos;

            }
        }
    }
}
