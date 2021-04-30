namespace RestWithASPNET5.Data.VO
{
    public class TokenVO
    {
        public TokenVO(bool authenticated, string created, string expiratton, string acessToken, string refreshToken)
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiratton;
            AcessToken = acessToken;
            RefreshToken = refreshToken;
        }

        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AcessToken{ get; set; }
        public string RefreshToken { get; set; }

    }
}
