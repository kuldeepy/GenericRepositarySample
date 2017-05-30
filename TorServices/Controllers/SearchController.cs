using BusinessEntities.Search;
using BusinessEntities.User;
using BusinessServices.Implementation;
using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TorServices.ErrorHelper;
using TorServices.Filters;
using TorServices.Filters.ActionFilters;
using TorServices.Repositary;

namespace TorServices.Controllers
{
    [RoutePrefix("api/tor-service")]
    public class SearchController : ApiController
    {
        private readonly IUserServices _userServices;
        private readonly ISearchServices _searchService;

        public SearchController(IUserServices userServices, ISearchServices searchServices)
        {
            if (userServices == null)
                throw new ArgumentNullException("userServices");
            _userServices = userServices;
            if (searchServices == null)
                throw new ArgumentNullException("searchService");
            _searchService = searchServices;
        }

        [HttpGet]
        [Route("health")]
        public IHttpActionResult Health()
        {
            var hostName = Dns.GetHostName();
            var hostIp = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return Ok($"Server is up! You are connected to {hostIp}");
        }

        [HttpGet]
        [Route("get/exception")]
        public List<User> GetException()
        {
            throw new Exception("Request is Invalid");
        }

        [HttpGet]
        [Route("users")]
        public List<User> GetAllUsers()
        {
            var users = _userServices.GetAllUsers().ToList();
            return users;
        }

        [HttpGet]
        [Route("user/{username}/")]
        public User GetUserByName(string username)
        {
            var user = _userServices.GetUserByName(username);
            if (user != null)
                return user;
            throw new ApiDataException(1001,$"User not found with username {username}",HttpStatusCode.BadRequest) ;
        }

        [AuthorizationRequired]
        [HttpPost]
        [Route("search")]
        public IHttpActionResult Search(SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
                throw new ApiBusinessException(1001, "Bad request", HttpStatusCode.BadRequest);
            else {
                var response = _searchService.Find(searchCriteria);
                return Ok(response);
            }
            
        }
    }
}
