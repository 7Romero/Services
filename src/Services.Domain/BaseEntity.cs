﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain;

public class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; }
}
