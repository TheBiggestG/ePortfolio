using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteInserts.Models.BaseClasses
{
    public abstract class InternalIdClass: NameClass
    {
        public ulong _internalId { get; set; }
    }
}
