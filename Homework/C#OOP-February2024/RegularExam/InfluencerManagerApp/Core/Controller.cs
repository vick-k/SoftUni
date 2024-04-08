using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName != "BusinessInfluencer" && typeName != "FashionInfluencer" && typeName != "BloggerInfluencer")
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (influencers.FindByName(username) != null)
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username, typeof(InfluencerRepository).Name);
            }

            IInfluencer influencer = null;

            if (typeName == "BusinessInfluencer")
            {
                influencer = new BusinessInfluencer(username, followers);
            }
            else if (typeName == "FashionInfluencer")
            {
                influencer = new FashionInfluencer(username, followers);
            }
            else if (typeName == "BloggerInfluencer")
            {
                influencer = new BloggerInfluencer(username, followers);
            }

            influencers.AddModel(influencer);

            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName != "ProductCampaign" && typeName != "ServiceCampaign")
            {
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            if (campaigns.FindByName(brand) != null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            ICampaign campaign = null;

            if (typeName == "ProductCampaign")
            {
                campaign = new ProductCampaign(brand);
            }
            else if (typeName == "ServiceCampaign")
            {
                campaign = new ServiceCampaign(brand);
            }

            campaigns.AddModel(campaign);

            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string AttractInfluencer(string brand, string username)
        {
            if (influencers.FindByName(username) == null)
            {
                return string.Format(OutputMessages.InfluencerNotFound, typeof(InfluencerRepository).Name, username);
            }

            if (campaigns.FindByName(brand) == null)
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }

            ICampaign currentCampaign = campaigns.FindByName(brand);

            if (currentCampaign.Contributors.Contains(username))
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            IInfluencer currentInfluencer = influencers.FindByName(username);

            if ((currentCampaign.GetType().Name == "ProductCampaign" && currentInfluencer.GetType().Name == "BloggerInfluencer") || (currentCampaign.GetType().Name == "ServiceCampaign" && currentInfluencer.GetType().Name == "FashionInfluencer"))
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (currentCampaign.Budget < currentInfluencer.CalculateCampaignPrice())
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            currentInfluencer.EnrollCampaign(brand);
            currentInfluencer.EarnFee(currentInfluencer.CalculateCampaignPrice());
            currentCampaign.Engage(currentInfluencer);

            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string FundCampaign(string brand, double amount)
        {
            if (campaigns.FindByName(brand) == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount <= 0)
            {
                return string.Format(OutputMessages.NotPositiveFundingAmount);
            }

            ICampaign currentCampaign = campaigns.FindByName(brand);
            currentCampaign.Gain(amount);

            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string CloseCampaign(string brand)
        {
            if (campaigns.FindByName(brand) == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToClose);
            }

            ICampaign currentCampaign = campaigns.FindByName(brand);

            if (currentCampaign.Budget <= 10000)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            foreach (var contributor in currentCampaign.Contributors)
            {
                IInfluencer currentInfluencer = influencers.FindByName(contributor);

                currentInfluencer.EarnFee(2000);
                currentInfluencer.EndParticipation(brand);
            }

            campaigns.RemoveModel(currentCampaign);

            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            if (influencers.FindByName(username) == null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned, username);
            }

            IInfluencer currentInfluencer = influencers.FindByName(username);

            if (currentInfluencer.Participations.Count > 0)
            {
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }
            else
            {
                influencers.RemoveModel(currentInfluencer);

                return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
            }

        }

        public string ApplicationReport()
        {
            StringBuilder sb = new();

            var sortedInfluencers = influencers.Models
                .OrderByDescending(m => m.Income)
                .ThenByDescending(m => m.Followers)
                .ToList();

            foreach (var influencer in sortedInfluencers)
            {
                sb.AppendLine(influencer.ToString());

                if (influencer.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");

                    foreach (var participation in influencer.Participations.OrderBy(p => p))
                    {
                        var currentCampaign = campaigns.FindByName(participation);

                        sb.AppendLine($"--{currentCampaign.ToString()}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
