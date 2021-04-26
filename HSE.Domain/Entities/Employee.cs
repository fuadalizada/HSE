using System;

namespace HSE.Domain.Entities
{
    public class Employee
    {
        public int PersonId { get; set; }
        public char CurrentEmployeeFlag { get; set; }
        public string NationalIdentifier { get; set; }
        public string EmailAddress { get; set; }
        public string Fullname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public char Gender { get; set; }
        public int? PositionId { get; set; }
        public int? OrganizationId { get; set; }
        public string OrganizationFullname { get; set; }
        public string OrganizationShortName { get; set; }
        public int? JobId { get; set; }
        public string JobName { get; set; }
        public string MobilePhone { get; set; }
        public string JobCategoryCode { get; set; }
        public string JobCategoryName { get; set; }
        public string JobSubcategoryCode { get; set; }
        public string JobSubcategoryName { get; set; }
        public int? ChildOrgIndMgrPosPerId { get; set; }
        public int? OrgCuratorPersonId { get; set; }
        public int? OrgStrDeductedMgrPersonId { get; set; }
        public int? ParentOrgIndMgrPosPerId { get; set; }
        public int? ParentOrgIndMgrPositionId { get; set; }
        public char? PersonIsCuratorFlag { get; set; }
        public char? PersonIsEnterpriseMgrFlag { get; set; }
        public int? EnterpriseManagerPersonId { get; set; }
        public int? EnterpriseManagerPositionId { get; set; }
        public char? PosOrgMgrPositionFlag { get; set; }
        public int? L3ParentOrganizationId { get; set; }
        public string WorkPhone { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
