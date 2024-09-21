using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class FashionInfluencer : Influencer // It can contribute to product campaigns
    {
        private const double EngagementRate = 4.0;
        private const double Factor = 0.1;

        public FashionInfluencer(string username, int followers)
            : base(username, followers, EngagementRate)
        {
        }

        public override int CalculateCampaignPrice()
        {
            double result = Math.Floor(Followers * EngagementRate * Factor);

            return (int)result;
        }
    }
}
