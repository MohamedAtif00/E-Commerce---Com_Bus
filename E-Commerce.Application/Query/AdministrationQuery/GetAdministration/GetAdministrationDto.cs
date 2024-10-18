using E_Commerce.Domain.Model.AdministrationAggre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.GetAdministration
{
    public record GetAdministrationDto(string? websiteColor,
                                      string? title_Eng = null,
                                      string? title_Arb = null,
                                      string? Desc_Eng = null,
                                      string? Desc_Arb = null,
                                      string? marquee_Eng = null,
                                      string? marquee_Arb = null,
                                      List<Group>? Groups = null);
    
    
}
