using BusinessEntities.User;

namespace BusinessServices.Interfaces
{
    public interface ITokenServices
    {
        #region Interface member methods.

        /// <summary>
        /// Function to generate unique token with expiry againt the provided userId.
        /// Also add a record in database for generated token.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        TokenEntity GenerateToken(int userId);

        /// <summary>
        /// Function to validate token against the expiry and existance in databsae.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        bool ValidateToken(string tokenId);

        /// <summary>
        /// Method to kill the provided token id.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        bool Kill(string tokenId);

        /// <summary>
        /// Delete tokens for the specific deleted user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool DeleteByUserId(int userId);
        #endregion
    }
}
