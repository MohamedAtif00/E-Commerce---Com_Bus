﻿using E_Commerce.SharedKernal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Model.AdministrationAggre
{
    public class WelcomeMessage : ValueObject
    {
        public WelcomeMessage(string? title_Eng, string? title_Arb, string? desc_Eng, string? desc_Arb)
        {
            Title_Eng = title_Eng;
            Title_Arb = title_Arb;
            Desc_Eng = desc_Eng;
            Desc_Arb = desc_Arb;
        }

        public string? Title_Eng { get; set; }
        public string? Title_Arb {  get; set; }
        public string? Desc_Eng { get; set; }
        public string? Desc_Arb { get; set; }




        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Title_Arb,Title_Eng,Desc_Arb,Desc_Eng };
        }
    }
}