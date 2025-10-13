using Curate.Application.Interface.Auth;
using Curate.Domain.Entities.Auth;
using Curate.Infrastructre.Context;
using Microsoft.EntityFrameworkCore;

namespace Curate.Infrastructre.Repository;

public class OtpRepository : IOtpRepository
{
    private readonly AppDbContext _appDbContext;
    public OtpRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<bool> Create(OTP otp)
    {
        var result = await _appDbContext.otps.FindAsync(otp.Id);
        if (result != null) return false;
        await _appDbContext.otps.AddAsync(otp);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _appDbContext.otps.FindAsync(id);
        if (result != null)
        {
            _appDbContext.otps.Remove(result);
            _appDbContext.SaveChanges();
            return true;
        }
        return false;
    }

    public async Task<List<OTP>> GetAll()
    {
        return await _appDbContext.otps.ToListAsync();
    }
    public async Task<OTP?> GetByEmail(string email)
    {
        return await _appDbContext.otps.FirstOrDefaultAsync(x=> x.Email==email); 
    }

    public async Task<bool> Update(OTP otp)
    {
        var result = _appDbContext.otps.Update(otp);
        await _appDbContext.SaveChangesAsync();
        return result != null ? true : false;
    }
}