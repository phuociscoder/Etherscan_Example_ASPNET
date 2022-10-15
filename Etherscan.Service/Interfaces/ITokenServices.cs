using Etherscan.Model.Dto;
using System.Data;

namespace Etherscan.Service.Interfaces
{
    public interface ITokenServices
    {
        int Create(TokenDto model);
        int Update(int tokenId, TokenDto model);
        DataTable GetList();
        
    }
}
