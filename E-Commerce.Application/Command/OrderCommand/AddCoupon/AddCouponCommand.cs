using E_Commerce.SharedKernal.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.OrderCommand.AddCoupon
{
    public record AddCouponCommand(string code,
                                    decimal discount,
                                    DateTime expirationDate,
                                    bool isActive,
                                    int usageLimit) :ICommand;
    
    
}
