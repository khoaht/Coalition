﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Infrastructure.Criterias;
using CL.Infrastructure.Services.Interfaces;
using Domain.Entity;

namespace CL.Infrastructure.Services
{
    public interface IClientService : IService<Guid, Client, ClientCriteria>
    {
        //TODO: Define anothers services
    }
}
