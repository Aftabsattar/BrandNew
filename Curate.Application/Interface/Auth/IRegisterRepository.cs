namespace Curate.Application.Interface.Auth;

public interface IRegisterRepository
{
    Task<bool> Create();
    Task<bool> Delete();
    Task<bool> GetAll();
    Task<bool> GetById();
    Task<bool> Update();
}