﻿using AspnetRun.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IOrderAppService
    {
        Task CheckOut(OrderDto orderDto);
    }
}
