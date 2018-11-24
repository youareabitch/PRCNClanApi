using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRCN.Clan.Api.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x => {
                x.AddProfile<AutoMapperConfigFile>();
            });
        }
    }
}