using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteBotigaSabates.StaticContent
{
    class ClientConnected
    {
        public static Client AuthClient;

        public ClientConnected(Client client)
        {
            AuthClient = client;
        }

    }
}
