using ONE.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONE.DataAccess.Repositories
{
    public interface IInitiatorRepository
    {
        List<InitiatorInfo> GetAllInitiatorInfos();
    }
}
