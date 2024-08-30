using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteInserts.Models.BaseClasses
{
    public abstract class BaseDBClass
    {
        [Key]
        public int _id { get; set; }
    }
}
