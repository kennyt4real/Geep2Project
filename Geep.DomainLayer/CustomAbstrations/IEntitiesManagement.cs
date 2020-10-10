using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geep.DomainLayer.CustomAbstrations
{
    public interface IEntitiesManagement
    {
        Task<List<BeneficiaryVm>> GetBeneficiaryByAssociationId(int id);
        Task<List<BeneficiaryVm>> GetBeneficiaryByAgentId(int id);
        Task<AgentVm> GetAgentByReferenceId(string id);
        Task<AgentVm> AddAgent(AgentVm vm);
        Task<AssociationVm> GetAssociationByAssociationName(string groupName);
        Task PushBeneficiaryRecordsToWhiteList();
        Task<(int beneficiaryId, string message)> AddBeneficiary(BeneficiaryVm vm);
        Task<List<GeepAgent>> GetGeepAgents();
        Task<(int beneficiaryId, string message)> UpdateBeneficiary(BeneficiaryVm vm);
        Task<ResponseVm> AddAgentsToClusters(AgentClusterLocationVm vm);
        Task CreateGroupOnWhiteList();
        Task<int> AddAssociation(AssociationVm vm);
        Task AddAssociationDocument(DocumentVm vm);
        Task<BeneficiaryVm> GetBeneficiaryByPhoneNumber(string phoneNumber);
    }
}
