﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IModifyTicketState
    {
        void TicketRegistered(TenantId Tenant, ProductId Product, TicketId Id, string Name, string Description);
    }
}