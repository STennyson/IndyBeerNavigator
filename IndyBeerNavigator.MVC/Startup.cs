﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndyBeerNavigator.MVC.Startup))]
namespace IndyBeerNavigator.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
