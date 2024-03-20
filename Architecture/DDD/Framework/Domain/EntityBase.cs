using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain;

public abstract class EntityBase
{
    protected EntityBase()
    {
        Id = 1;
    }

    public long Id { get; set; }
}
