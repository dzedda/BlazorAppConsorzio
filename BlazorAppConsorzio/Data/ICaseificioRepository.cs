using BlazorAppConsorzio.Models;

namespace BlazorAppConsorzio.Data
{
    public interface ICaseicificioRepository
    {
        Caseificio GetCaseificio(int id);
        List<Foto> GetFotos(int id);  
    }
}
