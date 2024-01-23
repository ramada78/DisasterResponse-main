using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Domain.Entities
{

    public class PropertyComparer : ValueComparer<List<DamageCase>>
    {
        public PropertyComparer() : base(
            (l, r) => string.Join(",", l) == string.Join(",", r),
            v => v.GetHashCode(),
            v => new(v))

        {
        }
    }

}
