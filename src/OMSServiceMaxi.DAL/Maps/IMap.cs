using Microsoft.EntityFrameworkCore;

namespace OMSServiceMaxi.Data.Access.Maps
{
    public interface IMap
    {
        void Visit(ModelBuilder builder);
    }
}