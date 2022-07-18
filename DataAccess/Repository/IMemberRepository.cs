using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IMemberRepository
    {
        Member? CheckLogin(string email, string password);
        public bool CheckLoginFromAccountInFile(string email, string password);
        Member GetMemberByEmail(string email);
        Boolean UpdateMember(Member member);
        IEnumerable<Member> GetAllMember();
        Boolean DeleteMember(Member member);
        Boolean AddMember(Member member);
        Member GetMemberByID(int? memberId);
    }
}
