﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Domain.Entities
{
    public class AttestationAnswer : BaseEntity
    {
        public int IdAttestation { get; set; }
        public int IdUserParticipant { get; set; }
        public int IdModule { get; set; }
        public int IdQuestion { get; set; }
        public int IdAnswer { get; set; }
        public string TextAnswer { get; set; }
    }
}