using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.AdministrationAggre
{
    public class Administration : AggregateRoot<AdministrationId>
    {


        public Administration(AdministrationId id) : base(id)
        {
        }
        public HeroImage _heroImage { get; set; }
        public WelcomeMessage _welcomeMessage { get; set; }
        public Description _description { get; set; }
        public string _websiteColor { get; set; } = "#FBD5D5";
        

        public static Administration Create()
        {
            return new(AdministrationId.CreateUnique());
        }

        public void UpdateHeroImage(HeroImage hero)
        {
            _heroImage = hero;
        }

        public void UpdateWebsiteColor(string color)
        {
            if(color == null)
                _websiteColor = "#FBD5D5";
            else
            _websiteColor = color;
        }

        public void UpdateWelcomeMessage(WelcomeMessage message)
        {
            _welcomeMessage = message;
        }

        public void UpdateDescription(Description description)
        {
            _description = description;
        }
       
    }
}
