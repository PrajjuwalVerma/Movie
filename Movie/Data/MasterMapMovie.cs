using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Movie.Data;

namespace Movie.Data
{
    public class MasterMapMovie
    {
        public int MasterMapId;
        [ForeignKey(nameof(MasterMovie))]
        public int MovieId;
        public MasterMovie MasterMovie { get; set; }

        [ForeignKey(nameof(MasterActor))]
        public int ActorId;
        public MasterActor MasterActor { get; set; }

        [ForeignKey(nameof(MasterProducer))]
        public int ProducerId;
        public MasterProducer MasterProducer { get; set; }

    }
}
