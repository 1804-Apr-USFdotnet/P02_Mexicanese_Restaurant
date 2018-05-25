using BusinessLogicLayer.models;

namespace BusinessLogicLayer
{
    public interface ILogic
    {
        void Register(LogicIdentityModel account);
        void Login(LogicIdentityModel account);
    }
}
