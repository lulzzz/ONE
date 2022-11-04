using ONE.Models.Domain;
using System.Collections.Generic;

namespace ONE.DataAccess.Repositories
{
    public interface ISystemIORepository
    {
        List<SystemIOInfo> GetAllSystemIOs();
    }
}
