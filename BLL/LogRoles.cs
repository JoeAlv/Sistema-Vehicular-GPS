using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LogRoles
{
    public Role FindRole(int RoleID)
    {
        Roles_CRUD obj = new Roles_CRUD();
        return obj.FindRole(RoleID);
    }

    public List<Role> ListRole()
    {
        Roles_CRUD obj = new Roles_CRUD();
        return obj.GetRoles();
    }
}

