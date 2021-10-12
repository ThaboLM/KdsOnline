using System;
using System.Collections.Generic;
using System.Text;

namespace KdsOnline.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
