﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitution_breaker.Genetic_algorithm
{
    public class Population
    {
       public IEnumerable<ISolution> Solutions { get; set; }


        double AverageFitness()
        {
            throw new NotImplementedException();
        }
    }
}
