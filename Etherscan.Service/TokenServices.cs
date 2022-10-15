using Etherscan.Model.Dto;
using Etherscan.Repository.Interfaces;
using Etherscan.Service.Interfaces;
using System.Data;

namespace Etherscan.Service
{
    public class TokenServices : ITokenServices
    {
        private ITokenRepository _tokenRepository;
        public TokenServices(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public int Create(TokenDto model)
        {
            return _tokenRepository.Create(new Model.Entity.TokenEntity { 
                Contract_Address = model.Contract_Address,
                Name = model.Name,
                Symbol = model.Symbol,
                Total_Holders = model.Total_Holders,
                Total_Supply = model.Total_Supply
            });
        }

        public DataTable GetList()
        {
            return _tokenRepository.GetListToken();
        }

        public int Update(int tokenId, TokenDto model)
        {
            return _tokenRepository.Update(tokenId, new Model.Entity.TokenEntity { 
                Contract_Address = model.Contract_Address,
                Name=model.Name,
                Symbol=model.Symbol,
                Total_Holders=model.Total_Holders,
                Total_Supply=model.Total_Supply
            });
        }
    }
}
