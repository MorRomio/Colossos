using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AuthSys.Hubs
{
    public class HubSignalR : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void Send(string nogen, string besked, string connID)
        {
            //Send til alle
            Clients.All.addMessageToPage(nogen, besked);


            //Send til alle pånær requester
            //Clients.AllExcept(connID).addMessageToPage(nogen, besked + " " + connID);
        }
    }
}