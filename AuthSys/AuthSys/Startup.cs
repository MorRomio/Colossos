﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthSys.Startup))]
namespace AuthSys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}