using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.AdministrationCommand.SetDescriptionCommand
{
    public record SetDescriptionCommand(string title_eng,string title_arb,string desc_eng,string desc_arb):ICommand;
    
    
}
