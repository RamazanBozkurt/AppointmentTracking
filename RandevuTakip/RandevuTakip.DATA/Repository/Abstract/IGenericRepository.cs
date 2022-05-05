using RandevuTakip.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuTakip.DATA.Repository.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
    }
}
