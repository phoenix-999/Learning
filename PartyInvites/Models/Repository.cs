using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class Repository
    {
        private static List<GuestResponse> _responses = new List<GuestResponse>();

        public static IEnumerable<GuestResponse> Responses
        {
            get
            {
                return _responses;
            }
        }

        public static void AddResponse(GuestResponse response)
        {
            _responses.Add(response);
        }
    }
}
