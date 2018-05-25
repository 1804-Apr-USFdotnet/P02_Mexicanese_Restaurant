using BusinessLogicLayer.models;

namespace BusinessLogicLayer
{
    public interface ILogic
    {
        void Register(LogicIdentityModel account);
        void RegisterAdmin(LogicIdentityModel account);
        void Login(LogicIdentityModel account);
    }
}
