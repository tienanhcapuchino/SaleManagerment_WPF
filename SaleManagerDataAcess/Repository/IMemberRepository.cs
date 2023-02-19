using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public interface IMemberRepository
    {
        Task<bool> CreateMember(Member model);
        Task<bool> UpdateMember(Member model);
        List<Member> GetAllMembers();
        Member GetById(int id);
    }
}
