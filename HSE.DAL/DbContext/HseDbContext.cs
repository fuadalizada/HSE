using Microsoft.EntityFrameworkCore;
using HSE.Domain.Entities;

namespace HSE.DAL.DbContext
{
    public class HseDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public HseDbContext(DbContextOptions<HseDbContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<AccessDeniedLog> AccessDeniedLogs { get; set; }
        public DbSet<InstructionType> InstructionTypes { get; set; }
        public DbSet<InstructionForm> InstructionForms { get; set; }
        public DbSet<EmployeeForm> EmployeeForms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<OrganizationBasePermitionMap> OrganizationBasePermitionMaps { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<FormShortContent> FormShortContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region User

            modelBuilder.Entity<User>().ToTable("TBL_USER");
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            modelBuilder.Entity<User>()
                .Property(x => x.Fincode)
                .HasColumnName("NATIONAL_IDENTIFIER")
                .HasColumnType("nvarchar(30)")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE")
                .HasColumnType("bit")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Firstname)
                .HasColumnName("FIRST_NAME")
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<User>()
                .Property(x => x.Lastname)
                .HasColumnName("LAST_NAME")
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<User>()
                .Property(x => x.Position)
                .HasColumnName("JOB_NAME")
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<User>()
                .Property(x => x.Structure)
                .HasColumnName("ORGANIZATION_FULL_NAME")
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<User>()
                .Property(x => x.LayoutOptionsJson)
                .HasColumnName("LAYOUT_OPTIONS_JSON")
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<User>()
                .Property(x => x.Gender)
                .HasColumnName("GENDER")
                .HasColumnType("bit");
            
            modelBuilder.Entity<User>()
                .Property(x => x.TourDate)
                .HasColumnName("TOUR_DATE")
                .HasColumnType("datetime");
            
            modelBuilder.Entity<User>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE")
                .HasColumnType("datetime");

            #endregion

            #region Employee

            modelBuilder.Entity<Employee>()
                .ToTable("TBL_EMPLOYEE")
                .HasNoKey();

            modelBuilder.Entity<Employee>()
                .Property(x => x.PersonId)
                .HasColumnName("PERSON_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.CurrentEmployeeFlag)
                .HasColumnName("CURRENT_EMPLOYEE_FLAG")
                .HasColumnType("nvarchar(1)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.NationalIdentifier)
                .HasColumnName("NATIONAL_IDENTIFIER")
                .HasColumnType("nvarchar(30)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.EmailAddress)
                .HasColumnName("EMAIL_ADDRESS")
                .HasColumnType("nvarchar(240)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.Fullname)
                .HasColumnName("FULL_NAME")
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.FirstName)
                .HasColumnName("FIRST_NAME")
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.LastName)
                .HasColumnName("LAST_NAME")
                .HasColumnType("nvarchar(240)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.Patronymic)
                .HasColumnName("PATRONYMIC")
                .HasColumnType("nvarchar(60)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.Gender)
                .HasColumnName("GENDER")
                .HasColumnType("nvarchar(1)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.PositionId)
                .HasColumnName("POSITION_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.OrganizationId)
                .HasColumnName("ORGANIZATION_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.OrganizationFullname)
                .HasColumnName("ORGANIZATION_FULL_NAME")
                .HasColumnType("nvarchar(240)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.OrganizationShortName)
                .HasColumnName("ORGANIZATION_SHORT_NAME")
                .HasColumnType("nvarchar(240)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.JobId)
                .HasColumnName("JOB_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.JobName)
                .HasColumnName("JOB_NAME")
                .HasColumnType("nvarchar(240)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.MobilePhone)
                .HasColumnName("MOBILE_PHONE_NUMBER")
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.WorkPhone)
                .HasColumnName("WORK_PHONE_NUMBER")
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.JobCategoryCode)
                .HasColumnName("JOB_CATEGORY_CODE")
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.JobCategoryName)
                .HasColumnName("JOB_CATEGORY_NAME")
                .HasColumnType("nvarchar(80)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.JobSubcategoryCode)
                .HasColumnName("JOB_SUBCATEGORY_CODE")
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.JobSubcategoryName)
                .HasColumnName("JOB_SUBCATEGORY_NAME")
                .HasColumnType("nvarchar(80)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.EnterpriseManagerPersonId)
                .HasColumnName("ENTERPRISE_MANAGER_PERSON_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.EnterpriseManagerPositionId)
                .HasColumnName("ENTERPRISE_MANAGER_POSITION_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.PosOrgMgrPositionFlag)
                .HasColumnName("POS_ORG_MGR_POSITION_FLAG")
                .HasColumnType("nvarchar(1)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.ParentOrgIndMgrPositionId)
                .HasColumnName("PARENT_ORG_IND_MGR_POSITION_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.OrgCuratorPersonId)
                .HasColumnName("ORG_CURATOR_PERSON_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.ParentOrgIndMgrPosPerId)
                .HasColumnName("PARENT_ORG_IND_MGR_POS_PER_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.ChildOrgIndMgrPosPerId)
                .HasColumnName("CHILD_ORG_IND_MGR_POS_PER_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.PersonIsEnterpriseMgrFlag)
                .HasColumnName("PERSON_IS_ENTERPRISE_MGR_FLAG")
                .HasColumnType("nvarchar(1)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.PersonIsCuratorFlag)
                .HasColumnName("PERSON_IS_CURATOR_FLAG")
                .HasColumnType("nvarchar(1)");

            modelBuilder.Entity<Employee>()
                .Property(x => x.OrgStrDeductedMgrPersonId)
                .HasColumnName("ORG_STR_DEDUCTED_MGR_PERSON_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.L3ParentOrganizationId)
                .HasColumnName("L3_PARENT_ORGANIZATION_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Employee>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE")
                .HasColumnType("datetime");
            
            modelBuilder.Entity<Employee>()
                .Property(x => x.PhotoBinary)
                .HasColumnName("PHOTO_BINARY")
                .HasColumnType("varbinary(max)");
            #endregion

            #region LoginLog

            modelBuilder.Entity<LoginLog>().ToTable("TBL_LOGIN_LOG");

            modelBuilder.Entity<LoginLog>().HasKey(x => x.Id);

            modelBuilder.Entity<LoginLog>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            modelBuilder.Entity<LoginLog>()
                .Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<LoginLog>()
                .Property(x => x.RemoteIpAddress)
                .HasColumnName("REMOTE_IP_ADDRESS")
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<LoginLog>()
                .Property(x => x.BrowserInfo)
                .HasColumnName("BROWSER_INFO")
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<LoginLog>()
                .Property(x => x.Success)
                .HasColumnName("SUCCESS")
                .HasColumnType("bit");

            modelBuilder.Entity<LoginLog>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE")
                .HasColumnType("DateTime");

            #endregion

            #region AccessDeniedLog

            modelBuilder.Entity<AccessDeniedLog>().ToTable("TBL_ACCESS_DENIED_LOG");

            modelBuilder.Entity<AccessDeniedLog>().HasKey(x => x.Id);

            modelBuilder.Entity<AccessDeniedLog>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            modelBuilder.Entity<AccessDeniedLog>()
                .Property(x => x.UserId)
                .HasColumnName("USER_ID")
                .HasColumnType("int");

            modelBuilder.Entity<AccessDeniedLog>()
                .Property(x => x.RemoteIpAddress)
                .HasColumnName("REMOTE_IP_ADDRESS")
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<AccessDeniedLog>()
                .Property(x => x.BrowserInfo)
                .HasColumnName("BROWSER_INFO")
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<AccessDeniedLog>()
                .Property(x => x.RefererUrl)
                .HasColumnName("REFERER_URL")
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<AccessDeniedLog>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE")
                .HasColumnType("Datetime");

            #endregion

            #region InstructionType

            modelBuilder.Entity<InstructionType>().ToTable("TBL_INSTRUCTION_TYPE");
            modelBuilder.Entity<InstructionType>().HasNoKey();
            modelBuilder.Entity<InstructionType>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<InstructionType>()
                .Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("NAME");

            modelBuilder.Entity<InstructionType>()
                .Property(x => x.IsActive)
                .HasColumnType("bit")
                .HasColumnName("IS_ACTIVE")
                .HasDefaultValue(true);

            modelBuilder.Entity<InstructionType>()
                .Property(x => x.CreateDate)
                .HasColumnType("DateTime")
                .HasColumnName("CREATE_DATE")
                .HasDefaultValueSql("GetDate()");

            #endregion

            #region InstructionForm

            modelBuilder.Entity<InstructionForm>().ToTable("TBL_INSTRUCTION_FORM");
            modelBuilder.Entity<InstructionForm>().HasKey(x => x.Id);
            modelBuilder.Entity<InstructionForm>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<InstructionForm>()
                .Property(x => x.InstructorUserId)
                .HasColumnName("INSTRUCTOR_USER_ID");

            modelBuilder.Entity<InstructionForm>()
                .Property(x => x.InstructorOrganizationId)
                .HasColumnName("INSTRUCTOR_ORGANIZATION_ID");
            
            modelBuilder.Entity<InstructionForm>()
                .Property(x => x.InstructorOrganizationFullName)
                .HasColumnType("nvarchar(240)")
                .HasColumnName("INSTRUCTOR_ORGANIZATION_FULL_NAME");

            modelBuilder.Entity<InstructionForm>()
                .Property(x => x.InstructorFullName)
                .HasColumnName("INSTRUCTOR_FULL_NAME")
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<InstructionForm>()
                .Property(x => x.InstructorPosition)
                .HasColumnName("INSTRUCTOR_POSITION")
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<InstructionForm>()
                .Property(x => x.InstructionShortContent)
                .HasColumnName("INSTRUCTOR_SHORT_CONTENT")
                .HasColumnType("nvarchar(max)");
            
            modelBuilder.Entity<InstructionForm>()
                .Property(x => x.InstructionTypeId)
                .HasColumnName("INSTRUCTION_TYPE_ID")
                .HasColumnType("int");
            
            modelBuilder.Entity<InstructionForm>()
                .Property(x => x.InstructionDate)
                .HasColumnName("INSTRUCTION_DATE")
                .HasColumnType("datetime");
            
            modelBuilder.Entity<InstructionForm>()
                .Property(x => x.InstructionTypeName)
                .HasColumnName("INSTRUCTION_TYPE_NAME")
                .HasColumnType("nvarchar(150)");

            modelBuilder.Entity<InstructionForm>()
                .Property(x => x.IsActive)
                .HasColumnName("IS_ACTIVE")
                .HasColumnType("bit")
                .HasDefaultValueSql("1")
                .IsRequired();

            #endregion

            #region EmployeeForm
            modelBuilder.Entity<EmployeeForm>().ToTable("TBL_EMPLOYEE_FORM");
            modelBuilder.Entity<EmployeeForm>().HasKey(x => x.Id);
            modelBuilder.Entity<EmployeeForm>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            modelBuilder.Entity<EmployeeForm>()
                .Property(x => x.EmployeeUserId)
                .HasColumnName("EMPLOYEE_USER_ID")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<EmployeeForm>()
                .Property(x => x.InstructionFormId)
                .HasColumnName("INSTRUCTION_FORM_ID")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<EmployeeForm>()
                .Property(x => x.InstructorComment)
                .HasColumnName("INSTRUCTOR_COMMENT")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            modelBuilder.Entity<EmployeeForm>()
                .Property(x => x.EmployeeFullName)
                .HasColumnName("EMPLOYEE_FULL_NAME")
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<EmployeeForm>()
                .Property(x => x.EmployeePosition)
                .HasColumnName("EMPLOYEE_POSITION")
                .HasColumnType("nvarchar(max)");


            modelBuilder.Entity<EmployeeForm>()
                .HasOne(x => x.InstructionForm)
                .WithMany(x => x.EmployeeForms)
                .HasForeignKey(x => x.InstructionFormId);

            modelBuilder.Entity<EmployeeForm>()
                .Property(x => x.IsActive)
                .HasColumnName("IS_ACTIVE")
                .HasColumnType("bit")
                .HasDefaultValueSql("1")
                .IsRequired();
            
            modelBuilder.Entity<EmployeeForm>()
                .Property(x => x.PhotoTakingDate)
                .HasColumnName("PHOTO_TAKING_DATE")
                .HasColumnType("datetime");

            #endregion

            #region Role

            modelBuilder.Entity<Role>().ToTable("TBL_ROLE");
            modelBuilder.Entity<Role>().HasKey(x => x.Id);
            modelBuilder.Entity<Role>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            
            modelBuilder.Entity<Role>()
                .Property(x => x.RoleName)
                .HasColumnType("nvarchar(250)")
                .HasColumnName("ROLE_NAME");
            
            modelBuilder.Entity<Role>()
                .Property(x => x.Description)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("DESCRIPTION");
            
            modelBuilder.Entity<Role>()
                .Property(x => x.IsActive)
                .HasColumnType("bit")
                .HasDefaultValue(true)
                .HasColumnName("IS_ACTIVE");

            #endregion

            #region UserRole

            modelBuilder.Entity<UserRole>().ToTable("TBL_USER_ROLE");
            modelBuilder.Entity<UserRole>().HasKey(x => x.Id);
            modelBuilder.Entity<UserRole>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            modelBuilder.Entity<UserRole>()
                .Property(x => x.UserId)
                .HasColumnType("int")
                .IsRequired()
                .HasColumnName("USER_ID");
            
            modelBuilder.Entity<UserRole>()
                .Property(x => x.RoleId)
                .HasColumnType("int")
                .IsRequired()
                .HasColumnName("ROLE_ID");
            
            modelBuilder.Entity<UserRole>()
                .Property(x => x.Role)
                .HasColumnType("nvarchar(100)")
                .IsRequired()
                .HasColumnName("ROLE");
            
            modelBuilder.Entity<UserRole>()
                .Property(x => x.IsActive)
                .HasColumnType("bit")
                .HasDefaultValue(true)
                .HasColumnName("IS_ACTIVE");
            
            modelBuilder.Entity<UserRole>()
                .Property(x => x.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GetDate()")
                .HasColumnName("CREATE_DATE");


            #endregion

            #region OrganizationBasePermitionMap

            modelBuilder.Entity<OrganizationBasePermitionMap>().ToTable("TBL_ORGANIZATION_BASE_PERMITION_MAP");
            modelBuilder.Entity<OrganizationBasePermitionMap>().HasKey(x => x.Id);
            modelBuilder.Entity<OrganizationBasePermitionMap>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            modelBuilder.Entity<OrganizationBasePermitionMap>()
                .Property(x => x.UserId)
                .HasColumnType("int")
                .IsRequired()
                .HasColumnName("USER_ID");

            modelBuilder.Entity<OrganizationBasePermitionMap>()
                .Property(x => x.RoleId)
                .HasColumnType("int")
                .IsRequired()
                .HasColumnName("ROLE_ID");

            modelBuilder.Entity<OrganizationBasePermitionMap>()
                .Property(x => x.Role)
                .HasColumnType("nvarchar(100)")
                .IsRequired()
                .HasColumnName("ROLE");

            modelBuilder.Entity<OrganizationBasePermitionMap>()
                .Property(x => x.OrganizationId)
                .HasColumnType("int")
                .IsRequired()
                .HasColumnName("ORGANIZATION_ID");

            modelBuilder.Entity<OrganizationBasePermitionMap>()
                .Property(x => x.OrganizationName)
                .HasColumnType("nvarchar(100)")
                .IsRequired()
                .HasColumnName("ORGANIZATION_NAME");

            modelBuilder.Entity<OrganizationBasePermitionMap>()
                .Property(x => x.IsActive)
                .HasColumnType("bit")
                .HasDefaultValue(true)
                .HasColumnName("IS_ACTIVE");

            modelBuilder.Entity<OrganizationBasePermitionMap>()
                .Property(x => x.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GetDate()")
                .HasColumnName("CREATE_DATE");

            #endregion

            #region Structure

            modelBuilder.Entity<Structure>()
                .ToTable("TBL_STRUCTURE");
            modelBuilder.Entity<Structure>().HasKey(x => x.Id);

            modelBuilder.Entity<Structure>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ParentOrganizationId)
                .HasColumnName("PARENT_ORGANIZATION_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ParentOrganizationFullname)
                .HasColumnName("PARENT_ORGANIZATION_FULL_NAME")
                .HasColumnType("nvarchar(240)");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ParentOrganizationShortName)
                .HasColumnName("PARENT_ORGANIZATION_SHORT_NAME")
                .HasColumnType("nvarchar(240)");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ParentOrgIsEmployerFlag)
                .HasColumnName("PARENT_ORG_IS_EMPLOYER_FLAG")
                .HasColumnType("nvarchar(1)");

            modelBuilder.Entity<Structure>()
                .Property(x => x.LevelDifference)
                .HasColumnName("LEVEL_DIFFERENCE")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ChildOrganizationId)
                .HasColumnName("CHILD_ORGANIZATION_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ChildOrganizationFullname)
                .HasColumnName("CHILD_ORGANIZATION_FULL_NAME")
                .HasColumnType("nvarchar(240)");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ChildOrganizationShortName)
                .HasColumnName("CHILD_ORGANIZATION_SHORT_NAME")
                .HasColumnType("nvarchar(240)");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ChildOrgIsEmployerFlag)
                .HasColumnName("CHILD_ORG_IS_EMPLOYER_FLAG")
                .HasColumnType("nvarchar(1)");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ParentOrgMgrPositionId)
                .HasColumnName("PARENT_ORG_MGR_POSITION_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ParentIndOrgMgrPositionId)
                .HasColumnName("PARENT_IND_ORG_MGR_POSITION_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ParentIndOrgMgrPosOrgId)
                .HasColumnName("PARENT_IND_ORG_MGR_POS_ORG_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ParentIndOrgMgrPosLevel)
                .HasColumnName("PARENT_IND_ORG_MGR_POS_LEVEL")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ParentIndFirstIncPersonId)
                .HasColumnName("PARENT_IND_FIRST_INC_PERSON_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ParentL3ParentOrgId)
                .HasColumnName("PARENT_L3_PARENT_ORG_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ChildOrgMgrPositionId)
                .HasColumnName("CHILD_ORG_MGR_POSITION_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ChildIndOrgMgrPositionId)
                .HasColumnName("CHILD_IND_ORG_MGR_POSITION_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ChildIndOrgMgrPosOrgId)
                .HasColumnName("CHILD_IND_ORG_MGR_POS_ORG_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ChildIndOrgMgrPosLevel)
                .HasColumnName("CHILD_IND_ORG_MGR_POS_LEVEL")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ChildIndFirstIncPersonId)
                .HasColumnName("CHILD_IND_FIRST_INC_PERSON_ID")
                .HasColumnType("int");

            modelBuilder.Entity<Structure>()
                .Property(x => x.ChildL3ParentOrgId)
                .HasColumnName("CHILD_L3_PARENT_ORG_ID")
                .HasColumnType("int");

            #endregion

            #region ErrorLog

            modelBuilder.Entity<ErrorLog>().ToTable("TBL_ERROR_LOG");
            modelBuilder.Entity<ErrorLog>().HasKey(x => x.Id);
            modelBuilder.Entity<ErrorLog>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            
            modelBuilder.Entity<ErrorLog>()
                .Property(x => x.UserId)
                .HasColumnName("USER_ID")
                .HasColumnType("int");
            
            modelBuilder.Entity<ErrorLog>()
                .Property(x => x.InstructionFormId)
                .HasColumnName("INSTRUCTION_FORM_ID")
                .HasColumnType("int");
            
            modelBuilder.Entity<ErrorLog>()
                .Property(x => x.ErrorMessage)
                .HasColumnName("ERROR_MESSAGE")
                .HasColumnType("nvarchar(max)");
            
            modelBuilder.Entity<ErrorLog>()
                .Property(x => x.ActionName)
                .HasColumnName("ACTION_NAME")
                .HasColumnType("nvarchar(250)");
            
            modelBuilder.Entity<ErrorLog>()
                .Property(x => x.ErrorLineNumber)
                .HasColumnName("ERROR_LINE_NUMBER")
                .HasColumnType("int");
            
            modelBuilder.Entity<ErrorLog>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE")
                .HasColumnType("datetime");

            #endregion

            #region FormShortContent

            modelBuilder.Entity<FormShortContent>().ToTable("TBL_FORM_SHORT_CONTENT");
            modelBuilder.Entity<FormShortContent>().HasKey(x => x.Id);
            modelBuilder.Entity<FormShortContent>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            modelBuilder.Entity<FormShortContent>()
                .Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(max)");
            
            modelBuilder.Entity<FormShortContent>()
                .Property(x => x.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("nvarchar(max)");
            
            modelBuilder.Entity<FormShortContent>()
                .Property(x => x.IsActive)
                .HasColumnName("IS_ACTIVE")
                .HasDefaultValue(true)
                .HasColumnType("bit");

            #endregion
        }
    }
}
