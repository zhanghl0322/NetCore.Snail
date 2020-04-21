using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snail.IService;
using Snail.Model;

namespace Snail.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "Permission")]
    public class SecretController : ControllerBase
    {
        #region Initialize

        /// <summary>
        /// Jwt 服务
        /// </summary>
        private readonly IJwtAppService _jwtApp;

    
        /// <summary>
        /// 用户服务
        /// </summary>
        private readonly ISecretAppService _secretApp;

      
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="jwtApp"></param>
        /// <param name="secretApp"></param>
        public SecretController(IJwtAppService jwtApp, ISecretAppService secretApp)
        {
            _jwtApp = jwtApp;
            _secretApp = secretApp;
        }

        #endregion

        UserDto a = new UserDto();


    }

}