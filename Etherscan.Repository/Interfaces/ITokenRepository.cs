using Etherscan.Model.Entity;
using System.Collections;
using System.Data;

namespace Etherscan.Repository.Interfaces
{
    public interface ITokenRepository
    {
        int Create(TokenEntity model);
        int Update(int tokenId, TokenEntity model);
        DataTable GetListToken();
    }
}
