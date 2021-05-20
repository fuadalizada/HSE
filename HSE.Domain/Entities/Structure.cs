namespace HSE.Domain.Entities
{
    public class Structure:BaseEntity
    {
        public int? ParentOrganizationId { get; set; }
        public string ParentOrganizationFullname { get; set; }
        public string ParentOrganizationShortName { get; set; }
        public char? ParentOrgIsEmployerFlag { get; set; }
        public int? LevelDifference { get; set; }
        public int? ChildOrganizationId { get; set; }
        public string ChildOrganizationFullname { get; set; }
        public string ChildOrganizationShortName { get; set; }
        public char? ChildOrgIsEmployerFlag { get; set; }
        public int? ParentOrgMgrPositionId { get; set; }
        public int? ParentIndOrgMgrPositionId { get; set; }
        public int? ParentIndOrgMgrPosOrgId { get; set; }
        public int? ParentIndOrgMgrPosLevel { get; set; }
        public int? ParentIndFirstIncPersonId { get; set; }
        public int? ParentL3ParentOrgId { get; set; }
        public int? ChildOrgMgrPositionId { get; set; }
        public int? ChildIndOrgMgrPositionId { get; set; }
        public int? ChildIndOrgMgrPosOrgId { get; set; }
        public int? ChildIndOrgMgrPosLevel { get; set; }
        public int? ChildIndFirstIncPersonId { get; set; }
        public int? ChildL3ParentOrgId { get; set; }
    }
}
