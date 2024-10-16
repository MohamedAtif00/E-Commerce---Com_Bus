using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Query.AdministrationQuery.GetAdministration
{
    public record GetAdministrationDto(string? websiteColor,
                                      string? title_Eng,
                                      string? title_Arb,
                                      string? Desc_Eng,
                                      string? Desc_Arb,
                                      string? marquee_Eng,
                                      string? marquee_Arb);
    
    
}
