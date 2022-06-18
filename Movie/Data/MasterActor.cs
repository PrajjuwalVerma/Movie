using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Data
{
    public class MasterActor
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
    }
}
