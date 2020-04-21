using Snail.IService;
using Snail.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Snail.Service
{
    public class SecretAppService : ISecretAppService
    {
        public async Task<UserDto> GetCurrentUserAsync(string account, string password)
        {
            var user = new UserDto { Id=Guid.NewGuid(), Email="zhanghl0322@gmail.com", Phone="4008300000", Role= Guid.NewGuid(), UserName="Allon" };
            //Todo：AutoMapper 做实体转换
            return user;
        }
    }
}
