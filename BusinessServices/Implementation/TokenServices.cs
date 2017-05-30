using System;
using BusinessEntities.User;
using BusinessServices.Interfaces;
using DAL.UnitOfWork;
using System.Linq;
using System.Configuration;
using DAL;

namespace BusinessServices.Implementation
{
    public class TokenServices : ITokenServices
    {
        #region Private memeber variables.

        private readonly UnitOfWork _unitOfWork;

        #endregion

        #region Public constructor.

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="unitOfWork"></param>
        public TokenServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Public member methods.

        /// <summary>
        /// Delete tokens for the specific deleted user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true for successful delete</returns>
        public bool DeleteByUserId(int userId)
        {
            _unitOfWork.TokenRepository.Delete(x => x.UserId == userId);
            _unitOfWork.Save();

            var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.UserId == userId).Any();
            return !isNotDeleted;
        }

        /// <summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenEntity GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issueOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(
                Convert.ToDouble(
                    ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            Token tokenModel = new Token
            {
                AuthToken = token,
                ExpiresOn = expiredOn,
                IssuedOn = issueOn,
                UserId = userId
            };

            _unitOfWork.TokenRepository.Insert(tokenModel);
            _unitOfWork.Save();

            var tokenDomain = new TokenEntity()
            {
                UserId = userId,
                IssuedOn = issueOn,
                ExpiresOn = expiredOn,
                AuthToken = token
            };

            return tokenDomain;
        }

        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId">true for successful delete</param>
        public bool Kill(string tokenId)
        {
            _unitOfWork.TokenRepository.Delete(x => x.AuthToken == tokenId);
            _unitOfWork.Save();
            var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.AuthToken == tokenId).Any();
            return !isNotDeleted;
        }

        /// <summary>
        /// Method to validate token against expiry and existence in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool ValidateToken(string tokenId)
        {
            var token = _unitOfWork.TokenRepository.Get(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now);
            if (token != null && !(DateTime.Now > token.ExpiresOn))
            {
                token.ExpiresOn = token.ExpiresOn.AddSeconds(
                Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                _unitOfWork.TokenRepository.Update(token);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        #endregion
    }
}
