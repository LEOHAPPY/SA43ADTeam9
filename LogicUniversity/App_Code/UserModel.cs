using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserModel
/// </summary>
public class UserModel
{
    private string id;
    private string name;
    private string email;
    private string departmentId;
    private string role;
    private string image;

    public string Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public string DepartmentId
    {
        get
        {
            return departmentId;
        }

        set
        {
            departmentId = value;
        }
    }

    public string Role
    {
        get
        {
            return role;
        }

        set
        {
            role = value;
        }
    }

    public string Image
    {
        get
        {
            return image;
        }

        set
        {
            image = value;
        }
    }

    public UserModel()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}