using AutoMapper;
using Geep.Models.Core;
using Geep.ViewModels;
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


            CreateMap<Models.Core.Agent, AgentVm>().ReverseMap();


            CreateMap<BeneficiaryVm, Beneficiary>();
            CreateMap<Beneficiary, BeneficiaryVm>()
                    .ForMember(x => x.AgentName, o => o.MapFrom(source => source.Agent.AgentFullName))
                    .ForMember(x => x.AssociationName, o => o.MapFrom(source => source.Association.AssociationName))
                    .ForMember(x=>x.AgentRefId, o=>o.MapFrom(source=>source.Agent.ReferenceId));


            CreateMap<AgentClusterLocationVm, AgentClusterLocation>();
            CreateMap<AgentClusterLocation, AgentClusterLocationVm>()
                .ForMember(x => x.AgentName, o => o.MapFrom(source => source.Agent.AgentFullName))
                .ForMember(x => x.AgentEmail, o => o.MapFrom(source => source.Agent.Email))
                .ForMember(x => x.AgentRefId, o => o.MapFrom(source => source.Agent.ReferenceId))
                .ForMember(x => x.ClusterName, o => o.MapFrom(source => source.ClusterLocation.Name))
                .ForMember(x => x.ClusterStateName, o => o.MapFrom(source => source.ClusterLocation.State.StateName));


            CreateMap<State, StateVm>().ReverseMap();


            CreateMap<LocalGovernmentAreaVm, LocalGovernmentArea>();
            CreateMap<LocalGovernmentArea, LocalGovernmentAreaVm>()
                .ForMember(x => x.StateName, o => o.MapFrom(source => source.State.StateName));


            CreateMap<AssociationVm, Association>();
            CreateMap<Association, AssociationVm>()
                .ForMember(x => x.AssociationState, o => o.MapFrom(source => source.LocalGovernmentArea.State.StateName))
                .ForMember(x => x.AssociationLga, o => o.MapFrom(source => source.LocalGovernmentArea.LgaName));


            CreateMap<AssociationBeneficiaryVm, AssociationBeneficiary>();
            CreateMap<AssociationBeneficiary, AssociationBeneficiaryVm>()
                .ForMember(x => x.BeneficiaryFullName, o => o.MapFrom(source => source.Beneficiary.BeneficiaryFullName))
                .ForMember(x => x.AssociationName, o => o.MapFrom(source => source.Association.AssociationName));


            CreateMap<ClusterLocationVm, ClusterLocation>();
            CreateMap<ClusterLocation, ClusterLocationVm>()
                .ForMember(x => x.StateName, o => o.MapFrom(source => source.State.StateName));

            CreateMap<BeneficiaryVm, UpdateRecordOnPortalModel>();

            CreateMap<BeneficiaryVm, BOIFields>()
                .ForMember(x=>x.Agent, opt => opt.Ignore());
        }
        
    }
}
