﻿using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Data.Configuration
{
    public class CandidateConfiguration:EntityTypeConfiguration<Candidate>
    {
        public CandidateConfiguration()
        {
            ToTable("Candidates");
            Property(c=>c.CandidateId).
        }

    }
}
