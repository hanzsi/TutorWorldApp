using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLayer
{
    [ServiceContract]
    [ServiceKnownType(typeof(Student))]
    [ServiceKnownType(typeof(Teacher))]
    [ServiceKnownType(typeof(TimeSlot))]
    [ServiceKnownType(typeof(WorkDay))]
    [ServiceKnownType(typeof(BookSession))]
    public interface IUserService
    {
        [OperationContract]
        [FaultContract(typeof(UserFault))]
        void Update(UserProfile profile);

        [OperationContract]
        Teacher FindTeacherById(int id);

        [OperationContract]
        Teacher GetAuthenticatedTeacher();

        [OperationContract]
        List<Teacher> GetTeacherList();

        [OperationContract]
        // Same ^^
        Student GetAuthenticatedStudent();

        [OperationContract]
        void CreateWorkDay(WorkDay workDay);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void Book(BookSession session);

        [OperationContract]
        void RemoveBookedSession(BookSession session);

        [OperationContract]
        [FaultContract(typeof(SubjectError))]
        Subject AddSubject(Subject subject);

        [OperationContract]
        Skill AddSkillset(Skill skill, Subject subject);

        [OperationContract]
        void RemoveSkillset(Skill skill, Subject subject);

        [OperationContract]
        [FaultContract(typeof(SubjectError))]
        void RemoveSubject(Subject subject);

        [OperationContract]
        Rating CreateRating(Rating rating);

        [OperationContract]
        List<Rating> GetRatingsBySubject(Subject subject);

        [OperationContract]
        IEnumerable<Subject> GetDistinctSubjets();

        [OperationContract]
        List<Teacher> FilterBySubject(Subject subject);

        [OperationContract]
        [FaultContract(typeof(UserFault))]
        List<Teacher> FilterByPrice(int min, int max);


        [OperationContract]
        List<Teacher> FilterByPostalCode(int pc);

        [OperationContract]
        Student FindById(int id);
    }

    [DataContract]
    class UserFault
    {
        [DataMember]
        public string Issue { get; set; }

        [DataMember]
        public string Details { get; set; }

    }
    [DataContract]
    class SkillError
    {
        [DataMember]
        public string Issue { get; set; }

        [DataMember]
        public string Details { get; set; }
    }

    [DataContract]
    class SubjectError
    {
        [DataMember]
        public string Issue { get; set; }

        [DataMember]
        public string Details { get; set; }
    }

}
