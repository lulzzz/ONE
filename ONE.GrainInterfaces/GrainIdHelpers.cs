using System;

namespace ONE.GrainInterfaces
{
    public class GrainIdHelpers
    {
        private static Guid UUID_Namespace = new Guid("ce2fa4e6-3a17-442d-bda0-77d95b52eb15");

        /// <summary>
        /// Gets the grain id as a GUID, if the id is guid it just converts it, 
        /// if the id is a string that is not a guid string, then it creates a deterministic name based UUID (v5) from the string id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Guid GetGrainIdAsGuid(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return Guid.Empty;
            }

            if (Guid.TryParse(id, out var uuid))
            {
                return uuid;
            }
            return UUIDNext.Uuid.NewNameBased(UUID_Namespace, id);
        }
    }
}
