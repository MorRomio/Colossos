using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace AuthSys.SignalRhub
{
    public class HubSignalR : Hub
    {
             
        public void Test( )
        {
            Clients.All.TestMessages("Hello from server");
            //Clients.Caller.AddCard("testDiv");
            //return "Success from server";
        }

        public void CardAdded() {
            var context = GlobalHost.ConnectionManager.GetHubContext<HubSignalR>();
            context.Clients.All.AddCard();
        }
    }
}