using BusinessObject.Models;
using Nancy.Json;
//DAO
namespace DataAccess
{
    public class MemberDAO : BaseDAO<Member>, IMemberRepository
    {
        private static readonly object instanceLock = new object();
        public static MemberDAO instance = null;
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                }
                return instance;
            }
        }
        private Dictionary<string, string> GetDefaultAdmin()
        {
            Dictionary<string, string> defaultAdmin = new Dictionary<string, string>();
            string json = string.Empty;
            using (StreamReader reader = new StreamReader("appsettings.json"))
            {
                json = reader.ReadToEnd();
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var obj = jss.Deserialize<dynamic>(json);
            string email = obj["DefaultAccount"]["Email"];
            string password = obj["DefaultAccount"]["password"];
            defaultAdmin.Add("email", email);
            defaultAdmin.Add("password", password);
            return defaultAdmin;
        }

        public bool AddMember(Member member) => base.SaveEntity(member);

        public Member? CheckLogin(string email, string password)
        {
            using (var db = new SaleManagementDBContext())
            {
                try
                {
                    return db.Set<Member>()
                        .Where(b => b.Email.Equals(email.Trim()) && b.Password.Equals(password.Trim()))
                        .FirstOrDefault();
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        public bool CheckLoginFromAccountInFile(string email, string password)
        {
            Dictionary<string, string> defaultAdmin = GetDefaultAdmin();
            string emailAdmin = "";
            string passwordAdmin = "";
            defaultAdmin.TryGetValue("email", out emailAdmin);
            defaultAdmin.TryGetValue("password", out passwordAdmin);
            return (email.Equals(emailAdmin) && (password.Equals(passwordAdmin)));
        }

        public bool DeleteMember(Member member) => base.DeleteEntity(member);

        public Member? GetMemberByEmail(string email)
        {
            using (var db = new SaleManagementDBContext())
            {
                try
                {
                    email = email.Trim();
                    return db.Set<Member>()
                        .Where(b => b.Email.Equals(email))
                        .FirstOrDefault();
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        public Member GetMemberByID(int? memberId) => base.GetEntityById(memberId);

        public IEnumerable<Member>? GetAllMember() => base.GetAllEntity();

        public bool UpdateMember(Member member) => base.UpdateEntity(entity: member);
    }
}
