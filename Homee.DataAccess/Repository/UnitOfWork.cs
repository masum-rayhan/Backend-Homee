using Homee.DataAccess.Data;
using Homee.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homee.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _db;
    public UnitOfWork(AppDbContext db)
    {
        _db = db;
    }

    public IDeviceRepo Devices => new DeviceRepo(_db);

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
