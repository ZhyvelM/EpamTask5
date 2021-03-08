using AutoMapper;
using BL;
using EpamTask5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamTask5.Util
{
    public class WebMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration
            (
                cfg =>
                {
                    cfg.CreateMap<SaleDTO, SaleViewModel>();
                    cfg.CreateMap<SaleViewModel, SaleDTO>();
                    cfg.CreateMap<CreateSaleViewModel, SaleDTO>();
                }
            );
            return config;
        }
    }
}