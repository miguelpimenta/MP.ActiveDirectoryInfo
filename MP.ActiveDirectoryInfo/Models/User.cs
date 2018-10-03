using MP.Support;
using System;
using System.Collections.Generic;

namespace MP.ActiveDirectoryInfo.Models
{
    public class User : BindableBase
    {
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string SamAccountName { get; set; } = string.Empty;
        public string UserPrincipalName { get; set; } = string.Empty;
        public string GivenName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid? Guid { get; set; } = null;
        public string EmailAddress { get; set; } = string.Empty;
        public string VoiceTelephoneNumber { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        public string AdvancedSearchFilter { get; set; } = string.Empty;
        public bool? Enabled { get; set; }
        public string AccountLockoutTime { get; set; } = string.Empty;
        public DateTime? LastLogon { get; set; } = null;
        public List<string> PermittedWorkstations { get; set; } = null;
        public string PermittedLogonTimes { get; set; } = string.Empty;
        public DateTime? AccountExpirationDate { get; set; } = null;
        public bool SmartCardLogonRequired { get; set; }
        public bool DelegationPermited { get; set; }
        public int BadLogonCount { get; set; }
        public string HomeDirectory { get; set; } = string.Empty;
        public string HomeDrive { get; set; } = string.Empty;
        public string ScriptPath { get; set; } = string.Empty;
        public DateTime? LastPasswordSet { get; set; } = null;
        public DateTime? LastBadPasswordAttemp { get; set; } = null;
        public bool PasswordNotRequired { get; set; }
        public bool PasswordNeverExpires { get; set; }
        public bool UserCannotChangePassword { get; set; }
        public bool AllowReversiblePasswordEncryption { get; set; }
        public List<string> Certificates { get; set; } = null;
        public string Sid { get; set; } = string.Empty;
        public string DistinguishedName { get; set; } = string.Empty;
        public string StructuralObjectClass { get; set; } = string.Empty;
    }
}