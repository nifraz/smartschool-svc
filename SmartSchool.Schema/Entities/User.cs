using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Schema.Entities
{
    public class User : AbstractRecord
    {
        public string Password { get; set; }
        public bool IsMobileNoVerified { get; set; }
        public bool IsEmailVerified { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? TokenExpiration { get; set; }

        //one
        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }
        public Person Person { get; set; }

        //many

        //audit

        [InverseProperty(nameof(User.CreatedUser))]
        public ICollection<User> CreatedUsers { get; set; } = [];
        [InverseProperty(nameof(User.LastModifiedUser))]
        public ICollection<User> LastModifiedUsers { get; set; } = [];
        [InverseProperty(nameof(User.DeletedUser))]
        public ICollection<User> DeletedUsers { get; set; } = [];

        //[InverseProperty(nameof(AcademicYear.CreatedUser))]
        //public ICollection<AcademicYear> CreatedAcademicYears { get; set; } = [];
        //[InverseProperty(nameof(AcademicYear.LastModifiedUser))]
        //public ICollection<AcademicYear> LastModifiedAcademicYears { get; set; } = [];
        //[InverseProperty(nameof(AcademicYear.DeletedUser))]
        //public ICollection<AcademicYear> DeletedAcademicYears { get; set; } = [];

        [InverseProperty(nameof(Class.CreatedUser))]
        public ICollection<Class> CreatedClasses { get; set; } = [];
        [InverseProperty(nameof(Class.LastModifiedUser))]
        public ICollection<Class> LastModifiedClasses { get; set; } = [];
        [InverseProperty(nameof(Class.DeletedUser))]
        public ICollection<Class> DeletedClasses { get; set; } = [];

        [InverseProperty(nameof(Person.CreatedUser))]
        public ICollection<Person> CreatedPersons { get; set; } = [];
        [InverseProperty(nameof(Person.LastModifiedUser))]
        public ICollection<Person> LastModifiedPersons { get; set; } = [];
        [InverseProperty(nameof(Person.DeletedUser))]
        public ICollection<Person> DeletedPersons { get; set; } = [];

        [InverseProperty(nameof(PersonQualification.CreatedUser))]
        public ICollection<PersonQualification> CreatedPersonQualifications { get; set; } = [];
        [InverseProperty(nameof(PersonQualification.LastModifiedUser))]
        public ICollection<PersonQualification> LastModifiedPersonQualifications { get; set; } = [];
        [InverseProperty(nameof(PersonQualification.DeletedUser))]
        public ICollection<PersonQualification> DeletedPersonQualifications { get; set; } = [];

        [InverseProperty(nameof(Principal.CreatedUser))]
        public ICollection<Principal> CreatedPrincipals { get; set; } = [];
        [InverseProperty(nameof(Principal.LastModifiedUser))]
        public ICollection<Principal> LastModifiedPrincipals { get; set; } = [];
        [InverseProperty(nameof(Principal.DeletedUser))]
        public ICollection<Principal> DeletedPrincipals { get; set; } = [];

        [InverseProperty(nameof(SchoolPrincipalEnrollment.CreatedUser))]
        public ICollection<SchoolPrincipalEnrollment> CreatedSchoolPrincipalEnrollments { get; set; } = [];
        [InverseProperty(nameof(SchoolPrincipalEnrollment.LastModifiedUser))]
        public ICollection<SchoolPrincipalEnrollment> LastModifiedSchoolPrincipalEnrollments { get; set; } = [];
        [InverseProperty(nameof(SchoolPrincipalEnrollment.DeletedUser))]
        public ICollection<SchoolPrincipalEnrollment> DeletedSchoolPrincipalEnrollments { get; set; } = [];

        [InverseProperty(nameof(PersonRelationship.CreatedUser))]
        public ICollection<PersonRelationship> CreatedPersonRelationships { get; set; } = [];
        [InverseProperty(nameof(PersonRelationship.LastModifiedUser))]
        public ICollection<PersonRelationship> LastModifiedPersonRelationships { get; set; } = [];
        [InverseProperty(nameof(PersonRelationship.DeletedUser))]
        public ICollection<PersonRelationship> DeletedPersonRelationships { get; set; } = [];

        [InverseProperty(nameof(School.CreatedUser))]
        public ICollection<School> CreatedSchools { get; set; } = [];
        [InverseProperty(nameof(School.LastModifiedUser))]
        public ICollection<School> LastModifiedSchools { get; set; } = [];
        [InverseProperty(nameof(School.DeletedUser))]
        public ICollection<School> DeletedSchools { get; set; } = [];

        [InverseProperty(nameof(Student.CreatedUser))]
        public ICollection<Student> CreatedStudents { get; set; } = [];
        [InverseProperty(nameof(Student.LastModifiedUser))]
        public ICollection<Student> LastModifiedStudents { get; set; } = [];
        [InverseProperty(nameof(Student.DeletedUser))]
        public ICollection<Student> DeletedStudents { get; set; } = [];

        [InverseProperty(nameof(SchoolStudentEnrollment.CreatedUser))]
        public ICollection<SchoolStudentEnrollment> CreatedSchoolStudentEnrollments { get; set; } = [];
        [InverseProperty(nameof(SchoolStudentEnrollment.LastModifiedUser))]
        public ICollection<SchoolStudentEnrollment> LastModifiedSchoolStudentEnrollments { get; set; } = [];
        [InverseProperty(nameof(SchoolStudentEnrollment.DeletedUser))]
        public ICollection<SchoolStudentEnrollment> DeletedSchoolStudentEnrollments { get; set; } = [];

        [InverseProperty(nameof(SchoolStudentEnrollmentRequest.CreatedUser))]
        public ICollection<SchoolStudentEnrollmentRequest> CreatedSchoolStudentEnrollmentRequests { get; set; } = [];
        [InverseProperty(nameof(SchoolStudentEnrollmentRequest.LastModifiedUser))]
        public ICollection<SchoolStudentEnrollmentRequest> LastModifiedSchoolStudentEnrollmentRequests { get; set; } = [];
        [InverseProperty(nameof(SchoolStudentEnrollmentRequest.DeletedUser))]
        public ICollection<SchoolStudentEnrollmentRequest> DeletedSchoolStudentEnrollmentRequests { get; set; } = [];

        [InverseProperty(nameof(ClassStudentEnrollment.CreatedUser))]
        public ICollection<ClassStudentEnrollment> CreatedClassStudentEnrollments { get; set; } = [];
        [InverseProperty(nameof(ClassStudentEnrollment.LastModifiedUser))]
        public ICollection<ClassStudentEnrollment> LastModifiedClassStudentEnrollments { get; set; } = [];
        [InverseProperty(nameof(ClassStudentEnrollment.DeletedUser))]
        public ICollection<ClassStudentEnrollment> DeletedClassStudentEnrollments { get; set; } = [];

        [InverseProperty(nameof(Teacher.CreatedUser))]
        public ICollection<Teacher> CreatedTeachers { get; set; } = [];
        [InverseProperty(nameof(Teacher.LastModifiedUser))]
        public ICollection<Teacher> LastModifiedTeachers { get; set; } = [];
        [InverseProperty(nameof(Teacher.DeletedUser))]
        public ICollection<Teacher> DeletedTeachers { get; set; } = [];

        [InverseProperty(nameof(ClassTeacherEnrollment.CreatedUser))]
        public ICollection<ClassTeacherEnrollment> CreatedClassTeacherClassEnrollments { get; set; } = [];
        [InverseProperty(nameof(ClassTeacherEnrollment.LastModifiedUser))]
        public ICollection<ClassTeacherEnrollment> LastModifiedClassTeacherClassEnrollments { get; set; } = [];
        [InverseProperty(nameof(ClassTeacherEnrollment.DeletedUser))]
        public ICollection<ClassTeacherEnrollment> DeletedClassTeacherClassEnrollments { get; set; } = [];

        [InverseProperty(nameof(SchoolTeacherEnrollment.CreatedUser))]
        public ICollection<SchoolTeacherEnrollment> CreatedSchoolTeacherEnrollments { get; set; } = [];
        [InverseProperty(nameof(SchoolTeacherEnrollment.LastModifiedUser))]
        public ICollection<SchoolTeacherEnrollment> LastModifiedSchoolTeacherEnrollments { get; set; } = [];
        [InverseProperty(nameof(SchoolTeacherEnrollment.DeletedUser))]
        public ICollection<SchoolTeacherEnrollment> DeletedSchoolTeacherEnrollments { get; set; } = [];

        [InverseProperty(nameof(SchoolTeacherEnrollmentRequest.CreatedUser))]
        public ICollection<SchoolTeacherEnrollmentRequest> CreatedSchoolTeacherEnrollmentRequests { get; set; } = [];
        [InverseProperty(nameof(SchoolTeacherEnrollmentRequest.LastModifiedUser))]
        public ICollection<SchoolTeacherEnrollmentRequest> LastModifiedSchoolTeacherEnrollmentRequests { get; set; } = [];
        [InverseProperty(nameof(SchoolTeacherEnrollmentRequest.DeletedUser))]
        public ICollection<SchoolTeacherEnrollmentRequest> DeletedSchoolTeacherEnrollmentRequests { get; set; } = [];
    }
}
