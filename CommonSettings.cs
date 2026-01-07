using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekatv2.Services;
namespace Projekatv2
{
    public class CommonSettings
    {
        public readonly static IService Service = new Service();
    }
}
