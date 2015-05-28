using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungry.Model.Commom
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
