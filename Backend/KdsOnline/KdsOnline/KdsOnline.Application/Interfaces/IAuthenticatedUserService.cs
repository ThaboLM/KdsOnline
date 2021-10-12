using System;
using System.Collections.Generic;
using System.Text;

namespace KdsOnline.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
