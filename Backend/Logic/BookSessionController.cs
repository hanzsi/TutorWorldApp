using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DatabaseLayer;
using System.Transactions;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Logic
{
    public class BookSessionController
    {

        private DBContext db = new DBContext();
        private static object thisLock = new object();


        public void Create(BookSession session)
        {
            Student stud = db.Students
                .Include("BookSessions")
                .Include("BookSessions.Slot")
                .Where(s => session.Student.Id == s.Id)
                .FirstOrDefault();
            if (stud == null)
            {
                throw new BookSessionException("Unexpected error happened", session);
            }

            foreach(BookSession sesn in stud.BookSessions)
            {
                if(sesn.Slot.StartTime == session.Slot.StartTime)
                {
                    throw new BookSessionException("Please choose a different time slot", session);
                }
            }
            if (session.Slot == null)
            {
                throw new BookSessionException("Please choose a time slot", session);
            }
            if (string.IsNullOrEmpty(session.Topic))
            {
                throw new BookSessionException("Please choose a topic", session);
            }
            if (session.Subject == null)
            {
                throw new BookSessionException("Please choose a subject", session);
            }
            if (!session.Slot.WorkDay.Teacher.Subjects.Contains(session.Subject))
            {
                throw new BookSessionException("This teacher does not teach this subject", session);
            }

            // Unset reference objects so EF wouldn't bother persisting them
            // Only set foreign keys
            session.Slot_Id = session.Slot.Id;
            session.Student_Id = session.Student.Id;
            session.Subject_Id = session.Subject.Id;
            session.Student = null;
            session.Slot = null;
            session.Subject = null;

            // Discard time information
            session.Date = session.Date.Date;

            // The important part
            // This loop may finish in two ways:
            //   An exception is thrown
            //   Transaction gets committed 
            int maxTries = 3;
            for (int attempts = 0; attempts < maxTries; attempts++)
            {
                // We execute two queries, a SELECT and a INSERT
                // Serializable is used because it guarantees that nobody else will insert rows in our range
                //   until this transaction is done(aka "Phantom Rows")
                // When there are no conflicting sessions, there will be no rows in the range therefore SQL server 
                //   will lock the whole table.
                // Since the SELECT operation only acquires a shared lock, other connections may still read data.
                // But if other connections try to insert(like this one), they will need a write lock, just like 
                //   this one. This results in a deadlock. We leave it up to the DBMS to solve this deadlock and
                //   just retry this transaction if it fails up to 3 times.
                // 
                using (var transaction = db.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
                {
                    // Try to find conflicintg sessions
                    // Conflicting session is one using the same time slot and the same date
                    var conflictingSession = db.BookSessions
                        .Where(bs => bs.Slot_Id == session.Slot_Id && bs.Date == session.Date)
                        .FirstOrDefault();
                    if (conflictingSession != null)
                    {
                        throw new BookSessionException("Time already is already taken", session);
                    }

                    // Add new session
                    db.BookSessions.Add(session);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateException e)
                    {
                        SqlException inner = e.InnerException as SqlException;
                        if (inner != null)
                        {
                            if (inner.Number == 1205) // Deadlock SQL server error code
                            {
                                // Since deadlocks do occur, we will only re-try up to 3 times
                                // If a deadlock occurs again, it can not be "luck" so we throw it
                                if (attempts == maxTries)
                                {
                                    throw e;
                                }
                                continue;
                            }
                        }
                        throw e; // Something we do no expect
                    }
                    transaction.Commit();
                    break;
                }
            }

        }

        // TODO CHECK IF THE STUDENT IS ALLOWED TO DO SO (24 HRS)
        public void DeleteSession(BookSession session)
        {

            session = db.BookSessions.Find(session.Id);
            if (session == null)
            {
                throw new BookSessionException("session is null", session);
            }
            else if (0 < session.Date.AddHours(-24).CompareTo(DateTime.Now))
            {
                throw new BookSessionException("Session is beyond cancelling date", session);
            }
            db.BookSessions.Remove(session);
            db.SaveChanges();
        }
    }
}