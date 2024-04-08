using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer // It can contribute to service campaigns
    {
        private const double EngagementRate = 2.0;
        private const double Factor = 0.2;

        public BloggerInfluencer(string username, int followers)
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
