using System.Transactions;
using HexArch.Csv.Domain.Entities;

namespace HexArch.Csv.Domain.Interfaces.Repositories;

public interface IPeopleRepository
{
    Person Add(Person person);
    TransactionScope BeginTransaction();
}