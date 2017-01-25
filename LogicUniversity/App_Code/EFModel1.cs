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

public partial class packageList
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public packageList()
    {
        this.packageListItems = new HashSet<packageListItem>();
        this.transactionLists = new HashSet<transactionList>();
    }

    public string id { get; set; }
    public Nullable<System.DateTime> disbursementDate { get; set; }
    public string issuedBy { get; set; }
    public string status { get; set; }
    public string remark { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<packageListItem> packageListItems { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<transactionList> transactionLists { get; set; }
}

public partial class packageListItem
{
    public int id { get; set; }
    public string packageListId { get; set; }
    public string departmentId { get; set; }
    public string acknowledgedBy { get; set; }
    public string itemId { get; set; }
    public Nullable<int> requestQty { get; set; }
    public Nullable<int> issusedQty { get; set; }
    public Nullable<int> finalQty { get; set; }
    public string remark { get; set; }

    public virtual packageList packageList { get; set; }
    public virtual packageListItem packageListItems1 { get; set; }
    public virtual packageListItem packageListItem1 { get; set; }
    public virtual stationaryCatelogue stationaryCatelogue { get; set; }
    public virtual userDepartmentList userDepartmentList { get; set; }
}

public partial class stationaryCatelogue
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public stationaryCatelogue()
    {
        this.packageListItems = new HashSet<packageListItem>();
        this.stockTakes = new HashSet<stockTake>();
        this.transactionListItems = new HashSet<transactionListItem>();
    }

    public string id { get; set; }
    public string category { get; set; }
    public string description { get; set; }
    public Nullable<int> reorderLevel { get; set; }
    public Nullable<int> currentBalance { get; set; }
    public Nullable<int> reorderQty { get; set; }
    public string unitOfMeasure { get; set; }
    public string binNum { get; set; }
    public string supplier1Id { get; set; }
    public string supplier2Id { get; set; }
    public string supplier3Id { get; set; }
    public Nullable<double> price1 { get; set; }
    public Nullable<double> price2 { get; set; }
    public Nullable<double> price3 { get; set; }
    public string image { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<packageListItem> packageListItems { get; set; }
    public virtual supplierList supplierList { get; set; }
    public virtual supplierList supplierList1 { get; set; }
    public virtual supplierList supplierList2 { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<stockTake> stockTakes { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<transactionListItem> transactionListItems { get; set; }
}

public partial class stockTake
{
    public int id { get; set; }
    public Nullable<System.DateTime> stockTakeDate { get; set; }
    public string conductedBy { get; set; }
    public string itemId { get; set; }

    public virtual stationaryCatelogue stationaryCatelogue { get; set; }
}

public partial class supplierList
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public supplierList()
    {
        this.stationaryCatelogues = new HashSet<stationaryCatelogue>();
        this.stationaryCatelogues1 = new HashSet<stationaryCatelogue>();
        this.stationaryCatelogues2 = new HashSet<stationaryCatelogue>();
    }

    public string id { get; set; }
    public string supplierName { get; set; }
    public string contactName { get; set; }
    public string gstRegisNum { get; set; }
    public string address { get; set; }
    public string postalCode { get; set; }
    public string phone { get; set; }
    public string fax { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<stationaryCatelogue> stationaryCatelogues { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<stationaryCatelogue> stationaryCatelogues1 { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<stationaryCatelogue> stationaryCatelogues2 { get; set; }
}

public partial class sysdiagram
{
    public string name { get; set; }
    public int principal_id { get; set; }
    public int diagram_id { get; set; }
    public Nullable<int> version { get; set; }
    public byte[] definition { get; set; }
}

public partial class transactionList
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public transactionList()
    {
        this.transactionListItems = new HashSet<transactionListItem>();
    }

    public string id { get; set; }
    public string requestBy { get; set; }
    public string responseBy { get; set; }
    public string approveBy { get; set; }
    public Nullable<System.DateTime> requestDate { get; set; }
    public Nullable<System.DateTime> approveDate { get; set; }
    public Nullable<System.DateTime> receivedDate { get; set; }
    public Nullable<System.DateTime> expectedDate { get; set; }
    public string status { get; set; }
    public string remark { get; set; }
    public string type { get; set; }
    public string packageListId { get; set; }

    public virtual packageList packageList { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<transactionListItem> transactionListItems { get; set; }
}

public partial class transactionListItem
{
    public int id { get; set; }
    public string transactionId { get; set; }
    public string itemId { get; set; }
    public Nullable<int> requestQty { get; set; }
    public Nullable<int> finalQty { get; set; }
    public string remark { get; set; }

    public virtual stationaryCatelogue stationaryCatelogue { get; set; }
    public virtual transactionList transactionList { get; set; }
}

public partial class userDepartmentList
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public userDepartmentList()
    {
        this.packageListItems = new HashSet<packageListItem>();
    }

    public string id { get; set; }
    public string deptName { get; set; }
    public string headName { get; set; }
    public string supervisorName { get; set; }
    public string repName { get; set; }
    public string collectionPoint { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<packageListItem> packageListItems { get; set; }
}
