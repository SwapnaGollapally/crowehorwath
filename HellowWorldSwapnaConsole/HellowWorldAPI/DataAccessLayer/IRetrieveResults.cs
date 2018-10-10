/// <summary>
/// interface with definition of retrieveing results.This interface can be used to retrieve results from JSON or database.
/// </summary>
using HellowWorldAPI.Models;
using System.Collections.Generic;
namespace HellowWorldAPI.DataAccessLayer
{
    public interface IRetrieveResults
    {
        List<TextData> LoadTextResults();
    }
}