using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.AdministrationCommand.ChangeTitleCommand
{
    public record ChangeWelcomeCommand(string title_Eng,string title_Arb,string message_Eng,string message_Arb,string marquee_Eng,string marquee_Arb):ICommand;
    
    
}
