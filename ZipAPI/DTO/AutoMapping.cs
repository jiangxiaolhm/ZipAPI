using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZipAPI.Models;

namespace ZipAPI.ViewModels
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserPostDTO>();
            CreateMap<UserPostDTO, User>();

            CreateMap<Account, AccountPostDTO>();
            CreateMap<AccountPostDTO, Account>();
        }
    }
}
