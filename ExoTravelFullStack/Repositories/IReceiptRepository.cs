using System.Collections.Generic;
using ExoTravelFullStack.Models;

namespace ExoTravelFullStack.Repositories
{
    public interface IReceiptRepository
    {
        List<Receipt> GetAllReceipts();
        List<Receipt> GetAllReceiptsByUserId(int id);
        Receipt GetReceiptById(int id);
        Receipt GetReceiptByLogId(int id);
        void Add(Receipt receipt);
        void Delete(int id);
    }
}