using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Data
{
    public class MasterMovie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTimeOffset DateOfRelease { get; set; }
    }
}
