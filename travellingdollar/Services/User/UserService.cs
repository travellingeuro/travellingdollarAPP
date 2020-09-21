﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using travellingdollar.Models;
using travellingdollar.Services.Request;

namespace travellingdollar.Services.User
{
    public class UserService : IUserService
    {
        readonly IRequestService requestService;

        public UserService(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        public Task<List<Users>> GetUserEmail(string email)

        {
            var builder = new UriBuilder(AppSettings.UserEndPoint);

            builder.Query = $"?email={email}";

            var uri = builder.ToString();

            return requestService.GetAsync<List<Users>>(uri);
        }

        public async Task<string> PostUser(Models.Users user)
        {
            var builder = new UriBuilder(AppSettings.UserEndPoint);

            var uri = builder.ToString();

            var response = await requestService.PostAsync<Models.Users, string>(uri, user);

            return response;
        }
    }
}
