using Pe.ByS.ERP.Infraestructura.Core.Base;
using Pe.ByS.ERP.Infraestructura.Core.Context;
using Pe.ByS.ERP.Infraestructura.Model.Base;

namespace Pe.ByS.ERP.Infraestructura.Repository.Base
{
    public class QueryRepository<T> : IQueryRepository<T>
        where T : Logic
    {
        public IDbContextProvider dataBaseProvider { get; set; }

        public void Dispose()
        {
            if (this.dataBaseProvider != null)
            {
                this.dataBaseProvider.Dispose();
            }
        }
    }
}
