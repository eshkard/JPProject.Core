using JPProject.Admin.Domain.Interfaces;
using JPProject.Admin.Infra.Data.Context;
using System.Threading.Tasks;

namespace JPProject.Admin.Infra.Data.UoW
{
    public class UnitOfWork : IAdimUnitOfWork
    {
        private readonly JPProjectAdminUIContext _adminUiContext;

        public UnitOfWork(JPProjectAdminUIContext adminUiContext)
        {
            _adminUiContext = adminUiContext;
        }

        public async Task<bool> Commit()
        {
            var linesModified = await _adminUiContext.SaveChangesAsync();
            return linesModified > 0;
        }

        public void Dispose()
        {
            _adminUiContext.Dispose();
        }
    }
}
