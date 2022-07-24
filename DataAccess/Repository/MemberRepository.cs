using BusinessObject.Models;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public bool AddMember(Member member) => MemberDAO.Instance.AddMember(member);

        public Member? CheckLogin(string email, string password) => MemberDAO.Instance.CheckLogin(email, password);
        public bool CheckLoginFromAccountInFile(string email, string password) => MemberDAO.Instance.CheckLoginFromAccountInFile(email, password);
        public bool DeleteMember(Member member) => MemberDAO.Instance.DeleteMember(member);

        public IEnumerable<Member> GetAllMember() => MemberDAO.Instance.GetAllMember();

        public Member GetMemberByEmail(string email) => MemberDAO.Instance.GetMemberByEmail(email);

        public Member GetMemberByID(int? memberId) => MemberDAO.Instance.GetMemberByID(memberId);

        public bool UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);
    }
}
