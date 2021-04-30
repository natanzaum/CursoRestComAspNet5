using RestWithASPNET5.Data.VO;

namespace RestWithASPNET5.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidaCredenciais(UserVO user);
        TokenVO ValidaCredenciais(TokenVO token);
        bool RevokeToken(string userName);
    }
}
