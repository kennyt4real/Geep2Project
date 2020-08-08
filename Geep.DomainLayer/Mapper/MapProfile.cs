using AutoMapper;
using Geep.Models.Core;
using Geep.ViewModels.CoreVm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.DomainLayer.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Reverse map to be reviewedd


            CreateMap<Agent, AgentVm>().ReverseMap();


            CreateMap<Beneficiary, BeneficiaryVm>().ReverseMap();


            CreateMap<AgentClusterLocation, AgentClusterLocationVm>().ReverseMap();


            CreateMap<State, StateVm>().ReverseMap();


            CreateMap<LocalGovernmentArea, LocalGovernmentAreaVm>().ReverseMap();


            CreateMap<Association, AssociationVm>().ReverseMap();


            CreateMap<AssociationBeneficiary, AssociationBeneficiaryVm>().ReverseMap();


            CreateMap<ClusterLocation, ClusterLocationVm>().ReverseMap();
        }
    }
}
