﻿using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geep.DomainLayer.CustomAbstrations
{
    public interface IBeneficiaryManagement
    {
        Task<List<BeneficiaryVm>> GetBeneficiaryByAssociationId(int id);
        Task<List<BeneficiaryVm>> GetBeneficiaryByAgentId(int id);
        Task<AgentVm> GetAgentByReferenceId(string id);
        Task<AgentVm> AddAgent(AgentVm vm);
        Task<AssociationVm> GetAssociationByAssociationName(string groupName);
        Task PushRecordsToWhiteList();
        Task<(int beneficiaryId, string message)> AddBeneficiary(BeneficiaryVm vm);
        Task<List<GeepAgent>> GetGeepAgents();
        Task<(int beneficiaryId, string message)> UpdateBeneficiary(BeneficiaryVm vm);
    }
}
