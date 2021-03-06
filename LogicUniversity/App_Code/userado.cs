﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class aspnet_Applications
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public aspnet_Applications()
    {
        this.aspnet_Membership = new HashSet<aspnet_Membership>();
        this.aspnet_Paths = new HashSet<aspnet_Paths>();
        this.aspnet_Roles = new HashSet<aspnet_Roles>();
        this.aspnet_Users = new HashSet<aspnet_Users>();
    }

    public string ApplicationName { get; set; }
    public string LoweredApplicationName { get; set; }
    public System.Guid ApplicationId { get; set; }
    public string Description { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<aspnet_Membership> aspnet_Membership { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<aspnet_Paths> aspnet_Paths { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<aspnet_Roles> aspnet_Roles { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<aspnet_Users> aspnet_Users { get; set; }
}

public partial class aspnet_Membership
{
    public System.Guid ApplicationId { get; set; }
    public System.Guid UserId { get; set; }
    public string Password { get; set; }
    public int PasswordFormat { get; set; }
    public string PasswordSalt { get; set; }
    public string MobilePIN { get; set; }
    public string Email { get; set; }
    public string LoweredEmail { get; set; }
    public string PasswordQuestion { get; set; }
    public string PasswordAnswer { get; set; }
    public bool IsApproved { get; set; }
    public bool IsLockedOut { get; set; }
    public System.DateTime CreateDate { get; set; }
    public System.DateTime LastLoginDate { get; set; }
    public System.DateTime LastPasswordChangedDate { get; set; }
    public System.DateTime LastLockoutDate { get; set; }
    public int FailedPasswordAttemptCount { get; set; }
    public System.DateTime FailedPasswordAttemptWindowStart { get; set; }
    public int FailedPasswordAnswerAttemptCount { get; set; }
    public System.DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }
    public string Comment { get; set; }

    public virtual aspnet_Applications aspnet_Applications { get; set; }
    public virtual aspnet_Users aspnet_Users { get; set; }
}

public partial class aspnet_Paths
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public aspnet_Paths()
    {
        this.aspnet_PersonalizationPerUser = new HashSet<aspnet_PersonalizationPerUser>();
    }

    public System.Guid ApplicationId { get; set; }
    public System.Guid PathId { get; set; }
    public string Path { get; set; }
    public string LoweredPath { get; set; }

    public virtual aspnet_Applications aspnet_Applications { get; set; }
    public virtual aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
}

public partial class aspnet_PersonalizationAllUsers
{
    public System.Guid PathId { get; set; }
    public byte[] PageSettings { get; set; }
    public System.DateTime LastUpdatedDate { get; set; }

    public virtual aspnet_Paths aspnet_Paths { get; set; }
}

public partial class aspnet_PersonalizationPerUser
{
    public System.Guid Id { get; set; }
    public Nullable<System.Guid> PathId { get; set; }
    public Nullable<System.Guid> UserId { get; set; }
    public byte[] PageSettings { get; set; }
    public System.DateTime LastUpdatedDate { get; set; }

    public virtual aspnet_Paths aspnet_Paths { get; set; }
    public virtual aspnet_Users aspnet_Users { get; set; }
}

public partial class aspnet_Profile
{
    public System.Guid UserId { get; set; }
    public string PropertyNames { get; set; }
    public string PropertyValuesString { get; set; }
    public byte[] PropertyValuesBinary { get; set; }
    public System.DateTime LastUpdatedDate { get; set; }

    public virtual aspnet_Users aspnet_Users { get; set; }
}

public partial class aspnet_Roles
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public aspnet_Roles()
    {
        this.aspnet_Users = new HashSet<aspnet_Users>();
    }

    public System.Guid ApplicationId { get; set; }
    public System.Guid RoleId { get; set; }
    public string RoleName { get; set; }
    public string LoweredRoleName { get; set; }
    public string Description { get; set; }

    public virtual aspnet_Applications aspnet_Applications { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<aspnet_Users> aspnet_Users { get; set; }
}

public partial class aspnet_SchemaVersions
{
    public string Feature { get; set; }
    public string CompatibleSchemaVersion { get; set; }
    public bool IsCurrentVersion { get; set; }
}

public partial class aspnet_Users
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public aspnet_Users()
    {
        this.aspnet_PersonalizationPerUser = new HashSet<aspnet_PersonalizationPerUser>();
        this.aspnet_Roles = new HashSet<aspnet_Roles>();
    }

    public System.Guid ApplicationId { get; set; }
    public System.Guid UserId { get; set; }
    public string UserName { get; set; }
    public string LoweredUserName { get; set; }
    public string MobileAlias { get; set; }
    public bool IsAnonymous { get; set; }
    public System.DateTime LastActivityDate { get; set; }

    public virtual aspnet_Applications aspnet_Applications { get; set; }
    public virtual aspnet_Membership aspnet_Membership { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
    public virtual aspnet_Profile aspnet_Profile { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<aspnet_Roles> aspnet_Roles { get; set; }
}

public partial class aspnet_WebEvent_Events
{
    public string EventId { get; set; }
    public System.DateTime EventTimeUtc { get; set; }
    public System.DateTime EventTime { get; set; }
    public string EventType { get; set; }
    public decimal EventSequence { get; set; }
    public decimal EventOccurrence { get; set; }
    public int EventCode { get; set; }
    public int EventDetailCode { get; set; }
    public string Message { get; set; }
    public string ApplicationPath { get; set; }
    public string ApplicationVirtualPath { get; set; }
    public string MachineName { get; set; }
    public string RequestUrl { get; set; }
    public string ExceptionType { get; set; }
    public string Details { get; set; }
}
