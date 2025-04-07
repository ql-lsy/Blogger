using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.DAL
{
    public class Study
    {
        public static object StudyDAL(int ID)
        {
            using (BoKeDBEntities db = new BoKeDBEntities())
            {
                var coursedata = db.course.FirstOrDefault(x => x.courseId == ID);
                if (coursedata != null)
                {
                    coursedata.courseHit++;
                    return db.SaveChanges() > 0;

                }

                else { return false; }
            }
        }
    }
}