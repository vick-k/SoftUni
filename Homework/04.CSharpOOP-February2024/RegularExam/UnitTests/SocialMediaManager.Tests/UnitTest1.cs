using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            InfluencerRepository repo = new InfluencerRepository();

            Assert.That(repo, Is.Not.Null);
            Assert.That(repo.Influencers.Count, Is.EqualTo(0));
        }

        [Test]
        public void RegisterInfluencer_Null()
        {
            InfluencerRepository repo = new InfluencerRepository();
            Influencer influencer = null;
            Assert.Throws<ArgumentNullException>(() => repo.RegisterInfluencer(influencer));
        }

        [Test]
        public void RegisterInfluencer_UsernameExist()
        {
            InfluencerRepository repo = new InfluencerRepository();
            Influencer influencer = new Influencer("vik", 10);
            Influencer influencer2 = new Influencer("vik", 10);
            repo.RegisterInfluencer(influencer);

            Assert.Throws<InvalidOperationException>(() => repo.RegisterInfluencer(influencer2));
        }

        [Test]
        public void RegisterInfluencer_Success()
        {
            InfluencerRepository repo = new InfluencerRepository();
            Influencer influencer = new Influencer("vik", 10);

            string message = "Successfully added influencer vik with 10";

            Assert.That(repo.RegisterInfluencer(influencer), Is.EqualTo(message));
            Assert.That(repo.Influencers.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveInfluencer_Null()
        {
            InfluencerRepository repo = new InfluencerRepository();
            string nullString = null;

            Assert.Throws<ArgumentNullException>(() => repo.RemoveInfluencer(nullString));
        }

        [Test]
        public void RemoveInfluencer_WhiteSpace()
        {
            InfluencerRepository repo = new InfluencerRepository();
            string whiteSpace = " ";

            Assert.Throws<ArgumentNullException>(() => repo.RemoveInfluencer(whiteSpace));
        }

        [Test]
        public void RemoveInfluencer_Success()
        {
            InfluencerRepository repo = new InfluencerRepository();
            Influencer influencer = new Influencer("vik", 10);
            repo.RegisterInfluencer(influencer);

            Assert.That(repo.RemoveInfluencer("vik"), Is.True);
        }

        [Test]
        public void GetInfluencerWithMostFollowers()
        {
            InfluencerRepository repo = new InfluencerRepository();
            Influencer influencer = new Influencer("vik", 10);
            Influencer influencer2 = new Influencer("ivan", 20);
            Influencer influencer3 = new Influencer("peter", 30);
            repo.RegisterInfluencer(influencer);
            repo.RegisterInfluencer(influencer2);
            repo.RegisterInfluencer(influencer3);

            Assert.That(repo.GetInfluencerWithMostFollowers(), Is.EqualTo(influencer3));
        }

        [Test]
        public void GetInfluencer_Null()
        {
            InfluencerRepository repo = new InfluencerRepository();
            Influencer influencer = new Influencer("vik", 10);
            Influencer influencer2 = new Influencer("ivan", 20);
            Influencer influencer3 = new Influencer("peter", 30);
            repo.RegisterInfluencer(influencer);
            repo.RegisterInfluencer(influencer2);
            repo.RegisterInfluencer(influencer3);

            Assert.That(repo.GetInfluencer("none"), Is.Null);
        }

        [Test]
        public void GetInfluencer_Success()
        {
            InfluencerRepository repo = new InfluencerRepository();
            Influencer influencer = new Influencer("vik", 10);
            Influencer influencer2 = new Influencer("ivan", 20);
            Influencer influencer3 = new Influencer("peter", 30);
            repo.RegisterInfluencer(influencer);
            repo.RegisterInfluencer(influencer2);
            repo.RegisterInfluencer(influencer3);

            Assert.That(repo.GetInfluencer("vik"), Is.EqualTo(influencer));
        }
    }
}