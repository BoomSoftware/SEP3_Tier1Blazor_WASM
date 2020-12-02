﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data.AdminData
{
    public interface IAdminManager
    {
        Task<IList<UserShortVersion>> GetUsers(int number, int offset);
        Task<List<int>> GetPosts(int number, int offset);
        Task<int> GetTotalNumberOfUsers();
        Task<int> GetTotalNumberOfPosts();

    }
}