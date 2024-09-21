﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class ProductCampaign : Campaign // It can contribute to business and fashion influencers
    {
        private const double InitialBudget = 60000;

        public ProductCampaign(string brand)
            : base(brand, InitialBudget)
        {
        }
    }
}
