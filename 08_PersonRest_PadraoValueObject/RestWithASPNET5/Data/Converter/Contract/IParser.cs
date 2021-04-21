using System.Collections.Generic;


namespace RestWithASPNET5.Data.Converter.Contract
{
    public interface IParser<Origem, Destino>
    {
        Origem Parser(Destino destino);
        List<Destino> Parser(List<Origem> destino);
    }
}
