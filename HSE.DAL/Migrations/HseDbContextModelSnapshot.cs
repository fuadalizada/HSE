﻿// <auto-generated />
using System;
using HSE.DAL.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HSE.DAL.Migrations
{
    [DbContext(typeof(HseDbContext))]
    partial class HseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HSE.Domain.Entities.AccessDeniedLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrowserInfo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BROWSER_INFO");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("Datetime")
                        .HasColumnName("CREATE_DATE");

                    b.Property<string>("RefererUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("REFERER_URL");

                    b.Property<string>("RemoteIpAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("REMOTE_IP_ADDRESS");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.ToTable("TBL_ACCESS_DENIED_LOG");
                });

            modelBuilder.Entity("HSE.Domain.Entities.Employee", b =>
                {
                    b.Property<int?>("ChildOrgIndMgrPosPerId")
                        .HasColumnType("int")
                        .HasColumnName("CHILD_ORG_IND_MGR_POS_PER_ID");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATE_DATE");

                    b.Property<string>("CurrentEmployeeFlag")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("CURRENT_EMPLOYEE_FLAG");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(240)")
                        .HasColumnName("EMAIL_ADDRESS");

                    b.Property<int?>("EnterpriseManagerPersonId")
                        .HasColumnType("int")
                        .HasColumnName("ENTERPRISE_MANAGER_PERSON_ID");

                    b.Property<int?>("EnterpriseManagerPositionId")
                        .HasColumnType("int")
                        .HasColumnName("ENTERPRISE_MANAGER_POSITION_ID");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FULL_NAME");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("GENDER");

                    b.Property<string>("JobCategoryCode")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("JOB_CATEGORY_CODE");

                    b.Property<string>("JobCategoryName")
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("JOB_CATEGORY_NAME");

                    b.Property<int?>("JobId")
                        .HasColumnType("int")
                        .HasColumnName("JOB_ID");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(240)")
                        .HasColumnName("JOB_NAME");

                    b.Property<string>("JobSubcategoryCode")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("JOB_SUBCATEGORY_CODE");

                    b.Property<string>("JobSubcategoryName")
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("JOB_SUBCATEGORY_NAME");

                    b.Property<int?>("L3ParentOrganizationId")
                        .HasColumnType("int")
                        .HasColumnName("L3_PARENT_ORGANIZATION_ID");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(240)")
                        .HasColumnName("LAST_NAME");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("MOBILE_PHONE_NUMBER");

                    b.Property<string>("NationalIdentifier")
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("NATIONAL_IDENTIFIER");

                    b.Property<int?>("OrgCuratorPersonId")
                        .HasColumnType("int")
                        .HasColumnName("ORG_CURATOR_PERSON_ID");

                    b.Property<int?>("OrgStrDeductedMgrPersonId")
                        .HasColumnType("int")
                        .HasColumnName("ORG_STR_DEDUCTED_MGR_PERSON_ID");

                    b.Property<string>("OrganizationFullname")
                        .HasColumnType("nvarchar(240)")
                        .HasColumnName("ORGANIZATION_FULL_NAME");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int")
                        .HasColumnName("ORGANIZATION_ID");

                    b.Property<string>("OrganizationShortName")
                        .HasColumnType("nvarchar(240)")
                        .HasColumnName("ORGANIZATION_SHORT_NAME");

                    b.Property<int?>("ParentOrgIndMgrPosPerId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_ORG_IND_MGR_POS_PER_ID");

                    b.Property<int?>("ParentOrgIndMgrPositionId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_ORG_IND_MGR_POSITION_ID");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("PATRONYMIC");

                    b.Property<int>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("PERSON_ID");

                    b.Property<string>("PersonIsCuratorFlag")
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("PERSON_IS_CURATOR_FLAG");

                    b.Property<string>("PersonIsEnterpriseMgrFlag")
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("PERSON_IS_ENTERPRISE_MGR_FLAG");

                    b.Property<byte[]>("PhotoBinary")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PHOTO_BINARY");

                    b.Property<string>("PosOrgMgrPositionFlag")
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("POS_ORG_MGR_POSITION_FLAG");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int")
                        .HasColumnName("POSITION_ID");

                    b.Property<string>("WorkPhone")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("WORK_PHONE_NUMBER");

                    b.ToTable("TBL_EMPLOYEE");
                });

            modelBuilder.Entity("HSE.Domain.Entities.EmployeeForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeFullName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMPLOYEE_FULL_NAME");

                    b.Property<string>("EmployeePosition")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMPLOYEE_POSITION");

                    b.Property<int>("EmployeeUserId")
                        .HasColumnType("int")
                        .HasColumnName("EMPLOYEE_USER_ID");

                    b.Property<int>("InstructionFormId")
                        .HasColumnType("int")
                        .HasColumnName("INSTRUCTION_FORM_ID");

                    b.Property<string>("InstructorComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("INSTRUCTOR_COMMENT");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_ACTIVE")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("PhotoTakingDate")
                        .HasColumnType("datetime")
                        .HasColumnName("PHOTO_TAKING_DATE");

                    b.HasKey("Id");

                    b.HasIndex("InstructionFormId");

                    b.ToTable("TBL_EMPLOYEE_FORM");
                });

            modelBuilder.Entity("HSE.Domain.Entities.ErrorLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ACTION_NAME");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATE_DATE");

                    b.Property<int>("ErrorLineNumber")
                        .HasColumnType("int")
                        .HasColumnName("ERROR_LINE_NUMBER");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ERROR_MESSAGE");

                    b.Property<int?>("InstructionFormId")
                        .HasColumnType("int")
                        .HasColumnName("INSTRUCTION_FORM_ID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.ToTable("TBL_ERROR_LOG");
                });

            modelBuilder.Entity("HSE.Domain.Entities.FormShortContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("IS_ACTIVE");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NAME");

                    b.HasKey("Id");

                    b.ToTable("TBL_FORM_SHORT_CONTENT");
                });

            modelBuilder.Entity("HSE.Domain.Entities.InstructionForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InstructionDate")
                        .HasColumnType("datetime")
                        .HasColumnName("INSTRUCTION_DATE");

                    b.Property<string>("InstructionShortContent")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("INSTRUCTOR_SHORT_CONTENT");

                    b.Property<int>("InstructionTypeId")
                        .HasColumnType("int")
                        .HasColumnName("INSTRUCTION_TYPE_ID");

                    b.Property<string>("InstructionTypeName")
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("INSTRUCTION_TYPE_NAME");

                    b.Property<string>("InstructorFullName")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("INSTRUCTOR_FULL_NAME");

                    b.Property<string>("InstructorOrganizationFullName")
                        .HasColumnType("nvarchar(240)")
                        .HasColumnName("INSTRUCTOR_ORGANIZATION_FULL_NAME");

                    b.Property<int>("InstructorOrganizationId")
                        .HasColumnType("int")
                        .HasColumnName("INSTRUCTOR_ORGANIZATION_ID");

                    b.Property<string>("InstructorPosition")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("INSTRUCTOR_POSITION");

                    b.Property<int>("InstructorUserId")
                        .HasColumnType("int")
                        .HasColumnName("INSTRUCTOR_USER_ID");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_ACTIVE")
                        .HasDefaultValueSql("1");

                    b.HasKey("Id");

                    b.ToTable("TBL_INSTRUCTION_FORM");
                });

            modelBuilder.Entity("HSE.Domain.Entities.InstructionType", b =>
                {
                    b.Property<DateTime?>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasColumnName("CREATE_DATE")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("IS_ACTIVE");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.ToTable("TBL_INSTRUCTION_TYPE");
                });

            modelBuilder.Entity("HSE.Domain.Entities.LoginLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrowserInfo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BROWSER_INFO");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("CREATE_DATE");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("RemoteIpAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("REMOTE_IP_ADDRESS");

                    b.Property<bool>("Success")
                        .HasColumnType("bit")
                        .HasColumnName("SUCCESS");

                    b.HasKey("Id");

                    b.ToTable("TBL_LOGIN_LOG");
                });

            modelBuilder.Entity("HSE.Domain.Entities.OrganizationBasePermitionMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CREATE_DATE")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("IS_ACTIVE");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int")
                        .HasColumnName("ORGANIZATION_ID");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ORGANIZATION_NAME");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ROLE");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("ROLE_ID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.ToTable("TBL_ORGANIZATION_BASE_PERMITION_MAP");
                });

            modelBuilder.Entity("HSE.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("IS_ACTIVE");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ROLE_NAME");

                    b.HasKey("Id");

                    b.ToTable("TBL_ROLE");
                });

            modelBuilder.Entity("HSE.Domain.Entities.Structure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChildIndFirstIncPersonId")
                        .HasColumnType("int")
                        .HasColumnName("CHILD_IND_FIRST_INC_PERSON_ID");

                    b.Property<int?>("ChildIndOrgMgrPosLevel")
                        .HasColumnType("int")
                        .HasColumnName("CHILD_IND_ORG_MGR_POS_LEVEL");

                    b.Property<int?>("ChildIndOrgMgrPosOrgId")
                        .HasColumnType("int")
                        .HasColumnName("CHILD_IND_ORG_MGR_POS_ORG_ID");

                    b.Property<int?>("ChildIndOrgMgrPositionId")
                        .HasColumnType("int")
                        .HasColumnName("CHILD_IND_ORG_MGR_POSITION_ID");

                    b.Property<int?>("ChildL3ParentOrgId")
                        .HasColumnType("int")
                        .HasColumnName("CHILD_L3_PARENT_ORG_ID");

                    b.Property<string>("ChildOrgIsEmployerFlag")
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("CHILD_ORG_IS_EMPLOYER_FLAG");

                    b.Property<int?>("ChildOrgMgrPositionId")
                        .HasColumnType("int")
                        .HasColumnName("CHILD_ORG_MGR_POSITION_ID");

                    b.Property<string>("ChildOrganizationFullname")
                        .HasColumnType("nvarchar(240)")
                        .HasColumnName("CHILD_ORGANIZATION_FULL_NAME");

                    b.Property<int?>("ChildOrganizationId")
                        .HasColumnType("int")
                        .HasColumnName("CHILD_ORGANIZATION_ID");

                    b.Property<string>("ChildOrganizationShortName")
                        .HasColumnType("nvarchar(240)")
                        .HasColumnName("CHILD_ORGANIZATION_SHORT_NAME");

                    b.Property<int?>("LevelDifference")
                        .HasColumnType("int")
                        .HasColumnName("LEVEL_DIFFERENCE");

                    b.Property<int?>("ParentIndFirstIncPersonId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_IND_FIRST_INC_PERSON_ID");

                    b.Property<int?>("ParentIndOrgMgrPosLevel")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_IND_ORG_MGR_POS_LEVEL");

                    b.Property<int?>("ParentIndOrgMgrPosOrgId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_IND_ORG_MGR_POS_ORG_ID");

                    b.Property<int?>("ParentIndOrgMgrPositionId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_IND_ORG_MGR_POSITION_ID");

                    b.Property<int?>("ParentL3ParentOrgId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_L3_PARENT_ORG_ID");

                    b.Property<string>("ParentOrgIsEmployerFlag")
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("PARENT_ORG_IS_EMPLOYER_FLAG");

                    b.Property<int?>("ParentOrgMgrPositionId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_ORG_MGR_POSITION_ID");

                    b.Property<string>("ParentOrganizationFullname")
                        .HasColumnType("nvarchar(240)")
                        .HasColumnName("PARENT_ORGANIZATION_FULL_NAME");

                    b.Property<int?>("ParentOrganizationId")
                        .HasColumnType("int")
                        .HasColumnName("PARENT_ORGANIZATION_ID");

                    b.Property<string>("ParentOrganizationShortName")
                        .HasColumnType("nvarchar(240)")
                        .HasColumnName("PARENT_ORGANIZATION_SHORT_NAME");

                    b.HasKey("Id");

                    b.ToTable("TBL_STRUCTURE");
                });

            modelBuilder.Entity("HSE.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("ACTIVE");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CREATE_DATE");

                    b.Property<string>("Fincode")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("NATIONAL_IDENTIFIER");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit")
                        .HasColumnName("GENDER");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LAST_NAME");

                    b.Property<string>("LayoutOptionsJson")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LAYOUT_OPTIONS_JSON");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("JOB_NAME");

                    b.Property<string>("Structure")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ORGANIZATION_FULL_NAME");

                    b.Property<DateTime?>("TourDate")
                        .HasColumnType("datetime")
                        .HasColumnName("TOUR_DATE");

                    b.HasKey("Id");

                    b.ToTable("TBL_USER");
                });

            modelBuilder.Entity("HSE.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("CREATE_DATE")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("IS_ACTIVE");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ROLE");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("ROLE_ID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.ToTable("TBL_USER_ROLE");
                });

            modelBuilder.Entity("HSE.Domain.Entities.EmployeeForm", b =>
                {
                    b.HasOne("HSE.Domain.Entities.InstructionForm", "InstructionForm")
                        .WithMany("EmployeeForms")
                        .HasForeignKey("InstructionFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InstructionForm");
                });

            modelBuilder.Entity("HSE.Domain.Entities.InstructionForm", b =>
                {
                    b.Navigation("EmployeeForms");
                });
#pragma warning restore 612, 618
        }
    }
}
