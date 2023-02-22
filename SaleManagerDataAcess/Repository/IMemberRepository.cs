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
        bool CreateMember(Member model);
        bool UpdateMember(Member model);
        List<Member> GetAllMembers();
        Member GetById(int id);
        bool UserLogged(UserDto model);
        bool IsEmailExist(string email, int id);
        Member FindByEmail(string email);
        bool DeleteUser(int id);
    }
}
